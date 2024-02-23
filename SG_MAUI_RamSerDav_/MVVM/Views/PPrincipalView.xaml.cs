namespace SG_MAUI_RamSerDav_.MVVM.ViewModels;

/// <summary>
/// Clase View para la vista principal.
/// </summary>
public partial class PPrincipalView : ContentPage
{
    /// <summary>
    /// Constructor de la clase PPrincipalView.
    /// </summary>
    public PPrincipalView()
    {
        InitializeComponent();
        BindingContext = new PPrincipalViewModel(); // Establece el contexto de enlace con una nueva instancia del ViewModel asociado
        NavigationPage.SetHasNavigationBar(this, false); // Oculta la barra de navegación en esta pagina, Por si venimos de la anterior
    }
}