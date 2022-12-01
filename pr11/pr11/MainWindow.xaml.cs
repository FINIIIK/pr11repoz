using pr11.TextEditorUsingPatternMemento;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr11 {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public int i = 0;
        TextClass objText = new TextClass { 
            Text = "", 
            Original = new TextClassClone {Text = "",}
        };

        public MainWindow() {
            InitializeComponent();
            FontSize.SelectedIndex = 0;
            FontStyle.SelectedIndex = 0;

            ComboBoxItem ItemValue = (ComboBoxItem)FontSize.SelectedItem;
            TextBlock.FontSize = int.Parse(ItemValue.Content.ToString());

            ComboBoxItem StyleValue = (ComboBoxItem)FontStyle.SelectedItem;
            switch (StyleValue.Content.ToString()) {
                case "Regular":
                    TextBlock.FontStyle = FontStyles.Normal;
                    break;
                case "Italic":
                    TextBlock.FontStyle = FontStyles.Italic;
                    break;
                case "Bold":
                    if (i == 0) {
                        TextBlock.FontWeight = FontWeights.Bold;
                        i++;
                    }
                    else {
                        TextBlock.FontWeight = FontWeights.Normal;
                        i--;
                    }
                    break;
                default:
                    TextBlock.FontStyle = FontStyles.Normal;
                    break;
            }
        }

        private void FontSize_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ComboBoxItem ItemValue = (ComboBoxItem)FontSize.SelectedItem;
            TextBlock.FontSize = int.Parse(ItemValue.Content.ToString());
        }

        private void FontStyle_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            ComboBoxItem StyleValue = (ComboBoxItem)FontStyle.SelectedItem;
            switch (StyleValue.Content.ToString()) {
                case "Regular":
                    TextBlock.FontStyle = FontStyles.Normal;
                    break;
                case "Italic":
                    TextBlock.FontStyle = FontStyles.Italic;
                    break;
                case "Bold":
                    if (i == 0) {
                        TextBlock.FontWeight = FontWeights.Bold;
                        i++;
                    }
                    else {
                        TextBlock.FontWeight = FontWeights.Normal;
                        i--;
                    }
                    break;
                default:
                    TextBlock.FontStyle = FontStyles.Normal;
                    break;
            }
        }

        private void save_Click(object sender, RoutedEventArgs e) {
            objText.Text = TextBlock.Text;
            if (objText.IsModified()) objText.Original.Text = objText.Text;
        }

        private void DisplayDetalis() {
            TextBlock.Text = objText.Text;
        }

        private void back_Click(object sender, RoutedEventArgs e) {
            objText.Revert();
            DisplayDetalis();
        }
    }

    class Memento {
        public string State { get; private set; }
        public Memento(string state) {
            this.State = state;
        }
    }

    class Caretaker {
        public Memento Memento { get; set; }
    }

    class Originator {
        public string State { get; set; }
        public void SetMemento(Memento memento) {
            State = memento.State;
        }
        public Memento CreateMemento() {
            return new Memento(State);
        }
    }
}
