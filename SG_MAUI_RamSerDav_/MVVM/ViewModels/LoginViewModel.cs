using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using SG_MAUI_RamSerDav_.MVVM.Models;
using PropertyChanged;
using SG_MAUI_RamSerDav_.MVVM.Views;
using SG_MAUI_RamSerDav_.MVVM.Abstractions;

namespace SG_MAUI_RamSerDav_.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel
    {
        public INavigation navigation; // Interfaz de navegacion para cambiar de página
        public IBaseRepository<Usuario> usuarioRepository => App.UsuarioRepo; // Obtener el repositorio de usuarios desde App

        public Usuario _usuarioActual = new Usuario();
        public Usuario usuarioActual
        {
            get => _usuarioActual;
            set
            {
                _usuarioActual = value;
                ((Command)aceptarCommand).ChangeCanExecute();
            }
        }

        public ICommand limpiarCommand { get; set; } // Evento limpiar los campos
        public ICommand aceptarCommand { get; set; } // Evento iniciar sesión

        // Constructor de la clase
        public LoginViewModel()
        {
            //agregarUsuariosFake();
            limpiarCommand = new Command(ClearFields); // Asigna el metodo ClearFields al comando ClearCommand
            aceptarCommand = new Command(inicioSesion, puedeHacerLogin); // Asigna los métodos AttemptLogin y CanAttemptLogin al comando AcceptCommand
        }

        // Metodo que indica si se puede intentar iniciar sesion
        private bool puedeHacerLogin()
        {
            return !string.IsNullOrWhiteSpace(usuarioActual.Email) && !string.IsNullOrWhiteSpace(usuarioActual.Password);
        }

        // Evento para limpiar los campos
        private void ClearFields()
        {
            usuarioActual = new Usuario();
        }

        // Evento de iniciar sesión
        private async void inicioSesion()
        {
            // Verificar si el usuario existe en la base de datos
            var usuarioObetenido = usuarioRepository.GetItem(u => u.Email == usuarioActual.Email && u.Password == usuarioActual.Password);

            if (usuarioObetenido != null)
            {
                // Si el usuario existe, navega a la pagina de gestión de usuarios
                App.Current.MainPage.Navigation.PushAsync(new GestionUsuariosView());
            }
            else
            {
                bool res = await Auxiliar.Herramientas.MensajeConfirmacion("info", "El usuario no existe, ¿desea registrarse?");
                if (res == true)
                {
                    // Si el usuario no existe, crea un nuevo registro de usuario
                    var usuario = new Usuario
                    {
                        Email = usuarioActual.Email,
                        Password = usuarioActual.Password,
                        EsDelegado = false // Por defecto, el campo EsDelegado es falso
                    };
                    usuarioRepository.SaveItem(usuario); // Guarda el nuevo registro de usuario en la bbdd
                    App.Current.MainPage.Navigation.PushAsync(new GestionUsuariosView());
                }
            }
        }

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







