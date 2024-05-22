using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinNet.Modelo
{
    public class Tarea
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
