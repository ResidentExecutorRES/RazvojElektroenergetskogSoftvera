using Contract;
using Contract.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestContract
{
    [TestFixture]
    public class TestPodaciIzBaze
    {
        [Test]
        public void KonstruktorTest()
        {
            Assert.DoesNotThrow(() => new PodaciIzBaze("BL", SqlDateTime.Parse("2018-06-02 02:00:00.000"), 90));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KonstrukotorNullIdException()
        {
            new PodaciIzBaze(null, SqlDateTime.Parse("2018-06-02 02:00:00.000"), 90);
        }

        [Test]
        [ExpectedException(typeof(VremeException))]
        public void KonstruktorVremeMerenjaException()
        {
            new PodaciIzBaze("SA", SqlDateTime.Parse("2018-07-02 02:00:00.000"), 90);
        }

        [Test]
        [ExpectedException(typeof(VremeException))]
        public void KonstruktorVremeException()
        {
            new PodaciIzBaze("SA", SqlDateTime.Parse("2018-07-02 02:00:00.000"), 90);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void KonstruktorVrednostNegativnaException()
        {
            new PodaciIzBaze("SA", SqlDateTime.Parse("2018-06-02 02:00:00.000"), -1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void KonstruktorVrednostPrekoracenjeException()
        {
            float vrednost = float.MaxValue;
            new PodaciIzBaze("SA", SqlDateTime.Parse("2018-06-02 02:00:00.000"), vrednost);
        }
    }
}
