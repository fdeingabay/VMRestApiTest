using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enum;
using Entities;
using Services.Cotizacion.Strategy;

namespace Services.Cotizacion
{
    public class CotizacionService : ICotizacionService
    {
        public Entities.CotizacionMoneda GetCotizacion(string moneda, string fromURL = null)
        {
            Moneda monedaToGet;
            if (!Enum.TryParse<Moneda>(moneda, true, out monedaToGet))
            {
                return null;
            }

            var cotizacionProvider = this.GetProvider(monedaToGet);
            return cotizacionProvider.GetCotizacion(fromURL);
        }

        private ICotizacionProvider GetProvider(Moneda moneda)
        {
            ICotizacionProvider provider = null;

            switch (moneda)
            {
                case Moneda.Pesos:
                    provider = new CotizacionPesos();
                    break;
                case Moneda.Dolar:
                    provider = new CotizacionDolar();
                    break;
                case Moneda.Real:
                    provider = new CotizacionReal();
                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }

            return provider;
        }
    }
}
