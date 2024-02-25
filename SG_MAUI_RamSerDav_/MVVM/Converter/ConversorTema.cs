using System.Globalization;

namespace SG_MAUI_RamSerDav_.MVVM.Converter
{
    /// <summary>
    /// Clase que convierte un valor booleano en un nombre de tema Claro o Oscuro.
    /// </summary>
    public class ConversorTema : IValueConverter
    {
        /// <summary>
        /// Convierte un valor booleano en un nombre de tema.
        /// </summary>
        /// <param name="value">Valor booleano a convertir.</param>
        /// <returns>Nombre del tema: "Light" si el valor es verdadero, "Dark" si el valor es falso.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return "Light";
            }
            else
            {
                return "Dark";
            }
        }

        /// <summary>
        /// Convierte un nombre de tema de vuelta a un valor booleano.
        /// </summary>
        /// <param name="value">Nombre del tema a convertir de vuelta a booleano.</param>
        /// <returns>Valor bacio.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
