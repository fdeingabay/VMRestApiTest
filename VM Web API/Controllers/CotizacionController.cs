using Entities;
using Services.Cotizacion;
using System;
using System.Web.Http;

namespace VM_Web_API.Controllers
{
    public class CotizacionController : ApiController
    {
        private ICotizacionService cotizacionService;

        public CotizacionController(ICotizacionService cotizacionService)
        {
            this.cotizacionService = cotizacionService;
        }

        [HttpGet]
        [Route("api/cotizacion/{moneda}")]
        public IHttpActionResult Get(string moneda)
        {
            CotizacionMoneda cotizacion = null;

            try
            {
                cotizacion = cotizacionService.GetCotizacion(moneda);
            }
            catch(NotImplementedException e)
            {
                return Unauthorized();
            }

            if (cotizacion == null)
            {
                return NotFound();
            }

            return Ok(cotizacion);
        }
    }
}
