using System;

using Windows.Storage;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace DataConverter.Uwp.Helpers
{
    /// <summary>Class providing functionality around switching and restoring theme settings</summary>
    public static class ThemeHelper
    {
        private const string SelectedAppThemeKey = "SelectedAppTheme";
        private static Window currentApplicationWindow;

        // Keep reference so it does not get optimized/garbage collected
        private static UISettings uiSettings;

        /// <summary>
        ///     Gets the current actual theme of the app based on the requested theme of the root
        ///     element, or if that value is Default, the requested theme of the Application.
        /// </summary>
        public static ElementTheme ActualTheme
        {
            get
            {
                if (Window.Current.Content is FrameworkElement rootElement &&
                    rootElement.RequestedTheme != ElementTheme.Default)
                    return rootElement.RequestedTheme;

                return Enum.Parse<ElementTheme>(Application.Current.RequestedTheme.ToString());
            }
        }

        /// <summary>
        ///     Gets or sets (with LocalSettings persistence) the RequestedTheme of the root element.
        /// </summary>
        public static ElementTheme RootTheme
        {
            get
            {
                if (Window.Current.Content is FrameworkElement rootElement)
                    return rootElement.RequestedTheme;

                return ElementTheme.Default;
            }
            set
            {
                if (Window.Current.Content is FrameworkElement rootElement)
                    rootElement.RequestedTheme = value;

                ApplicationData.Current.LocalSettings.Values[SelectedAppThemeKey] = value.ToString();
                UpdateSystemCaptionButtonColors();
            }
        }

        public static void Initialize()
        {
            // Save reference as this might be null when the user is in another app
            currentApplicationWindow = Window.Current;
            var savedTheme = ApplicationData.Current.LocalSettings.Values[SelectedAppThemeKey]?.ToString();

            if (savedTheme != null)
                RootTheme = Enum.Parse<ElementTheme>(savedTheme);

            // Registering to color changes, thus we notice when user changes theme system wide
            uiSettings = new UISettings();
            uiSettings.ColorValuesChanged += UiSettings_ColorValuesChanged;
        }

        private static void UiSettings_ColorValuesChanged(UISettings sender, object args)
        {
            // Make sure we have a reference to our window so we dispatch a UI change
            if (currentApplicationWindow != null)
            {
                // Dispatch on UI thread so that we have a current appbar to access and change
                _ = currentApplicationWindow.Dispatcher.RunAsync(
                    Windows.UI.Core.CoreDispatcherPriority.High,
                    () => UpdateSystemCaptionButtonColors());
            }
        }

        public static bool IsDarkTheme()
        {
            return RootTheme == ElementTheme.Default
                ? Application.Current.RequestedTheme == ApplicationTheme.Dark
                : RootTheme == ElementTheme.Dark;
        }

        public static void UpdateSystemCaptionButtonColors()
        {
            ApplicationView.GetForCurrentView().TitleBar.ButtonForegroundColor = IsDarkTheme() 
                ? (Color?)Colors.White
                : (Color?)Colors.Black;
        }
    }
}
