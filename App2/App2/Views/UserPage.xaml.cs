using System;
using App2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public UserViewModel UserModel { get; private set; }
        public UserPage(UserViewModel user)
        {
            InitializeComponent();
            UserModel = user;
            this.BindingContext = UserModel;
        }
    }
}