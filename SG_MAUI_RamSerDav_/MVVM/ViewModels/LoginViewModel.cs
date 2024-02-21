using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using SG_MAUI_RamSerDav_.MVVM.Models;

namespace SG_MAUI_RamSerDav_.MVVM.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string username;
        private string password;

        public string Username
        {
            get => username;
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public ICommand ClearCommand { get; }
        public ICommand AcceptCommand { get; }
        public bool AcceptEnabled { get; set; }

        public LoginViewModel()
        {
            ClearCommand = new Command(ClearFields);
            AcceptCommand = new Command(AttemptLogin, CanAttemptLogin);
        }

        private bool CanAttemptLogin()
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private void ClearFields()
        {
            Username = string.Empty;
            Password = string.Empty;
        }

        private void AttemptLogin()
        {
            // Lógica de verificación de sesión
            if (IsUserValid(Username, Password))
            {
                // Iniciar sesión con la cuenta encontrada en sqlite
                // Navigation.PushAsync(new MainPage());
            }
            else
            {
                // Mostrar mensaje de error y limpiar campos
                // En nuestro caso, debería ser crear un nuevo registro
                ClearFields();
            }
            // Pasaremos de página con un registro, ya sea para bien o para mal
        }

        // Validador, busca en sqlite si se encuentra el registro
        private bool IsUserValid(string username, string password)
        {
            // Lógica para verificar el usuario en la base de datos
            return true;
        }

        // Si la propiedad intenta cambiar...
        protected virtual void OnPropertyChanged(string propertyName)
        {
            // Verificar si hay suscriptores registrados para el evento PropertyChanged. Siempre que no sea null, se notifica el cambio
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Si el evento cambia, se notifica
        public event PropertyChangedEventHandler PropertyChanged;

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
                    Password = "1234",
                    EsDelegado = false

                },
                new Usuario
                {
                    Email = "e@e.com",
                    Password = "1234",
                    EsDelegado = false

                },
                new Usuario
                {
                    Email = "f@f.com",
                    Password = "1234",
                    EsDelegado = false
                },
            };
            //App.UsuarioRepo.SaveItemCascade(listaUsuariosFake);
        }// Fin de agregarUsuariosFake
    }

   
}


