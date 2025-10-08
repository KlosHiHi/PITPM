using System.Windows;
using TestWPF.Model;
using TestWPF.View;

namespace TestWPF
{
    public partial class MainWindow : Window
    {
        private List<User> _users;
        public List<User> Users = new()
        {
            new User { Login = "admin",Password = "admin", Role = Role.Administator },
            new User { Login = "kloshi",Password = "qwerty", Role = Role.User },
            new User { Login = "circoniy", Password = "12345", Role = Role.User },
        };

        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new AuthorizationPage());
        }
    }
}