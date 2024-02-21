using PropertyChanged;
using SG_MAUI_RamSerDav_.MVVM.Models;
using SG_MAUI_RamSerDav_.MVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
                //Vuelve a la página del login
                App.Current.MainPage.Navigation.PopAsync();
                // Si quieres salir de la aplicación completamente
                // App.Current.Quit();
            });


            EliminarCommand = new Command(async () =>
            {
                bool resultado = await Auxiliar.Herramientas.MensajeConfirmacion("Confirmación", "¿Estás seguro?");
                if (resultado)
                { 
                    App.UsuarioRepo.DeleteItem(UsuarioActual);
                    refrescarLista();
                }       
            });


            GuardarCommand = new Command(() =>
            {
                if (camposCompletos())
                {
                    App.UsuarioRepo.SaveItemCascade(UsuarioActual);
                    refrescarLista();
                    limpiarCampos();
                }
                else
                {
                    Auxiliar.Herramientas.MensajeInfomativo("Faltan campos por completar \n o usuario por seleccionar");
                }
            });

        }

        //public void checkbox_chaged()
        //{
        //    UsuarioActual.EsDelegado = !UsuarioActual.EsDelegado;
        //}

        private bool camposCompletos()
        {
            return !string.IsNullOrWhiteSpace(UsuarioActual.Email) && !string.IsNullOrWhiteSpace(UsuarioActual.Password);
        }


        public void limpiarCampos()
        {
            UsuarioActual = new Usuario();
        }

        public void refrescarLista()
        {
            ListaUsuarios = App.UsuarioRepo.GetItems();
        }

    }
}
