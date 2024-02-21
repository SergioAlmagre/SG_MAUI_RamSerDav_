
using SG_MAUI_RamSerDav_.MVVM.ViewModels;

namespace SG_MAUI_RamSerDav_.MVVM.Views;

public partial class GestionUsuariosView : ContentPage
{
	private GestionUsuariosViewModel gestionUsuariosViewModel = new GestionUsuariosViewModel();
	public GestionUsuariosView()
	{
		InitializeComponent();
		BindingContext = gestionUsuariosViewModel;
	}

 //   private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
 //   {
	//	gestionUsuariosViewModel.UsuarioActual.EsDelegado = gestionUsuariosViewModel.UsuarioActual.EsDelegado ? false : true;
	//	//gestionUsuariosViewModel.checkbox_chaged();
	//}


}