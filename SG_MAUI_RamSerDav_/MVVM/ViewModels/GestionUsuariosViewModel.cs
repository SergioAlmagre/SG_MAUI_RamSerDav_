using PropertyChanged;
using SG_MAUI_RamSerDav_.Auxiliar;
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
        public ICommand EliminarCommand { get; set; }
        public ICommand GuardarCommand { get; set; }
        public ICommand btnVolverCommand { get; set; }
        public ICommand LimpiaCommand { get; set; }

        public GestionUsuariosViewModel()
        {
            refrescarLista();

            btnIrGestionUsuariosCommand = new Command(() =>
            {
                App.Current.MainPage.Navigation.PushAsync(new GestionUsuariosView());
            });

            btnVolverCommand = new Command(() =>
            {
                App.Current.MainPage.Navigation.PopAsync();
            });



            EliminarCommand = new Command(async () =>
            {
                bool confirmacion = await Herramientas.MensajeConfirmacion("info", "Desea eliminar el usuario?");
                if (confirmacion)
                {
                    App.UsuarioRepo.DeleteItem(UsuarioActual); // Eliminar el usuario
                    refrescarLista();

                }
               
            });

            LimpiaCommand = new Command(() =>
            {
                limpiarCampos();
            });


            GuardarCommand = new Command(() =>
            {
                if(camposVacios()) //Verificar si los campos están vacíos
                {
                    Herramientas.MensajeInfomativoAsync("Existen campos vacíos o usuario sin seleccionar");
                }
                else
                {

                    if(Herramientas.validarEmail(UsuarioActual.Email) == false) // Verificar si el correo electrónico es válido
                    {
                        Herramientas.MensajeInfomativoAsync("El correo electrónico no es válido.");
                        return;
                    }
                    else if(Herramientas.validarPassword(UsuarioActual.Password) == false) // Verificar si la contraseña es válida
                    {
                        Herramientas.MensajeInfomativoAsync("La contraseña debe tener al menos 6 caracteres, al menos 1 número y una letra mayúscula");
                        return;
                    }
                    else
                    {
                        UsuarioActual.Password = Herramientas.encriptarContraseña(UsuarioActual.Password);
                    }


                    // Verificar si el correo electrónico ya está en uso
                    if (Herramientas.CorreoElectronicoEnUso(UsuarioActual.Email)) // Verificar si el correo electrónico ya está en uso
                    {
                        Herramientas.MensajeInfomativoAsync("El correo electrónico ya está en uso.");
                    }
                    else 
                    {
                        Herramientas.MensajeInfomativoAsync("Usuario guardado correctamente");
                        App.UsuarioRepo.SaveItemCascade(UsuarioActual); // Guardar el usuario
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
