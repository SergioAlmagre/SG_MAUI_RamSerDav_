namespace SG_MAUI_RamSerDav_.MVVM.ViewModels;

public partial class PPrincipalView : ContentPage
{
	public PPrincipalView()
	{
		InitializeComponent();
		BindingContext = new PPrincipalViewModel();
		NavigationPage.SetHasNavigationBar(this, false);
	}
}