using SG_MAUI_RamSerDav_.MVVM.Models;
using SG_MAUI_RamSerDav_.MVVM.ViewModels;

namespace SG_MAUI_RamSerDav_.MVVM.Views;

public partial class GestionUsuariosView : ContentPage
{
	public GestionUsuariosViewModel gestUsuariosVM = new GestionUsuariosViewModel();
	public GestionUsuariosView()
	{
		InitializeComponent();
		BindingContext = gestUsuariosVM;
	}

    private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        // Obtiene el DataContext del CheckBox (que es el objeto Usuario en este caso)
        if (sender is CheckBox checkBox && checkBox.BindingContext is Usuario usu)
        {
            gestUsuariosVM.UsuarioActual = usu;
            gestUsuariosVM.UsuarioActual.EsDelegado = e.Value;
            App.UsuarioRepo.SaveItemCascade(gestUsuariosVM.UsuarioActual);
            gestUsuariosVM.limpiarCampos();
        }  
    }
}