using Microsoft.Maui.Controls.PlatformConfiguration;
using SG_MAUI_RamSerDav_.MVVM.Models;
using SG_MAUI_RamSerDav_.MVVM.ViewModels;
using SG_MAUI_RamSerDav_.MVVM.Views;
using SG_MAUI_RamSerDav_.Repositories;

namespace SG_MAUI_RamSerDav_
{
    /// <summary>
    /// Hilo Principal del Proyecto.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Repositorio de usuarios, definido para poder alcanzarlo durante todo el proyecto.
        /// </summary>
        public static BaseRepository<Usuario> UsuarioRepo { get; private set; }

        /// <summary>
        /// Constructor de la clase App.
        /// </summary>
        /// <param name="usuRepo">Repositorio de usuarios.</param>
        public App(BaseRepository<Usuario> usuRepo)
        {
            // Inicializa el repositorio de usuarios
            UsuarioRepo = usuRepo;

            // Inicializa los componentes de la aplicación
            InitializeComponent();

            // Ponemos como pagina principal LoginView
            MainPage = new NavigationPage(new LoginView());

            // Opcional: Ocultar los botones de minimizar y cerrar la aplicación en plataformas específicas
            // MainPage.On<Windows>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}