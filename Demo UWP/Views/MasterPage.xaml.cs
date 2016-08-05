using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Demo_UWP.Views
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MasterPage : Page
    {
        public MasterPage()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            Menu.IsPaneOpen = !Menu.IsPaneOpen;
        }
    }
}