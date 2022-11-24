using GreenLeaves.Implementations;
using GreenLeaves.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GreenLeaves.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ContactoController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Contacto>> Post([FromBody] Contacto oContacto)
        {
            try
            {
                ContactoRepository oContactoRepository = new ContactoRepository();
                return await oContactoRepository.AgregarContacto(oContacto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new Contact record");
            }
        }
    }
}
