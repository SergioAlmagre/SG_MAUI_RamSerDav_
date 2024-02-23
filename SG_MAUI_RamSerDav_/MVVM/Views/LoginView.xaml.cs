using SG_MAUI_RamSerDav_.MVVM.ViewModels;

namespace SG_MAUI_RamSerDav_.MVVM.Views
{
    /// <summary>
    /// Clase View para la vista de inicio de sesión.
    /// </summary>
    public partial class LoginView : ContentPage
    {
        /// <summary>
        /// Constructor de la clase LoginView.
        /// </summary>
        public LoginView()
        {
            InitializeComponent();

            // Oculta la barra de navegación
            NavigationPage.SetHasNavigationBar(this, false);

            // Establece el contexto de enlace con una nueva instancia del ViewModel de inicio de sesión
            BindingContext = new LoginViewModel();
        }

        /// <summary>
        /// Manejador de eventos para el cambio de estado del interruptor de tema.
        /// </summary>
        private void CambiarTema_Toggled(object sender, EventArgs e)
        {
            // Cambia el tema de la aplicación según el estado del interruptor
            if (Application.Current.UserAppTheme == AppTheme.Dark)
            {
                Application.Current.UserAppTheme = AppTheme.Light;
            }
            else
            {
                Application.Current.UserAppTheme = AppTheme.Dark;
            }
        }
    }
}