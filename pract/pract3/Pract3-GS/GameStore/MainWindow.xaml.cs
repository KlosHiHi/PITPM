using GameStore.ViewModels;
using System.Windows;

namespace GameStore
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            (DataContext as MainViewModel).SendMessage += (s, e) => MessageBox.Show(e.Message, e.Caption, e.Button, e.Icon);
        }
    }
}