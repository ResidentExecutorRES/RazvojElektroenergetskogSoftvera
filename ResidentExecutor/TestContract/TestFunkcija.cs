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
    public class TestFunkcija
    {
        [Test]
        public void FunckijaKonstruktor()
        {
            Assert.DoesNotThrow(() =>
            {
                new FUNKCIJA(1, 0);
            });
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FunkcijaKOnstruktorPrviParametar()
        {
            new FUNKCIJA(4, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FunkcijaKOnstruktorDrugiParametar()
        {
            new FUNKCIJA(2, 3);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FunkcijaKOnstruktorObaParametra()
        {
            new FUNKCIJA(4, 3);
        }



    }
}
