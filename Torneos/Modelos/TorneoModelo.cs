using System;

namespace Torneos.Modelos
{
    public class TorneoModelo
    {
        public Guid id { get; set; }
        public string nombre { get; set; }
        public string lugar { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string tipoTorneo { get; set; }
        public string categoria { get; set; }
        public string equipos { get; set; }
        public int nEquipos { get; set; }
    }
}
