using SG_MAUI_RamSerDav_.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SG_MAUI_RamSerDav_.MVVM.ViewModels
{

    internal class PPrincipalViewModel
    {

    public ICommand btnIrGestionUsuariosCommand { get; set; }
    public ICommand btnSalirCommand { get; set; }

        public PPrincipalViewModel()
        {

            btnIrGestionUsuariosCommand = new Command(() =>
            {
                App.Current.MainPage.Navigation.PushAsync(new GestionUsuariosView());
            });



            btnSalirCommand = new Command(() =>
            {
            //Vuelve a la página del login pero habría que pensar si se cierra la aplicación o no
            App.Current.MainPage.Navigation.PopAsync();
            });

        }
      
    }
}
