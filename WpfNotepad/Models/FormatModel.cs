using System.Windows;
using System.Windows.Media;

namespace WpfNotepad.Models
{
    public class FormatModel : ObservableObject
    {
        private FontStyle _style;
        public FontStyle Style
        {
            get { return _style; }
            set { OnPropertyChanged(ref _style, value); }
        }

        private FontWeight _fontWeight;
        public FontWeight FontWeight
        {
            get { return _fontWeight; }
            set { OnPropertyChanged(ref _fontWeight, value); }
        }

        private FontFamily _family;
        public FontFamily Family
        {
            get { return _family; }
            set { OnPropertyChanged(ref _family, value); }
        }

        private double _size;
        public double Size
        {
            get { return _size; }
            set { OnPropertyChanged(ref _size, value); }
        }
    }
}
