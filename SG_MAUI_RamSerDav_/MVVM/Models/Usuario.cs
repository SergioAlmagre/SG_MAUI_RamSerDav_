using SG_MAUI_RamSerDav_.MVVM.Abstractions;
using System;
using System.IO;

// Objeto Usuario / Alumno
namespace SG_MAUI_RamSerDav_.MVVM.Models
{
    [SQLite.Table("Usuarios")]
    public class Usuario : TableData
    {
        [SQLite.Column("Email")]
        public string Email { get; set; }

        [SQLite.Column("Password")]
        public string Password { get; set; }

        [SQLite.Column("EsDelegado")]
        public bool EsDelegado { get; set; }
    }
}
