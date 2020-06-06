using System;

using Microsoft.UI.Xaml.Controls;

using Windows.Foundation.Metadata;
using Windows.UI.Xaml;

namespace DataConverter.Uwp.Views
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            Current = this;
            InitializeComponent();
        }

        public static MainPage Current { get; private set; }

        public string AppTitleFromSystem => Windows.ApplicationModel.Package.Current.DisplayName;

        private void NavigationViewControl_PaneClosing(NavigationView sender, NavigationViewPaneClosingEventArgs args)
            => UpdateAppTitleMargin(sender);

        private void OnNavigationPaneOpened(NavigationView sender, object args)
            => UpdateAppTitleMargin(sender);

        private void OnNavigationDisplayModeChanged(NavigationView sender, NavigationViewDisplayModeChangedEventArgs args)
        {
            var currMargin = AppTitleBar.Margin;
            AppTitleBar.Margin = sender.DisplayMode == NavigationViewDisplayMode.Minimal
                ? new Thickness(sender.CompactPaneLength * 2, currMargin.Top, currMargin.Right, currMargin.Bottom)
                : new Thickness(sender.CompactPaneLength, currMargin.Top, currMargin.Right, currMargin.Bottom);

            UpdateAppTitleMargin(sender);
        }

        private void UpdateAppTitleMargin(NavigationView sender)
        {
            const int SmallLeftIndent = 4, LargeLeftIndent = 24;

            if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
            {
                AppTitle.TranslationTransition = new Vector3Transition();

                AppTitle.Translation = (sender.DisplayMode == NavigationViewDisplayMode.Expanded && sender.IsPaneOpen) ||
                         sender.DisplayMode == NavigationViewDisplayMode.Minimal
                    ? new System.Numerics.Vector3(SmallLeftIndent, 0, 0)
                    : new System.Numerics.Vector3(LargeLeftIndent, 0, 0);
            }
            else
            {
                var currMargin = AppTitle.Margin;

                AppTitle.Margin = (sender.DisplayMode == NavigationViewDisplayMode.Expanded && sender.IsPaneOpen) ||
                         sender.DisplayMode == NavigationViewDisplayMode.Minimal
                    ? new Thickness(SmallLeftIndent, currMargin.Top, currMargin.Right, currMargin.Bottom)
                    : new Thickness(LargeLeftIndent, currMargin.Top, currMargin.Right, currMargin.Bottom);
            }
        }

        private void OnNavigate(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItemContainer.IsSelected)
            {
                // Clicked on an item that is already selected, Avoid navigating to the same page
                // again causing movement.
                return;
            }

            var invokedItem = args.InvokedItemContainer;
            Type type = null;
            if (invokedItem == ConverterMenuItem)
                type = typeof(ConverterPage);
            else if (invokedItem == ColorToolMenuItem)
                type = typeof(ColorToolPage);

            if (type != null && RootFrame.CurrentSourcePageType != type)
                _ = RootFrame.Navigate(type);
        }
    }
}
