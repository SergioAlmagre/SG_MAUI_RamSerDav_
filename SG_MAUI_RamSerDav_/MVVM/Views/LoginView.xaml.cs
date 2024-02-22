using SG_MAUI_RamSerDav_.MVVM.ViewModels;

namespace SG_MAUI_RamSerDav_.MVVM.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); // Ocultar la barra de título
            BindingContext = new LoginViewModel();
        }
    }
}