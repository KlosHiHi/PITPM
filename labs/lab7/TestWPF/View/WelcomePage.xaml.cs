using System.Windows.Controls;

namespace TestWPF.View
{
    public partial class WelcomePage : Page
    {
        public string login; 
        public string role;

        public WelcomePage()
        {
            InitializeComponent();

            WelcomeTextBlock.Text = $"Добро пожаловать, {login}, Ваша роль - {role}";
        }
    }
}
