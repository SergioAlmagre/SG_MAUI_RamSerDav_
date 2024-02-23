using SG_MAUI_RamSerDav_.MVVM.Models;
using SG_MAUI_RamSerDav_.MVVM.ViewModels;

namespace SG_MAUI_RamSerDav_.MVVM.Views;

/// <summary>
/// ViewModel para Gestion de Usuarios.
/// </summary>
public partial class GestionUsuariosView : ContentPage
{
    // ViewModel para la vista de gestión de usuarios
    public GestionUsuariosViewModel gestUsuariosVM = new GestionUsuariosViewModel();

    /// <summary>
    /// Constructor 
    public GestionUsuariosView()
    {
        InitializeComponent();
        BindingContext = gestUsuariosVM; // Establece el contexto de enlace con el ViewModel
    }

    /// <summary>
    /// Manejador de eventos para el cambio de estado del CheckBox.
    /// </summary>
    private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        // Obtiene el DataContext del CheckBox, es decir, Usuario por ende los Alumnos
        if (sender is CheckBox checkBox && checkBox.BindingContext is Usuario usu)
        {
            gestUsuariosVM.UsuarioActual = usu; // Establece el usuario actual en el ViewModel
            gestUsuariosVM.UsuarioActual.EsDelegado = e.Value; // Actualiza el estado del usuario
            App.UsuarioRepo.SaveItemCascade(gestUsuariosVM.UsuarioActual); // Guarda los cambios en bbdd
            gestUsuariosVM.limpiarCampos(); // Limpia los campos
        }  
    }
}
