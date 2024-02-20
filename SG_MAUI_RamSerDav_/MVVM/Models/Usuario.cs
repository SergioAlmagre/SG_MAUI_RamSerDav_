using System;
using System.IO;

// Objeto Usuario
namespace SQLitePrueba.MVVM.Models
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