using System.Windows.Input;
using System.ComponentModel;
using SG_MAUI_RamSerDav_.MVVM.Models;
using PropertyChanged;
using SG_MAUI_RamSerDav_.MVVM.Abstractions;
using SG_MAUI_RamSerDav_.Auxiliar;

namespace SG_MAUI_RamSerDav_.MVVM.ViewModels
{
    /// <summary>
    /// ViewModel de inicio de sesión.
    /// </summary>
    [AddINotifyPropertyChangedInterface] // Agrega automáticamente la implementación de repintes
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; // Evento para notificar cambios de propiedad, sin esto no se ha conseguido cumplir la condicion de pasar de desabilitado a habilitado el boton al escribir

        /// <summary>
        /// usuario encontrado en la bbdd
        /// </summary>
        public Usuario usuarioEncontrado { get; set; } = new Usuario();

        /// <summary>
        /// Propiedad para el estado del tema oscuro
        /// </summary>
        public bool TemaOscuroActivado { get; set; }

        /// <summary>
        /// Comandos De botones y acciones
        /// </summary>
        public ICommand limpiarCommand { get; set; }
        public ICommand aceptarCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        /// <summary>
        /// Propiedad para la verificación del estado de los text, email y contraseña
        /// </summary>
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(IsAceptarEnabled));
            }
        }
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(IsAceptarEnabled));
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public LoginViewModel()
        {
            limpiarCommand = new Command(ClearFields);
            aceptarCommand = new Command(inicioSesion, () => IsAceptarEnabled);
            TemaOscuroActivado = false;

            // Comando para salir de la aplicación
            ExitCommand = new Command(async () =>
            {
                bool confirmacion = await Herramientas.MensajeConfirmacion("info", "Desea salir de la aplicación?");
                if (confirmacion)
                {
                    System.Environment.Exit(0); // Se cierra la aplicación
                }
            });
        }

        // Propiedad para habilitar/deshabilitar el boton de aceptar
        public bool IsAceptarEnabled => !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);

        // Método para limpiar los campos de email y contraseña
        private void ClearFields()
        {
            Email = string.Empty;
            Password = string.Empty;
        }

        /// <summary>
        /// Método para el inicio de sesión
        /// </summary>
        private async void inicioSesion()
        {
            // Validación del email
            if (!Herramientas.emailCumpleMascara(Email))
            {
                await Herramientas.MensajeInfomativoAsync("El correo electrónico no es válido");
                return; // Necesario para no pasar por mas Opciones
            }

            // Validación de la contraseña
            if (!Herramientas.passwordCumpleMascara(Password))
            {
                await Herramientas.MensajeInfomativoAsync("La contraseña debe tener al menos 6 caracteres, al menos 1 número y una letra mayúscula");
                return;
            }

            // Encriptación de la contraseña ingresada
            string passwordEncriptada = Herramientas.encriptarContraseña(Password);

            // Obtención del usuario desde el repositorio
            usuarioEncontrado = App.UsuarioRepo.GetItem(u => u.Email == Email && u.Password == passwordEncriptada);

            if (usuarioEncontrado != null)
            {
                // Pasamos a la siguiente ventana, eliminamos la ventana de navegación
                App.Current.MainPage.Navigation.PushAsync(new PPrincipalView());
                App.Current.MainPage.Navigation.RemovePage(App.Current.MainPage.Navigation.NavigationStack[0]);
            }
            else
            {
                // Verificación de si el correo electrónico ya está en uso
                if (Herramientas.CorreoElectronicoEnUso(Email))
                {
                    await Herramientas.MensajeInfomativoAsync("El correo electrónico ya está en uso.");
                    ClearFields();
                }
                else
                {
                    // Confirmación para registrar un nuevo usuario
                    bool res = await Herramientas.MensajeConfirmacion("info", "El usuario no existe, ¿desea registrarse?");
                    if (res)
                    {
                        // Creación y guardado del nuevo usuario
                        var usuario = new Usuario
                        {
                            Email = Email,
                            Password = Herramientas.encriptarContraseña(Password), // Encriptar la contraseña antes de guardarla
                            EsDelegado = false
                        };
                        App.UsuarioRepo.SaveItem(usuario); // Guarda el usuario en el repositorio
                        App.Current.MainPage.Navigation.PushAsync(new PPrincipalView());
                        App.Current.MainPage.Navigation.RemovePage(App.Current.MainPage.Navigation.NavigationStack[0]);
                    }
                    else
                    {
                        ClearFields();
                    }
                }
            }
        }

        /// <summary>
        /// Método para la notificación de cambios en las propiedades
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Método para insertar usuarios falsos, solo para pruebas.
        /// </summary>
        public void agregarUsuariosFake()
        {
            List<Usuario> listaUsuariosFake = new List<Usuario>
            {
                new Usuario
                {
                    Email = "a@a.com",
                    Password = Herramientas.encriptarContraseña("1234Abc"),
                    EsDelegado = true
                },
                new Usuario
                {
                    Email = "b@b.com",
                    Password = Herramientas.encriptarContraseña("1234Abc"),
                    EsDelegado = false
                },
                new Usuario
                {
                    Email = "c@c.com",
                    Password = Herramientas.encriptarContraseña("1234Abc"),
                    EsDelegado = false
                },
                new Usuario
                {
                    Email = "d@d.com",
                    Password = Herramientas.encriptarContraseña("1234Abc"),
                    EsDelegado = false
                },
                new Usuario
                {
                    Email = "e@e.com",
                    Password = Herramientas.encriptarContraseña("1234Abc"),
                    EsDelegado = false
                },
                new Usuario
                {
                    Email = "f@f.com",
                    Password = Herramientas.encriptarContraseña("1234Abc"),
                    EsDelegado = false
                },
            };
            foreach (Usuario usu in listaUsuariosFake)
            {
                App.UsuarioRepo.SaveItemCascade(usu);
            }
        }
    }
}












