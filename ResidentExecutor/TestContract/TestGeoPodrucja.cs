using Contract;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestContract
{
    [TestFixture]
    public class TestGeoPodrucja
    {
        [Test]
        public void KonstruktorTest()
        {
            Assert.DoesNotThrow(() => new GeoPodrucja("BL", "Banjaluka"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KonstrukotorNullIdException_1()
        {
            new GeoPodrucja(null, "Banjaluka");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KonstrukotorNullIdException_2()
        {
            new GeoPodrucja("BL", null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KonstrukotorNullIdException_3()
        {
            new GeoPodrucja(null, null);
        }

    }
}
