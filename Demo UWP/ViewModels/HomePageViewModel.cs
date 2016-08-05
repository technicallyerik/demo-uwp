using System;
using System.Diagnostics;

using Caliburn.Micro;

namespace Demo_UWP.ViewModels
{
    public class HomePageViewModel : Screen
    {
        private bool _loadedAlready;

        protected override void OnActivate()
        {
            Debug.WriteLine($"Home Page Activated.  Loaded already? {_loadedAlready}");
            _loadedAlready = true;
        }

        protected override void OnDeactivate(bool close)
        {
            Debug.WriteLine($"Home Page Deactivated.  Closed? {close}");
        }
    }
}