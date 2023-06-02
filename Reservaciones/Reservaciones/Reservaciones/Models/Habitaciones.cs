using System;
using System.Collections.Generic;
using System.Text;

namespace Reservaciones.Models
{
    [Serializable]
    public class Habitaciones
    {

        public string nombre { get; set; }

        public int cantidadHuespedes { get; set; }

        public List<Reservacion> reservacion { get; } = new List<Reservacion>();


        // Regla de Negocio
        public bool agregarReservacion(Reservacion r) {


            if (r.cantidadPersonas <= cantidadHuespedes) { 
            
                reservacion.Add(r);
                return true;
            }
            

            return false;
        }

        public override string ToString()
        {
            return $" {nombre} - {cantidadHuespedes} ";
        }

    }
}
