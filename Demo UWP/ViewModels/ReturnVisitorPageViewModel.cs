using System;
using System.Diagnostics;

using Caliburn.Micro;

using Demo_UWP.Events;

namespace Demo_UWP.ViewModels
{
    class ReturnVisitorPageViewModel : Screen
    {
        private bool _loadedAlready;
        private readonly IEventAggregator _eventAggregator;

        public ReturnVisitorPageViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public void LetUserIn()
        {
            _eventAggregator.PublishOnUIThread(new LoginSuccessfulEvent());
        }

        protected override void OnActivate()
        {
            Debug.WriteLine($"Return Visitor Page Activated.  Loaded already? {_loadedAlready}");
            _loadedAlready = true;
        }

        protected override void OnDeactivate(bool close)
        {
            Debug.WriteLine($"Return Visitor Page Deactivated.  Closed? {close}");
        }
    }
}