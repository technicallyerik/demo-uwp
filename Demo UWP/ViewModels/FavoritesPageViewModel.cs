using System;
using System.Diagnostics;

using Caliburn.Micro;

namespace Demo_UWP.ViewModels
{
    public class FavoritesPageViewModel : Screen
    {
        private bool _loadedAlready;

        protected override void OnActivate()
        {
            Debug.WriteLine($"Favorites Page Activated.  Loaded already? {_loadedAlready}");
            _loadedAlready = true;
        }

        protected override void OnDeactivate(bool close)
        {
            Debug.WriteLine($"Favorites Page Deactivated.  Closed? {close}");
        }
    }
}