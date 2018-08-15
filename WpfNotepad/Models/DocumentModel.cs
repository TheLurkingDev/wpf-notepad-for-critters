using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfNotepad.Models
{
    public class DocumentModel : ObservableObject
    {
        private TextBox _editorTextBox;
        private TextBox EditorTextBox
        {
            get
            {
                if(_editorTextBox == null)
                {
                    _editorTextBox = (TextBox)Application.Current.MainWindow.FindName("EditorTextBox");
                }

                return _editorTextBox;
            }
            set { _editorTextBox = value; }
        }


        public string SelectedText
        {            
            get
            {
                return EditorTextBox.SelectedText;                                
            }
            set { EditorTextBox.SelectedText = value; }
        }


        private string _text;
        public string Text
        {
            get { return _text; }
            set { OnPropertyChanged(ref _text, value); }
        }

        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set { OnPropertyChanged(ref _text, value); }
        }

        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { OnPropertyChanged(ref _text, value); }
        }

        public bool IsEmpty
        {
            get
            {
                if(String.IsNullOrEmpty(FileName) || String.IsNullOrEmpty(FilePath))
                {
                    return true;
                }

                return false;
            }
        }
    }
}
