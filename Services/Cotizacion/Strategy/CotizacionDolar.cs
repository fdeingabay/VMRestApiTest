using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Entities;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Services.Cotizacion.Strategy
{
    class CotizacionDolar : ICotizacionProvider
    {
        const string UrlCotizacionBancoProvincia = "https://www.bancoprovincia.com.ar/Principal/Dolar";

        public CotizacionMoneda GetCotizacion()
        {
            return this.GetCotizacion(UrlCotizacionBancoProvincia);
        }

        public CotizacionMoneda GetCotizacion(string fromURL)
        {
            const int CompraIndex = 0;
            const int VentaIndex = 1;
            const int FechaHoraIndex = 2;

            if (fromURL == null)
                fromURL = UrlCotizacionBancoProvincia;

            using (var client = new HttpClient())
            {
                try
                {
                    var response = client.GetAsync(fromURL).Result;
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }

                    var httpContent = response.Content.ReadAsStringAsync();
                    var requestedData = httpContent.Result.Replace(".", ",");

                    var cotizacionArray = JArray.Parse(requestedData);
                    return new CotizacionMoneda()
                    {
                        Compra = float.Parse(cotizacionArray[CompraIndex].ToString()),
                        Venta = float.Parse(cotizacionArray[VentaIndex].ToString()),
                        UltimaActualizacion = cotizacionArray[FechaHoraIndex].ToString()
                    };
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
    }
}
