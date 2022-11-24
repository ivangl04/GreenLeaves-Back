using GreenLeaves.Interfaces;
using GreenLeaves.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenLeaves.Implementations
{
    public class CiudadRepository : ICiudad
    {
        private GreenLeavesContext context = null;

        public string[] ObtenerCiudad(string sTextCity)
        {
            IQueryable<string> oListCiudad;

            context = new GreenLeavesContext();
            oListCiudad = context.Ciudad
                          .Join(context.Estado, ciudad => ciudad.IsoEstado, estado => estado.Iso,
                          (ciudad, estado) => new { Ciudad = ciudad, Estado = estado })
                          .Join(context.Pais, ciudad_estado => ciudad_estado.Estado.IsoPais, pais => pais.Iso,
                          (ciudad_estado, pais) => ciudad_estado.Ciudad.Iso + "-" + ciudad_estado.Ciudad.Nombre + ", " + ciudad_estado.Estado.Nombre + ", " + pais.Nombre)
                          .Where(all => all.Contains(sTextCity));


            return oListCiudad.ToArray<string>();
        }

        public string[] ObtenerTodasCiudades()
        {
            IQueryable<string> oListCiudad;

            context = new GreenLeavesContext();
            oListCiudad = context.Ciudad
                          .Join(context.Estado, ciudad => ciudad.IsoEstado, estado => estado.Iso,
                          (ciudad, estado) => new { Ciudad = ciudad, Estado = estado })
                          .Join(context.Pais, ciudad_estado => ciudad_estado.Estado.IsoPais, pais => pais.Iso,
                          (ciudad_estado, pais) => ciudad_estado.Ciudad.Iso + "-" + ciudad_estado.Ciudad.Nombre + ", " + ciudad_estado.Estado.Nombre + ", " + pais.Nombre);


            return oListCiudad.ToArray<string>();
        }
    }
}
