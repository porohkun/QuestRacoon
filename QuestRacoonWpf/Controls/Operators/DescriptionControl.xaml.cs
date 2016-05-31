using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using System.Xml;
using QuestRacoonWpf.Quest;

namespace QuestRacoonWpf
{
    /// <summary>
    /// Interaction logic for DescriptionControl.xaml
    /// </summary>
    public partial class DescriptionControl : BaseOperatorControl
    {
        double _row0H = 0;
        double _row1H = 0;

        private Description _description;
        
        public DescriptionControl()
        {
            if (HighlightingManager.Instance.HighlightingDefinitions.Count(d => d.Name == "Custom Highlighting") == 0)
            {
                IHighlightingDefinition customHighlighting;
                using (Stream s = typeof(BlockEditWindow).Assembly.GetManifestResourceStream("QuestRacoonWpf.CustomHighlighting.xshd"))
                {
                    if (s == null)
                        throw new InvalidOperationException("Could not find embedded resource");
                    using (XmlReader reader = new XmlTextReader(s))
                    {
                        customHighlighting = ICSharpCode.AvalonEdit.Highlighting.Xshd.
                            HighlightingLoader.Load(reader, HighlightingManager.Instance);
                    }
                }
                HighlightingManager.Instance.RegisterHighlighting("Custom Highlighting", new string[] { ".cool" }, customHighlighting);
            }

            InitializeComponent();
            
            textBox.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("Custom Highlighting");

            _row0H = row0.Height.Value;
            _row1H = row1.Height.Value;
            row0.Height = new GridLength(0);
            row1.Height = new GridLength(0);
        }

        public DescriptionControl(Description description):this()
        {
            _description = description;
        }

        protected override void UpdateText()
        {
            textBox.Text = _description.Text.GetText(Locale);
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            row0.Height = new GridLength(0);
            row1.Height = new GridLength(0);
            textBox.MaxHeight = 25;
            _description.Text.SetText(textBox.Text, Locale);
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            row0.Height = new GridLength(_row0H);
            row1.Height = new GridLength(_row1H);
            textBox.MaxHeight = 92;
            textBox.Height = 92;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var action = ((string)((Button)sender).Content).Trim();

            switch (action)
            {
                case "{b}": InsertAction("{b}", "{/b}"); break;
                case "{i}": InsertAction("{i}", "{/i}"); break;
                case "{color}": InsertAction("{color=red}", "{/color}", -4, 3); break;
                case "{s}": InsertAction("{s=1}", "{/s}", -2, 1); break;
                case "{w}": InsertAction("{w=1}", "{/w}",-2 ,1); break;
                case "{wi}": InsertAction("{wi}"); break;
                case "{wc}": InsertAction("{wc}"); break;
                case "{c}": InsertAction("{c}"); break;
                case "{x}": InsertAction("{x}"); break;
            }
        }

        private void InsertAction(string open, string close = "", int offset = 0, int length = 0)
        {
            int start = textBox.SelectionStart;
            int sLength = textBox.SelectionLength;
            string[] text = new string[]
            {
                textBox.Text.Substring(0, start),
                textBox.Text.Substring(start, sLength),
                textBox.Text.Substring(start + sLength)
            };
            var sb = new StringBuilder();
            sb.Append(text[0]);
            sb.Append(open);
            sb.Append(text[1]);
            sb.Append(close);
            sb.Append(text[2]);

            start += open.Length + offset;

            textBox.Text = sb.ToString();
            textBox.Select(start, length);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            _description.Delete();
            OnVantBeDeleted(this);
        }
    }
}
