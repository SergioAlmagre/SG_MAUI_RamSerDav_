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



            btnSalirCommand = new Command(() =>
            {
            
                //App.Current.MainPage.Navigation.PopAsync();//Vuelve a la página del login
                App.Current.Quit(); //Cierra la aplicación
            });

        }
      
    }
}
