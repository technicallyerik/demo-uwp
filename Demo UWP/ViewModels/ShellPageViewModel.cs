using System;
using System.Diagnostics;

using Caliburn.Micro;

using Demo_UWP.Events;

namespace Demo_UWP.ViewModels
{
    class ShellPageViewModel : Conductor<IScreen>.Collection.OneActive, IHandle<LoginSuccessfulEvent>
    {
        private bool _loadedAlready;
        private readonly InitialVisitorPageViewModel _initialVisitorPage;
        private readonly ReturnVisitorPageViewModel _returnVisitorPage;
        private readonly MasterPageViewModel _shellPage;
        private readonly IEventAggregator _eventAggregator;

        public ShellPageViewModel(InitialVisitorPageViewModel initialVisitorPage, ReturnVisitorPageViewModel returnVisitorPage, MasterPageViewModel shellPage, IEventAggregator eventAggregator)
        {
            _initialVisitorPage = initialVisitorPage;
            _returnVisitorPage = returnVisitorPage;
            _shellPage = shellPage;
            _eventAggregator = eventAggregator;
        }

        protected override void OnActivate()
        {
            Debug.WriteLine($"Master Page Activated.  Loaded already? {_loadedAlready}");
            _loadedAlready = true;

            _eventAggregator.Subscribe(this);

            var rand = new Random(); // Check if user is currently logged in

            if (rand.Next(0, 2) == 0)
            {
                ActivateItem(_initialVisitorPage);
            }
            else
            {
                ActivateItem(_returnVisitorPage);
            }

            base.OnActivate();
        }

        protected override void OnDeactivate(bool close)
        {
            _eventAggregator.Unsubscribe(this);

            Debug.WriteLine($"Master Page Deactivated.  Closed? {close}");
        }

        public void Handle(LoginSuccessfulEvent message)
        {
            ActivateItem(_shellPage);
        }
    }
}