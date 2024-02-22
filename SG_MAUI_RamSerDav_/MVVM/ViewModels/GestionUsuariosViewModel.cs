using PropertyChanged;
using SG_MAUI_RamSerDav_.Auxiliar;
using SG_MAUI_RamSerDav_.MVVM.Models;
using SG_MAUI_RamSerDav_.MVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public ICommand EliminarCommand { get; set; }
        public ICommand GuardarCommand { get; set; }
        public ICommand btnVolverCommand { get; set; }
        public ICommand LimpiaCommand { get; set; }


        //private string _email;
        //public string Email
        //{
        //    get => _email;
        //    set
        //    {
        //        _email = value;
        //        OnPropertyChanged(nameof(Email));
        //        OnPropertyChanged(nameof(IsAceptarEnabled));
        //    }
        //}

        //private string _password;
        //public string Password
        //{
        //    get => _password;
        //    set
        //    {
        //        _password = value;
        //        OnPropertyChanged(nameof(Password));
        //        OnPropertyChanged(nameof(IsAceptarEnabled));
        //    }
        //}

        public GestionUsuariosViewModel()
        {
            refrescarLista();
            btnIrGestionUsuariosCommand = new Command(() =>
            {
                App.Current.MainPage.Navigation.PushAsync(new GestionUsuariosView());
            });

            btnVolverCommand = new Command(() =>
            {
                if (Application.Current.MainPage.Navigation.NavigationStack.Count > 1)
                {
                    Application.Current.MainPage.Navigation.PopAsync();
                }
            });




            EliminarCommand = new Command(async () =>
            {
                if (UsuarioActual.Id == 0)
                {
                    Herramientas.MensajeInfomativoAsync("No se ha seleccionado un usuario");
                    return;
                }
                else
                {
                    bool confirmacion = await Herramientas.MensajeConfirmacion("info", "Desea eliminar el usuario?");
                    if (confirmacion)
                    {
                        App.UsuarioRepo.DeleteItem(UsuarioActual);
                        refrescarLista();

                    }

                }

                
               
            });

            LimpiaCommand = new Command(() =>
            {
                limpiarCampos();
            });

            GuardarCommand = new Command(() =>
            {
                if(camposVacios())
                {
                    Herramientas.MensajeInfomativoAsync("Existen campos vacíos o usuario sin seleccionar");
                }
                else
                {
                    // Verificar si el correo electrónico ya está en uso
                    if (Herramientas.CorreoElectronicoEnUso(UsuarioActual.Email))
                    {
                        Herramientas.MensajeInfomativoAsync("El correo electrónico ya está en uso.");
                    }
                    else 
                    {
                        Herramientas.MensajeInfomativoAsync("Usuario guardado correctamente");
                        App.UsuarioRepo.SaveItemCascade(UsuarioActual);
                        refrescarLista();
                        limpiarCampos();
                    }
                    
                }
            });

        }

      



        public bool camposVacios()
        {
            if(string.IsNullOrWhiteSpace(UsuarioActual.Email) || string.IsNullOrWhiteSpace(UsuarioActual.Password))
            {
                return true;
            }
            else
            {
                return false;
            }
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
