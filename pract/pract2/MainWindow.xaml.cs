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

namespace practwork2
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Добро пожаловать!");
            var result = MessageBox.Show("что вы хотите сасиску или пюрешку", "menu", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
                MessageBox.Show("вы выбрали пюрешку");
            else
                MessageBox.Show("вы выбрали сасиську");
        }
    }
}