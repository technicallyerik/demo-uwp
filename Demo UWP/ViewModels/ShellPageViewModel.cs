using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.UI.Xaml.Controls;

using Caliburn.Micro;

namespace Demo_UWP.ViewModels
{
    public class ShellPageViewModel : Screen
    {
        private readonly WinRTContainer _container;
        private readonly IEventAggregator _eventAggregator;
        private INavigationService _navigationService;
        public ShellPageViewModel(WinRTContainer container, IEventAggregator eventAggregator)
        {
            _container = container;
            _eventAggregator = eventAggregator;
        }

        public void SetupNavigationService(Frame frame)
        {
            if (_container.HasHandler(typeof(INavigationService), null))
                _container.UnregisterHandler(typeof(INavigationService), null);

            _navigationService = _container.RegisterNavigationService(frame);
        }

        public void MenuItemSelected(ListBoxItem item)
        {
            switch (item.Tag.ToString())
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
