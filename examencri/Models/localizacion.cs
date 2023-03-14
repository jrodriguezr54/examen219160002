using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace examencri.Models
{
    public class localizacion
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public Double latitud { get; set; }

        public Double longitud { get; set; }
        [MaxLength(200)]
        public string descripcionlarga { get; set; }
        [MaxLength(60)]
        public string descripcioncorta { get; set; }
        
    }
}


