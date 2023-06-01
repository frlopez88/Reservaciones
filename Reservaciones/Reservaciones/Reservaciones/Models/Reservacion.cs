using System;
using System.Collections.Generic;
using System.Text;

namespace Reservaciones.Models
{
    public class Reservacion
    {

        public DateTime fechaReservacion { get; set; }

        public int cantidadPersonas { get; set; }

        public string nombreResponsable { get; set; }

        public string telefono { get; set; }

        public string correo { get; set; }


    }
}
