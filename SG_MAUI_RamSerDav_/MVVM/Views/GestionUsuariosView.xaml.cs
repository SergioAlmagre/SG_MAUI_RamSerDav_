using SG_MAUI_RamSerDav_.MVVM.ViewModels;

namespace SG_MAUI_RamSerDav_.MVVM.Views;

public partial class GestionUsuariosView : ContentPage
{
	public GestionUsuariosView()
	{
		InitializeComponent();
		BindingContext = new GestionUsuariosViewModel();
	}
}