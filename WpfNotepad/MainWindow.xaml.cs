using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfNotepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EditorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            var originalCaretPosition = textBox.CaretIndex;
            List<string> textLines = new List<string>();
            textLines = textBox.Text.Split(new string[] { "\r\n", "\n" }, System.StringSplitOptions.None).ToList();
            
            bool linesOver70 = false;

            for (int count = 0; count < textLines.Count; count++)
            {
                

                if (textLines[count].Length > 70)
                {
                    var lineUnder70 = textLines[count].Substring(0, 70);
                    var lineOverflow = textLines[count].Substring(70, textLines[count].Length - 70);
                    textLines[count] = lineUnder70;

                    if(textLines.Count == count + 1)
                    {
                        textLines.Add(String.Empty);
                    }

                    textLines[count + 1] = lineOverflow + textLines[count + 1];

                    linesOver70 = true;
                }
            }

            if(linesOver70)
            {
                textBox.Text = "";
                
                foreach(string line in textLines)
                {
                    textBox.Text += line + "\r\n";
                }

                char charAtPosition = textBox.Text[originalCaretPosition];
                
                if(charAtPosition == '\n')
                {
                    textBox.CaretIndex = originalCaretPosition + 2;
                }
                else
                {
                    textBox.CaretIndex = originalCaretPosition;
                }                
            }
        }
    }
}
