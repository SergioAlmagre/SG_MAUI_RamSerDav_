using System.Windows.Input;
using System.ComponentModel;
using SG_MAUI_RamSerDav_.MVVM.Models;
using PropertyChanged;
using SG_MAUI_RamSerDav_.MVVM.Abstractions;
using SG_MAUI_RamSerDav_.Auxiliar;

using System.Text.RegularExpressions;

namespace SG_MAUI_RamSerDav_.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public IBaseRepository<Usuario> usuarioRepository => App.UsuarioRepo;
        public bool TemaOscuroActivado { get; set; }
        public ICommand limpiarCommand { get; set; }
        public ICommand aceptarCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        private string _username;
        public string Username
        { 
            get => _username; 
            set 
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
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

        public LoginViewModel()
        {
            agregarUsuariosFake();
            limpiarCommand = new Command(ClearFields);
            aceptarCommand = new Command(inicioSesion, () => IsAceptarEnabled);
            TemaOscuroActivado = false;

            ExitCommand = new Command(async () =>
            {
                bool confirmacion = await Herramientas.MensajeConfirmacion("info", "Desea salir de la aplicación?");
                if (confirmacion)
                {
                    System.Environment.Exit(0); // Se cierra la aplicación
                }
            });
        }

        public bool IsAceptarEnabled => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);

        private void ClearFields()
        {
            Username = string.Empty;
            Password = string.Empty;
        }

        private async void inicioSesion()
        {
            if (!Herramientas.validarEmail(Username))
            {
                await App.Current.MainPage.DisplayAlert("Error", "El correo electrónico no es válido", "Aceptar");
                return;
            }

            if (!Herramientas.validarPassword(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "La contraseña debe tener al menos 6 caracteres, al menos 1 número y una letra mayúscula", "Aceptar");
                return;
            }

            // Verificar si el correo electrónico ya está en uso
            if (Herramientas.CorreoElectronicoEnUso(Username))
            {
                await Herramientas.MensajeInfomativoAsync("El correo electrónico ya está en uso.");
                return;
            }

            // Encriptar la contraseña ingresada
            string passwordEncriptada = Herramientas.encriptarContraseña(Password);

            var usuarioObtenido = usuarioRepository.GetItem(u => u.Email == Username && u.Password == Password);

            if (usuarioObtenido != null)
            {
                App.Current.MainPage.Navigation.PushAsync(new PPrincipalView());
            }
            else
            {
                bool res = await Herramientas.MensajeConfirmacion("info", "El usuario no existe, ¿desea registrarse?");
                if (res)
                {
                    var usuario = new Usuario
                    {
                        Email = Username,
                        Password = Herramientas.encriptarContraseña(Password), // Encriptar la contraseña antes de guardarla
                        EsDelegado = false
                    };
                    usuarioRepository.SaveItem(usuario);
                    App.Current.MainPage.Navigation.PushAsync(new PPrincipalView());
                }
            }
        }

        // Chequeo de datos
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Inserción de Datos
        public void agregarUsuariosFake()
        {
            List<Usuario> listaUsuariosFake = new List<Usuario>
            {
                new Usuario
                {
                    Email = "a@a.com",
                    Password = "1234Abc",
                    EsDelegado = true
                },
                new Usuario
                {
                    Email = "b@b.com",
                    Password = "1234Abc",
                    EsDelegado = false
                },
                new Usuario
                {
                    Email = "c@c.com",
                    Password = "1234Abc",
                    EsDelegado = false
                },
                new Usuario
                {
                    Email = "d@d.com",
                    Password = "1234Abc",
                    EsDelegado = false
                },
                new Usuario
                {
                    Email = "e@e.com",
                    Password = "1234Abc",
                    EsDelegado = false
                },
                new Usuario
                {
                    Email = "f@f.com",
                    Password = "1234Abc",
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












