using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;

using PropertyChanged;

namespace Demo_UWP.ViewModels.Navigation
{
    [ImplementPropertyChanged]
    public class ShellPageNavigationItemViewModel
    {
        public string Tag { get; set; }

        public string Text { get; set; }

        public Symbol Glyph { get; set; }
    }
}