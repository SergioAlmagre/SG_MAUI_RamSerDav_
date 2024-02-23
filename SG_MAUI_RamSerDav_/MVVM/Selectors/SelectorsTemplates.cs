using PropertyChanged;
using SG_MAUI_RamSerDav_.MVVM.Models;

namespace SG_MAUI_RamSerDav_.MVVM.Selectors
{
    /// <summary>
    /// Selector de plantillas que elige una plantilla de datos basada en la propiedad "EsDelegado" del objeto Usuario.
    /// </summary>
    [AddINotifyPropertyChangedInterface] // Notificara cambios en las propiedades
    public class SelectorsTemplates : DataTemplateSelector
    {
        /// <summary>
        /// Método que selecciona la plantilla de datos adecuada según el objeto de entrada.
        /// </summary>
        /// <param name="item">Objeto de entrada.</param>
        /// <param name="container">Contenedor de datos.</param>
        /// <returns>La plantilla de datos seleccionada.</returns>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            // Convierte el objeto de entrada en un objeto Usuario
            var usu = (Usuario)item;

            // Comprueba si el usuario es un delegado
            if (usu.EsDelegado)
            {
                // Obtiene la plantilla de datos para los delegados del recurso "vistaDelegado"
                Application
                    .Current
                    .Resources
                    .TryGetValue("vistaDelegado", out var estiloJefe);
                return (DataTemplate)estiloJefe;
            }
            else
            {
                // Obtiene la plantilla de datos para usuarios normales del recurso "vistaNormal"
                Application
                   .Current
                   .Resources
                   .TryGetValue("vistaNormal", out var estiloNormal);
                return (DataTemplate)estiloNormal;
            }
        }
    }
}

