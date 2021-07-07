using System;
using System.Collections.Generic;
using System.Text;

namespace Torneos.Modelos
{
    public class EquipoModelo
    {
        public Guid id { get; set; }
        public string nombre { get; set; }
        public int nJugadores { get; set; }
        public string tipo { get; set; }
        public string categoria { get; set; }
        public string localidad { get; set; }
    }
}
