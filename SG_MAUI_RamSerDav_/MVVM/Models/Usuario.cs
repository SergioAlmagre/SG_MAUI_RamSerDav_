using SG_MAUI_RamSerDav_.MVVM.Abstractions;
using System;
using System.IO;

// Objeto Usuario
namespace SG_MAUI_RamSerDav_.MVVM.Models
{
    [SQLite.Table("Usuarios")]
    public class Usuario : TableData
    {
        [SQLite.Column("Login")]
        public string Login { get; set; }

        [SQLite.Column("Password")]
        public string Password { get; set; }
    }
}