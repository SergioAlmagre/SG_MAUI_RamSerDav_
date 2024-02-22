using Microsoft.Maui.Controls.PlatformConfiguration;
using SG_MAUI_RamSerDav_.MVVM.Models;
using SG_MAUI_RamSerDav_.MVVM.ViewModels;
using SG_MAUI_RamSerDav_.MVVM.Views;
using SG_MAUI_RamSerDav_.Repositories;

namespace SG_MAUI_RamSerDav_
{
    public partial class App : Application
    {
        public static BaseRepository<Usuario> UsuarioRepo { get; private set; }
        public App(BaseRepository<Usuario> usuRepo)
        {
            UsuarioRepo = usuRepo;
            InitializeComponent();
            MainPage = new NavigationPage(new LoginView()) ;
            //MainPage.On<Windows>().SetToolbarPlacement(ToolbarPlacement.Bottom); // Ocultar los botones de minimizar y cerrar la aplicación
        }
    }
}
