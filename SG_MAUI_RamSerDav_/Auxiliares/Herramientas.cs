using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_MAUI_RamSerDav_.MVVM.ViewModels
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

    }
}
