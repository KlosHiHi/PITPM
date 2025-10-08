using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TestProgramWPF.Model;

namespace TestProgramWPF.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel()
        {
            Users = new ObservableCollection<User>
            {
            new User { Login = "admin",Password = "admin", Role = Role.Administator},
            new User { Login = "kloshi",Password = "qwerty", Role = Role.User},
            new User { Login = "circoniy",Password = "12345", Role = Role.User},
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
