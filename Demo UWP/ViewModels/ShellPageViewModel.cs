using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.UI.Xaml.Controls;

using Caliburn.Micro;
using Demo_UWP.ViewModels.Navigation;

namespace Demo_UWP.ViewModels
{
    public class ShellPageViewModel : Screen
    {
        private readonly WinRTContainer _container;
        private readonly IEventAggregator _eventAggregator;
        private INavigationService _navigationService;
        private ObservableCollection<ShellPageNavigationItemViewModel> _mainNavigationItems;
        private ShellPageNavigationItemViewModel _selectedMainNavigationItem;

        public ObservableCollection<ShellPageNavigationItemViewModel> MainNavigationItems
        {
            get { return _mainNavigationItems; }
            set
            {
                _mainNavigationItems = value;
                NotifyOfPropertyChange();
            }
        }

        public ShellPageNavigationItemViewModel SelectedMainNavigationItem
        {
            get { return _selectedMainNavigationItem; }
            set
            {
                _selectedMainNavigationItem = value;
                NotifyOfPropertyChange();
            }
        }

        public ShellPageViewModel(WinRTContainer container, IEventAggregator eventAggregator)
        {
            _container = container;
            _eventAggregator = eventAggregator;
        }

        protected override void OnActivate()
        {
            MainNavigationItems = new BindableCollection<ShellPageNavigationItemViewModel>
            {
                new ShellPageNavigationItemViewModel { Tag = "Home", Text = "Home", Glyph = Symbol.Home },
                new ShellPageNavigationItemViewModel { Tag = "Favorites", Text = "Favorites", Glyph = Symbol.OutlineStar },
                new ShellPageNavigationItemViewModel { Tag = "Settings", Text = "Settings", Glyph = Symbol.Setting }
            };
        }

        public void SetupNavigationService(Frame frame)
        {
            if (_container.HasHandler(typeof(INavigationService), null))
                _container.UnregisterHandler(typeof(INavigationService), null);

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
