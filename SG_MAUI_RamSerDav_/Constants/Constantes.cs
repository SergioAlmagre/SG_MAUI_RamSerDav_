using SQLite;

namespace SG_MAUI_RamSerDav_.MVVM.Constants
{
    /// <summary>
    /// Clase que contiene constantes utilizadas en la aplicación.
    /// </summary>
    public static class Constantes
    {
        private const string DBFileName = "ramserdav.db3"; // Nombre del archivo bbdd

        /// <summary>
        /// Flags para la apertura de la base de datos SQLite.
        /// </summary>
        public const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.FullMutex;

        /// <summary>
        /// Ruta completa de la base de datos.
        /// </summary>
        public static string DatabasePath
        {
            get
            {
                // Sincroniza el directorio de la aplicacion con el de nombre de la bbdd
                return Path.Combine(FileSystem.AppDataDirectory, DBFileName);
            }
        }
    }
}