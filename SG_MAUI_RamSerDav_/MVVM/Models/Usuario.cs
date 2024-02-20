using System;
using System.IO;


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