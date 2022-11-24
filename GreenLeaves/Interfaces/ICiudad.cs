using System.Threading.Tasks;

namespace GreenLeaves.Interfaces
{
    public interface ICiudad
    {
        string[] ObtenerTodasCiudades();

        string[] ObtenerCiudad(string sTextCity);
    }
}
