using Contract;
using NUnit.Framework;
using ServisniSloj;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServisniSloj
{
    [TestFixture]
    public class TestGetValues
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetVrijednostiZaGeoPodrucjeNull()
        {
            List<PodaciIzBaze> podaci = null;
            new GetValues().GetVrijednostiZaGeoPodrucje(podaci);
        }

        [Test]
        public void TestGetVrijednostiZaGeoPodrucje()
        {
            List<PodaciIzBaze> podaci = new List<PodaciIzBaze>()
            {
                new PodaciIzBaze("BL", SqlDateTime.Parse(DateTime.Now.ToString()), 1234),
                new PodaciIzBaze("BN", SqlDateTime.Parse(DateTime.Now.ToString()), 1238),
                new PodaciIzBaze("SA", SqlDateTime.Parse(DateTime.Now.ToString()), 1236),
            };

            Assert.DoesNotThrow(() =>
            {
                new GetValues().GetVrijednostiZaGeoPodrucje(podaci);
            });
        }
    }
}
