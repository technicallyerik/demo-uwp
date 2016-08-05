using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

using Windows.UI.Xaml.Controls;

using Caliburn.Micro;

using Demo_UWP.ViewModels.Navigation;

using PropertyChanged;

namespace Demo_UWP.ViewModels
{
    [ImplementPropertyChanged]
    public class ShellPageViewModel : Screen
    {
        private bool _loadedAlready;
        private readonly WinRTContainer _container;
        private INavigationService _navigationService;
        public ObservableCollection<ShellPageNavigationItemViewModel> MainNavigationItems { get; set; }
        public ShellPageNavigationItemViewModel SelectedMainNavigationItem { get; set; }

        public ShellPageViewModel(WinRTContainer container)
        {
            _container = container;
        }

        protected override void OnActivate()
        {
            Debug.WriteLine($"Shell Page Activated.  Loaded already? {_loadedAlready}");

            MainNavigationItems = new BindableCollection<ShellPageNavigationItemViewModel>
            {
                new ShellPageNavigationItemViewModel { Tag = "Home", Text = "Home", Glyph = Symbol.Home },
                new ShellPageNavigationItemViewModel { Tag = "Favorites", Text = "Favorites", Glyph = Symbol.OutlineStar },
                new ShellPageNavigationItemViewModel { Tag = "Settings", Text = "Settings", Glyph = Symbol.Setting }
            };
        }

        protected override void OnDeactivate(bool close)
        {
            Debug.WriteLine($"Master Page Deactivated.  Closed? {close}");
        }

        public void SetupNavigationService(Frame frame)
        {
            if (_container.HasHandler(typeof(INavigationService), null))
            {
                _container.UnregisterHandler(typeof(INavigationService), null);
            }

            _navigationService = _container.RegisterNavigationService(frame);
            SelectedMainNavigationItem = MainNavigationItems.First();
        }

        public void MenuItemSelected()
        {
            switch (SelectedMainNavigationItem.Tag)
            {
                case "Home":
                    _navigationService.NavigateToViewModel<HomePageViewModel>();
                    break;
                case "Favorites":
                    _navigationService.NavigateToViewModel<FavoritesPageViewModel>();
                    break;
                case "Settings":
                    _navigationService.NavigateToViewModel<SettingsPageViewModel>();
                    break;
            }
        }
    }
}