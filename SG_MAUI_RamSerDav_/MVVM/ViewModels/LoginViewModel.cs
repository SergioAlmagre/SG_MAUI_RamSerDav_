﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;

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
            // Logica de verificado de Sesion
            if (IsUserValid(Username, Password))
            {
                // Inicio de sesion con la cuenta que se ha encontrado en sqlite
                // Navigation.PushAsync(new MainPage());
            }
            else
            {
                // Mostrar mensaje de error y limpiar campos
                // En nuestro caso deberia ser, crea un nuevo Registro
                ClearFields();
            }
            // Para bien o para mal pasaremos de pagina con un registro 
        }

        // Validador, busca en sqlite si se encuentra el registro
        private bool IsUserValid(string username, string password)
        {
            // Lógica de verificación de usuario en la base de datos
            return true;
        }

        // Si la propiedad intenta cambiar...
        protected virtual void OnPropertyChanged(string propertyName)
        {
            // Verifica si hay suscriptores registrados para el evento PropertyChanged. Siempre que no sea null, se notifica cambio
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Si el evento cambia, se notifica
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
