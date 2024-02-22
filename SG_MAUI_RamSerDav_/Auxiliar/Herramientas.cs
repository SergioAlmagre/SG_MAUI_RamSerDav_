using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SG_MAUI_RamSerDav_.Auxiliar
{
    class Herramientas
    {
        public Herramientas()
        {

        }

        public static async Task MensajeInfomativoAsync(string mensaje)
        {
            //App.Current.MainPage.DisplayAlert("Información para el usuario", mensaje, "Aceptar");
            var currentPage = Application.Current.MainPage;
            await currentPage.DisplayAlert("Información", mensaje, "OK");
        }

        // Chekea si el correo existe en la bbdd
        public static bool CorreoElectronicoEnUso(string email)
        {
            var usuarioExistente = App.UsuarioRepo.GetItem(u => u.Email == email);
            return usuarioExistente != null;
        }


        public static async Task<bool> MensajeConfirmacion(string titulo, string mensaje)
        {
            var currentPage = Application.Current.MainPage;
            return await currentPage.DisplayAlert(titulo, mensaje, "Aceptar", "Cancelar");
        }

        public static string encriptarContraseña(string password)
        {
            char[] encryptedChars = new char[password.Length];

            for (int i = 0; i < password.Length; i++)
            {

                encryptedChars[i] = (char)(password[i] + 2);
            }

            return new string(encryptedChars);

        }

        public static string desencriptarContraseña(string password)
        {
            char[] decryptedChars = new char[password.Length];

            for (int i = 0; i < password.Length; i++)
            {
                decryptedChars[i] = (char)(password[i] - 2);
            }

            return new string(decryptedChars);
        }


        //expresión regular para validar si el correo electrónico tiene una estructura de correo electrónico clásica
        public static bool validarEmail(string email)
        {
            string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Regex.IsMatch(email, emailPattern);
        }
        // La contraseña debe tener al menos 6 caracteres, al menos 1 número y una letra mayúscula
        public static bool validarPassword(string password)
        {

            string passwordPattern = @"^(?=.*[A-Z])(?=.*\d).{6,}$";
            return Regex.IsMatch(password, passwordPattern);
        }

    }
}