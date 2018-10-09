using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Cotizacion;
using Infrastructure.Cross.IoC;
using System;

namespace Services.Tests
{
    [TestClass]
    public class CotizacionServiceTest
    {
        private ICotizacionService cotizacionService;

        [TestInitialize]
        public void TestSetup()
        {
            cotizacionService = FactoryIoC.Container.Resolve<CotizacionService>();
        }

        [TestMethod]
        public void GetCotizacion_Dolar_OK()
        {
            Assert.IsNotNull(cotizacionService.GetCotizacion("dolar"));
        }

        [TestMethod]
        public void GetCotizacion_Dolar_URL_Desconocida_Returns_Null()
        {
            Assert.IsNull(cotizacionService.GetCotizacion("dolar", "https://www.bancoprovincia.com.ar/Principal/Dolares"));
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void GetCotizacion_Pesos_Throws_Not_Implemented_Exception()
        {
            cotizacionService.GetCotizacion("pesos");
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void GetCotizacion_Real_Throws_Not_Implemented_Exception()
        {
            cotizacionService.GetCotizacion("real");
        }

        [TestMethod]
        public void GetCotizacion_Moneda_Desconocida_Returns_Null()
        {
            Assert.IsNull(cotizacionService.GetCotizacion("euro"));
        }
    }
}
