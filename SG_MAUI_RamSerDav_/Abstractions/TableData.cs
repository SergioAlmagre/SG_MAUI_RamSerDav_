﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Cambio DaAM
//instalacion de nuggets
//Install-Package
namespace SG_MAUI_RamSerDav_.MVVM.Abstractions
{
    public class TableData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
