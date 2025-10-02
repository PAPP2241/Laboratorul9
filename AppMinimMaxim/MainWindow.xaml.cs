using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppMinimMaxim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DigitAnalyzer Logic => (DigitAnalyzer)Resources["Logic"];
        public MainWindow()
        {
            InitializeComponent();
        }
        private static readonly Regex _allowed = new(@"^[0-9+\-\s]*$");
        private void txtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !_allowed.IsMatch(e.Text);
        }

        private void Maxim_Click(object sender, RoutedEventArgs e)
        {
            if (Logic.MaxDigit is int max)
            {
                Logic.ResultText = $"Cifra maxima: {max}";
            }
            else
            {
                Logic.ResultText = "Nu au fost gasite cifre in text!";
            }
        }

        private void Minim_Click(object sender, RoutedEventArgs e)
        {
            if (Logic.MinDigit is int min)
            {
                Logic.ResultText = $"Cifra minima: {min}";
            }
            else
            {
                Logic.ResultText = "Nu au fost gasite cifre in text!";
            }
        }
    }
}