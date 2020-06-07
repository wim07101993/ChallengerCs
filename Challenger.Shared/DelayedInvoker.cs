using System;
using System.Timers;

namespace Challenger.Shared
{
    public class DelayedInvoker
    {
        private readonly object _lock = new object();
        private readonly Timer _updateDelaytimer;

        public DelayedInvoker(double delay)
        {
            _updateDelaytimer = new Timer(delay);
        }

        public void Update(Action action)
        {
            lock (_lock)
            {
                if (!_updateDelaytimer.Enabled)
                    _updateDelaytimer.Elapsed += StartUpdateAsync;

                _updateDelaytimer.Enabled = false;
                _updateDelaytimer.Enabled = true;
            }

            void StartUpdateAsync(object timer, ElapsedEventArgs args)
            {
                _updateDelaytimer.Enabled = false;
                _updateDelaytimer.Elapsed -= StartUpdateAsync;
                action();
            }
        }
    }
}
