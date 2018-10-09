using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Cotizacion.Strategy
{
    public interface ICotizacionProvider
    {
        Entities.CotizacionMoneda GetCotizacion();

        Entities.CotizacionMoneda GetCotizacion(string fromURL);
    }
}
