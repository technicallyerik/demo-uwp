using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;

namespace Demo_UWP.ViewModels.Navigation
{
    
    public class ShellPageNavigationItemViewModel : INotifyPropertyChanged
    {
        private string _tag;
        private string _text;
        private Symbol _glyph;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Tag
        {
            get { return _tag; }
            set
            {
                _tag = value;
                OnPropertyChanged();
            }
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        public Symbol Glyph
        {
            get { return _glyph; }
            set
            {
                _glyph = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}