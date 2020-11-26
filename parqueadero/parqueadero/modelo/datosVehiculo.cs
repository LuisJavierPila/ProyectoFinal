using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace parqueadero.modelo
{
    public class datosVehiculo
    {
        [PrimaryKey, AutoIncrement]

        public int idAuto { get; set; }
        [MaxLength(255)]

        public string Placas { get; set; }
        [MaxLength(255)]

        public string Marca { get; set; }
        [MaxLength(255)]

        public int Hora { get; set; }
        [MaxLength(255)]

        public string Descripcion { get; set; }

     
    }
}
