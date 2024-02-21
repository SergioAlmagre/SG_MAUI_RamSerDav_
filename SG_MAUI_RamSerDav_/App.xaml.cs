using SG_MAUI_RamSerDav_.MVVM.Views;

namespace SG_MAUI_RamSerDav_
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginView()) ;
        }
    }
}
