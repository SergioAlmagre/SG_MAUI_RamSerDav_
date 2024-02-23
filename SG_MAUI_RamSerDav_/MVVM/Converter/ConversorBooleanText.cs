using System.Globalization;

namespace SG_MAUI_RamSerDav_.MVVM.Converter
{
    /// <summary>
    /// Clase que convierte un valor booleano en un texto especifico.
    /// </summary>
    public class ConversorBooleanText : IValueConverter
    {
        /// <summary>
        /// Convierte un valor booleano en un texto.
        /// </summary>
        /// <param name="value">Valor booleano a convertir.</param>
        /// <returns>Texto "Delegado" si el valor es verdadero, "Normal" si el valor es falso.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return "Delegado";
            }
            else
            {
                return "Normal";
            }
        }

        /// <summary>
        /// Convierte un texto de vuelta a un valor booleano.
        /// </summary>
        /// <param name="value">Texto a convertir de vuelta a booleano.</param>
        /// <returns>Valor bacio.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
