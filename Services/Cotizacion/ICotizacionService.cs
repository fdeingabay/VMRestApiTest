using Domain.Enum;
using Services.Cotizacion.Strategy;

namespace Services.Cotizacion
{
    public interface ICotizacionService
    {
        Entities.CotizacionMoneda GetCotizacion(string moneda, string fromURL = null);
    }
}
