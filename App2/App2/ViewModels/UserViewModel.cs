using System.ComponentModel;
using System.Runtime.CompilerServices;
using App2.Annotations;
using App2.Models;

namespace App2.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private UsersListViewModel usersList;

        public User User { get; private set; }

        public UserViewModel()
        {
            User = new User
            {
                Avatar = "",
                Name = "",
                Description = ""
            };
        }

        public UsersListViewModel ListViewModel
        {
            get => usersList;
            set
            {
                if (usersList != value)
                {
                    usersList = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => User.Name;
            set
            {
                if (!User.Name.Equals(value))
                {
                    User.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Avatar
        {
            get => User.Avatar;
            set
            {
                if (!User.Avatar.Equals(value))
                {
                    User.Avatar = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Description
        {
            get => User.Description;
            set
            {
                if (!User.Description.Equals(value))
                {
                    User.Description = value;
                    OnPropertyChanged();
                }
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}