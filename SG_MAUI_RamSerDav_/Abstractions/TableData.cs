using SQLite;

namespace SG_MAUI_RamSerDav_.MVVM.Abstractions
{
    /// <summary>
    /// Clase base para entidades de tabla.
    /// </summary>
    public class TableData
    {
        /// <summary>
        /// Identificador único de la entidad.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
