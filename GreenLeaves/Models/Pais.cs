using System;
using System.Collections.Generic;

namespace GreenLeaves.Models
{
    public partial class Pais
    {
        public Pais()
        {
            Estado = new HashSet<Estado>();
        }

        public string Iso { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Estado> Estado { get; set; }
    }
}
