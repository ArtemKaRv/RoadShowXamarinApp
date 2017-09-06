using System.Collections.ObjectModel;
using App2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using FFImageLoading;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersListPage : ContentPage
    {
        public UsersListPage()
        {
            InitializeComponent();

            var assembly = typeof(App).GetTypeInfo().Assembly;
            var json = ReadJsonFile(assembly.GetManifestResourceStream("App2.Content.Users.json"));
            var users = JsonConvert.DeserializeObject<ObservableCollection<UserViewModel>>(json);

            BindingContext = new UsersListViewModel {Navigation = this.Navigation, Users = users};
            BackgroundImage.Source = ImageSource.FromResource("App2.Content.Images.background.jpg");
            LogoImage.Source = ImageSource.FromResource("App2.Content.Images.logo.png");

            UsersList.BackgroundColor = Color.Transparent;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        /// <summary>
        /// Returns json string from file
        /// </summary>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        private string ReadJsonFile(Stream fileStream)
        {
            using (var reader = new StreamReader(fileStream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}