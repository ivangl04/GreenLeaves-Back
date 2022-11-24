using System;
using System.Collections.Generic;

namespace GreenLeaves.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Ciudad = new HashSet<Ciudad>();
        }

        public string Iso { get; set; }
        public string Nombre { get; set; }
        public string IsoPais { get; set; }

        public virtual Pais IsoPaisNavigation { get; set; }
        public virtual ICollection<Ciudad> Ciudad { get; set; }
    }
}
