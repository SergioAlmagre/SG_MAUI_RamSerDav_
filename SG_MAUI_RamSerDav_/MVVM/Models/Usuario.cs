using SG_MAUI_RamSerDav_.MVVM.Abstractions;

namespace SG_MAUI_RamSerDav_.MVVM.Models
{
    /// <summary>
    /// Modelo llamado Usuario, el cual representa a los estudiantes de la aplicación.
    /// </summary>
    [SQLite.Table("Usuarios")] // Define laa columna como "Usuarios"
    public class Usuario : TableData
    {
        /// <summary>
        /// Correo electrónico del usuario.
        /// </summary>
        [SQLite.Column("Email")] // Define la columna como "Email"
        public string Email { get; set; }

        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        [SQLite.Column("Password")] // Define la columna como "Password"
        public string Password { get; set; }

        /// <summary>
        /// Indica si el usuario es un delegado o no, este metodo es extra.
        /// </summary>
        [SQLite.Column("EsDelegado")] // Define la columna como "EsDelegado"
        public bool EsDelegado { get; set; }
    }
}
