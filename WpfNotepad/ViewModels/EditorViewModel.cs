using System.Windows;
using System.Windows.Input;
using WpfNotepad.Models;

namespace WpfNotepad.ViewModels
{
    public class EditorViewModel
    {
        // Must be properties to use binding.
        public ICommand FormatCommand { get; }
        public ICommand WrapCommand { get; }
        public FormatModel Format { get; set; }
        public DocumentModel Document { get; private set; }

        public EditorViewModel(DocumentModel document)
        {
            Document = document;
            Format = new FormatModel();
            FormatCommand = new RelayCommand(OpenStyleDialog);
            WrapCommand = new RelayCommand(ToggleWrap);
        }

        private void OpenStyleDialog()
        {
            var fontDialog = new FontDialog();
            fontDialog.DataContext = Format;
            fontDialog.ShowDialog();
        }

        private void ToggleWrap()
        {
            if (Format.Wrap == TextWrapping.Wrap)
                Format.Wrap = TextWrapping.NoWrap;
            else
                Format.Wrap = TextWrapping.Wrap;
        }
    }
}
