using System;
using System.Collections.Generic;

namespace GreenLeaves.Models
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Contacto = new HashSet<Contacto>();
        }

        public string Iso { get; set; }
        public string Nombre { get; set; }
        public string IsoEstado { get; set; }

        public virtual Estado IsoEstadoNavigation { get; set; }
        public virtual ICollection<Contacto> Contacto { get; set; }
    }
}
