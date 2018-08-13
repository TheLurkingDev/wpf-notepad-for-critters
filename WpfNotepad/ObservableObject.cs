using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfNotepad
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Whatever member fires the event to call this method,
        // it's name will be obtained via [CallerMemberName]
        // instead of resorting to a 'magic string'.
        public void OnPropertyChanged<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
        {
            property = value;
            var handler = PropertyChanged;

            if(handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
