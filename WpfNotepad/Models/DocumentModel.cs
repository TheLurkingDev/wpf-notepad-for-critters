using System;

namespace WpfNotepad.Models
{
    public class DocumentModel : ObservableObject
    {
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
