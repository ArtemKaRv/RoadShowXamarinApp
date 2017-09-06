using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using App2.Annotations;
using App2.Views;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class UsersListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<UserViewModel> Users { get; set; }

        public ICommand BackCommand;

        public ICommand AboutCommand;

        private UserViewModel selectedUser;

        public INavigation Navigation;

        public UsersListViewModel()
        {
            AboutCommand = new Command(About);
        }

        public UserViewModel SelectedFriend
        {
            get => selectedUser;
            set
            {
                if (selectedUser != value)
                {
                    var tempFriend = value;
                    selectedUser = null;
                    OnPropertyChanged();
                    Navigation.PushAsync(new UserPage(tempFriend));
                }
            }
        }

        public void About()
        {
            Navigation.PushAsync(new UserPage(selectedUser));
        }

        public void Back()
        {
            Navigation.PopAsync();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}