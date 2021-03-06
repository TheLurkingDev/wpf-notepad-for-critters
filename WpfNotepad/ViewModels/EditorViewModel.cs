﻿using System.Windows;
using System.Windows.Input;
using WpfNotepad.Models;

namespace WpfNotepad.ViewModels
{
    public class EditorViewModel
    {
        // Must be properties to use binding.
        public ICommand FormatCommand { get; }
        public ICommand WrapCommand { get; }
        public ICommand QuoteCommand { get; }
        public FormatModel Format { get; set; }
        public DocumentModel Document { get; private set; }

        public EditorViewModel(DocumentModel document)
        {
            Document = document;
            Format = new FormatModel();
            FormatCommand = new RelayCommand(OpenStyleDialog);            
            QuoteCommand = new RelayCommand(SetQuoteText);
        }

        private void SetQuoteText()
        {
            var selection = Document.SelectedText;
            var selectedLines = selection.Split(new string[] { "\r\n", "\n" }, System.StringSplitOptions.None);
            selection = "";
            foreach (string line in selectedLines)
            {
                selection += "> " + line + "\r\n";
            }
            Document.SelectedText = selection;
        }

        private void OpenStyleDialog()
        {
            var fontDialog = new FontDialog();
            fontDialog.DataContext = Format;
            fontDialog.ShowDialog();
        }
    }
}
