using GreenLeaves.Implementations;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GreenLeaves.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class CiudadController : ControllerBase
    {

        // GET: api/<CiudadController>
        [HttpGet]
        public IEnumerable<string> GetAllCities()
        {
            try
            {
                CiudadRepository oCiudadRepository = new CiudadRepository();
                return oCiudadRepository.ObtenerTodasCiudades();
            }
            catch (Exception)
            {
                return (IEnumerable<string>)StatusCode(StatusCodes.Status500InternalServerError, "Error getting Cities");
            }
        }

        // GET api/<CiudadController>/5
        [HttpGet("{sTextCity}")]
        public IEnumerable<string> Get(string sTextCity)
        {
            try
            {
                CiudadRepository oCiudadRepository = new CiudadRepository();
                return oCiudadRepository.ObtenerCiudad(sTextCity);
            }
            catch (Exception)
            {
                return (IEnumerable<string>)StatusCode(StatusCodes.Status500InternalServerError, "Error getting specific city");
            }
        }

    }
}
