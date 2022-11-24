using GreenLeaves.Models;
using System.Threading.Tasks;

namespace GreenLeaves.Interfaces
{
    public interface IContacto
    {
        public Task<Contacto> AgregarContacto(Contacto oContacto);
    }
}
