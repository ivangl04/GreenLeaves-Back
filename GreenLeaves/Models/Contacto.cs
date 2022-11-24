using System;
using System.Collections.Generic;

namespace GreenLeaves.Models
{
    public partial class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha { get; set; }
        public string IsoCiudad { get; set; }

        public virtual Ciudad IsoCiudadNavigation { get; set; }
    }
}
