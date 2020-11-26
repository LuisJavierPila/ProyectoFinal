using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace parqueadero.modelo
{
    public class datosUsuario
    {

        [PrimaryKey, AutoIncrement]
        public int IdUsuario { get; set; }
        public string usuario { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public string telefono { get; set; }


    }
}
