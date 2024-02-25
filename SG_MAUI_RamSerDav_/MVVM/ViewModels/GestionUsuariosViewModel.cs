using PropertyChanged;
using SG_MAUI_RamSerDav_.Auxiliar;
using SG_MAUI_RamSerDav_.MVVM.Models;
using SG_MAUI_RamSerDav_.MVVM.Views;
using System.Windows.Input;


namespace SG_MAUI_RamSerDav_.MVVM.ViewModels
{
    /// <summary>
    /// ViewModel para la vista de gestión de usuarios.
    /// </summary>
    [AddINotifyPropertyChangedInterface] // Agrega automáticamente la implementación de repintes
    public class GestionUsuariosViewModel 
    {
        /// <summary>
        /// Lista de usuarios.
        /// </summary>
        public List<Usuario> ListaUsuarios { get; set; } = new List<Usuario>();

        /// <summary>
        /// Usuario actual seleccionado.
        /// </summary>
        public Usuario UsuarioActual { get; set; } = new Usuario();

        /// <summary>
        /// Comando para navegar a la vista de gestión de usuarios.
        /// </summary>
        public ICommand btnIrGestionUsuariosCommand { get; set; }

        /// <summary>
        /// Comando para eliminar un usuario.
        /// </summary>
        public ICommand EliminarCommand { get; set; }

        /// <summary>
        /// Comando para guardar un usuario.
        /// </summary>
        public ICommand GuardarCommand { get; set; }

        /// <summary>
        /// Comando para volver a la vista anterior.
        /// </summary>
        public ICommand btnVolverCommand { get; set; }

        /// <summary>
        /// Comando para limpiar los campos.
        /// </summary>
        public ICommand LimpiaCommand { get; set; }


        /// <summary>
        /// Constructor.
        /// </summary>
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
                    await Herramientas.MensajeInfomativoAsync("No se ha seleccionado un usuario");
                    return;
                }
                else
                {
                    bool confirmacion = await Herramientas.MensajeConfirmacion("info", "Desea eliminar el usuario?");
                    if (confirmacion)
                    {
                        App.UsuarioRepo.DeleteItem(UsuarioActual);
                        if(App.UsuarioRepo.StatusMessage == null)
                        {
                          await  Herramientas.MensajeInfomativoAsync("Usuario eliminado correctamente");
                            refrescarLista();
                            limpiarCampos();
                        }
                        else
                        {
                            await Herramientas.MensajeInfomativoAsync("Ha ocurrido un error desconocido durante la operación, vuelva a intentarlo");
                            App.UsuarioRepo.StatusMessage = null;
                        }
                    }
                }   
            });

            LimpiaCommand = new Command(() =>
            {
                limpiarCampos();
            });


            GuardarCommand = new Command(async() =>
            {
                if(camposVacios()) //Verificar si los campos están vacíos
                {
                    await Herramientas.MensajeInfomativoAsync("Existen campos vacíos o usuario sin seleccionar");
                }
                else
                {

                    if(Herramientas.emailCumpleMascara(UsuarioActual.Email) == false) // Verificar si el correo electrónico es válido
                    {
                        await Herramientas.MensajeInfomativoAsync("El correo electrónico no es válido.");
                        return;
                    }
                    else if(Herramientas.passwordCumpleMascara(UsuarioActual.Password) == false) // Verificar si la contraseña es válida
                    {
                        await Herramientas.MensajeInfomativoAsync("La contraseña debe tener al menos 6 caracteres, al menos 1 número y una letra mayúscula");
                        return;
                    }
                    else
                    {
                        UsuarioActual.Password = Herramientas.encriptarContraseña(UsuarioActual.Password);
                    }


                    // Verificar si el correo electrónico ya está en uso
                    if (Herramientas.CorreoElectronicoEnUso(UsuarioActual.Email)) // Verificar si el correo electrónico ya está en uso
                    {
                        await Herramientas.MensajeInfomativoAsync("El correo electrónico ya está en uso.");
                    }
                    else 
                    {   
                        App.UsuarioRepo.SaveItemCascade(UsuarioActual); // Guardar el usuario
                        if(App.UsuarioRepo.StatusMessage == null) // Verificar si el usuario se guardó correctamente
                        {
                            await Herramientas.MensajeInfomativoAsync("Usuario guardado correctamente");
                            refrescarLista(); 
                            limpiarCampos();
                        }
                        else
                        {
                            await Herramientas.MensajeInfomativoAsync("Ha ocurrido un error desconocido durante la operación, vuelva a intentarlo");
                            App.UsuarioRepo.StatusMessage = null;
                        }
                    }
                }
            });

        }

        /// <summary>
        /// Verifica si los campos de email y contraseña están vacíos.
        /// </summary>
        /// <returns>True si los campos están vacíos, de lo contrario False.</returns>
        public bool camposVacios()
        {
            return string.IsNullOrWhiteSpace(UsuarioActual.Email) || string.IsNullOrWhiteSpace(UsuarioActual.Password);
        }

        /// <summary>
        /// Limpia los campos del usuario actual.
        /// </summary>
        public void limpiarCampos()
        {
            UsuarioActual = new Usuario();
        }

        /// <summary>
        /// Refresca la lista de usuarios.
        /// </summary>
        public void refrescarLista()
        {
            ListaUsuarios = App.UsuarioRepo.GetItems();
        }
    }
}
