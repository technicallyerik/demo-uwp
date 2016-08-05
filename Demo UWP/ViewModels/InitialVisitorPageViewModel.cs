using System;
using System.Diagnostics;

using Caliburn.Micro;

using Demo_UWP.Events;

namespace Demo_UWP.ViewModels
{
    public class InitialVisitorPageViewModel : Screen
    {
        private bool _loadedAlready;
        private readonly IEventAggregator _eventAggregator;

        public InitialVisitorPageViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public void LetUserIn()
        {
            _eventAggregator.PublishOnUIThread(new LoginSuccessfulEvent());
        }

        protected override void OnActivate()
        {
            Debug.WriteLine($"Initial Visitor Page Activated.  Loaded already? {_loadedAlready}");
            _loadedAlready = true;
        }

        protected override void OnDeactivate(bool close)
        {
            Debug.WriteLine($"Initial Visitor Page Deactivated.  Closed? {close}");
        }
    }
}