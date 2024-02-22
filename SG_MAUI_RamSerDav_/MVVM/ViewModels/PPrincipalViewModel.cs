using SG_MAUI_RamSerDav_.Auxiliar;
using SG_MAUI_RamSerDav_.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SG_MAUI_RamSerDav_.MVVM.ViewModels
{

    public class PPrincipalViewModel
    {

    public ICommand btnIrGestionUsuariosCommand { get; set; }
    public ICommand btnSalirCommand { get; set; }

        public PPrincipalViewModel()
        {

            btnIrGestionUsuariosCommand = new Command(() =>
            {
                App.Current.MainPage.Navigation.PushAsync(new GestionUsuariosView());
            });



            btnSalirCommand = new Command( async () =>
            {

                bool confirmacion = await Herramientas.MensajeConfirmacion("info", "Desea salir de la aplicación?");
                if (confirmacion)
                {
                    System.Environment.Exit(0); 
                }
            });

        }
      
    }
}
