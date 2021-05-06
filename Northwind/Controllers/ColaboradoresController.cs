using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradoresController : ControllerBase
    {
        /// <summary>
        /// Obter lista 
        /// </summary>
        /// <param name="dataInicial">datainicial</param>
        /// <param name="dataFinal">datafinal</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Colaboradores>), 200)]
        [ProducesResponseType(500)]
        public IActionResult Get(DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                return Ok(new Business.ColaboradoresBusiness().GetColaboradores( dataInicial, dataFinal));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
