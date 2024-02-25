using SG_MAUI_RamSerDav_.Auxiliar;
using SG_MAUI_RamSerDav_.MVVM.Views;
using System.Windows.Input;

namespace SG_MAUI_RamSerDav_.MVVM.ViewModels
{
    /// <summary>
    /// ViewModel para la Vista Principal.
    /// </summary>
    public class PPrincipalViewModel
    {
        /// <summary>
        /// Comando para navegar a la vista de gestión de usuarios.
        /// </summary>
        public ICommand btnIrGestionUsuariosCommand { get; set; }

        /// <summary>
        /// Comando para salir de la aplicación.
        /// </summary>
        public ICommand btnSalirCommand { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public PPrincipalViewModel()
        {
            // Inicialización de los comandos
            btnIrGestionUsuariosCommand = new Command(() =>
            {
                // Navega a la vista de gestión de usuarios al presionar el botón correspondiente
                App.Current.MainPage.Navigation.PushAsync(new GestionUsuariosView());
            });

            btnSalirCommand = new Command(async () =>
            {
                // Muestra un mensaje de confirmación antes de salir de la aplicación
                bool confirmacion = await Herramientas.MensajeConfirmacion("info", "Desea salir de la aplicación?");
                if (confirmacion)
                {
                    System.Environment.Exit(0); // Salir de la Aplicación
                }
            });
        }
    }
}

