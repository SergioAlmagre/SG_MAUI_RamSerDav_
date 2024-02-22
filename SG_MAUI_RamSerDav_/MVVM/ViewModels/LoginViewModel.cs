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
using SG_MAUI_RamSerDav_.Auxiliar;

namespace SG_MAUI_RamSerDav_.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IBaseRepository<Usuario> usuarioRepository => App.UsuarioRepo;

        public bool TemaOscuroActivado { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand limpiarCommand { get; set; }
        public ICommand aceptarCommand { get; set; }

        public LoginViewModel()
        {
            agregarUsuariosFake();
            limpiarCommand = new Command(ClearFields);
            aceptarCommand = new Command(inicioSesion, () => IsAceptarEnabled);
            TemaOscuroActivado = false;
        }

        public bool IsAceptarEnabled => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);

        private void ClearFields()
        {
            Username = string.Empty;
            Password = string.Empty;
        }

        private async void inicioSesion()
        {
            var usuarioObtenido = usuarioRepository.GetItem(u => u.Email == Username && u.Password == Password);

            if (usuarioObtenido != null)
            {
                App.Current.MainPage.Navigation.PushAsync(new PPrincipalView());
            }
            else
            {
                bool res = await Auxiliar.Herramientas.MensajeConfirmacion("info", "El usuario no existe, ¿desea registrarse?");
                if (res)
                {
                    var usuario = new Usuario
                    {
                        Email = Username,
                        Password = Password,
                        EsDelegado = false
                    };
                    usuarioRepository.SaveItem(usuario);
                    App.Current.MainPage.Navigation.PushAsync(new PPrincipalView());
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










