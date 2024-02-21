using PropertyChanged;
using SG_MAUI_RamSerDav_.MVVM.Models;
using SG_MAUI_RamSerDav_.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SG_MAUI_RamSerDav_.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class GestionUsuariosViewModel
    {
       public List<Usuario> ListaUsuarios { get; set; } = new List<Usuario>();
        public Usuario UsuarioActual { get; set; } = new Usuario();
        public ICommand btnIrGestionUsuariosCommand { get; set; }
        public ICommand btnSalirCommand { get; set; }
        public ICommand EliminarCommand { get; set; }
        public ICommand GuardarCommand { get; set; }

        public GestionUsuariosViewModel()
        {
            refrescarLista();
            btnIrGestionUsuariosCommand = new Command(() =>
            {
                App.Current.MainPage.Navigation.PushAsync(new GestionUsuariosView());
            });



            btnSalirCommand = new Command(() =>
            {
                //Vuelve a la página del login pero habría que pensar si se cierra la aplicación o no
                App.Current.MainPage.Navigation.PopAsync();
            });

            EliminarCommand = new Command(() =>
            {
                App.UsuarioRepo.DeleteItem(UsuarioActual);
                refrescarLista();
            });

            GuardarCommand = new Command(() =>
            {
                App.UsuarioRepo.SaveItem(UsuarioActual);
                Console.WriteLine(App.UsuarioRepo.StatusMessage);
                refrescarLista();
                nuevoUsuario();
            });

        }

        public void nuevoUsuario()
        {
            UsuarioActual = new Usuario();
        }

        public void refrescarLista()
        {
            ListaUsuarios = App.UsuarioRepo.GetItems();
        }

    }
}
