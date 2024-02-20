using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_MAUI_RamSerDav_.MVVM.ViewModels
{
    class Mensajes
    {
        public Mensajes()
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

    }
}
