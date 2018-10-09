using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Cotizacion.Strategy
{
    public class CotizacionReal : ICotizacionProvider
    {
        public CotizacionMoneda GetCotizacion()
        {
            throw new NotImplementedException();
        }

        public CotizacionMoneda GetCotizacion(string fromURL)
        {
            throw new NotImplementedException();
        }
    }
}
