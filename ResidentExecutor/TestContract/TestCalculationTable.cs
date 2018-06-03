using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract;
using Contract.Exceptions;
using NUnit.Framework;

namespace TestContract
{
    [TestFixture]
    public class TestCalculationTable
    {
        [Test]
        public void KonstruktorTest()
        {
            Assert.DoesNotThrow(() => new CalculationTable("BL", SqlDateTime.Parse("2018-06-02 02:00:00.000"), 90, SqlDateTime.Parse("2018-06-01 02:00:00.000")));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KonstrukotorNullIdException()
        {
            new CalculationTable(null, SqlDateTime.Parse("2018-06-02 02:00:00.000"), 90, SqlDateTime.Parse("2018-06-01 02:00:00.000"));
        }

        [Test]
        [ExpectedException(typeof(VremeException))]
        public void KonstruktorVremeProracunaException()
        {
            new CalculationTable("SA", SqlDateTime.Parse("2018-07-02 02:00:00.000"), 90, SqlDateTime.Parse("2018-06-01 02:00:00.000"));
        }

        [Test]
        [ExpectedException(typeof(VremeException))]
        public void KonstruktorVremeMerenjaException()
        {
            new CalculationTable("SA", SqlDateTime.Parse("2018-06-02 02:00:00.000"), 90, SqlDateTime.Parse("2018-08-01 02:00:00.000"));
        }

        [Test]
        [ExpectedException(typeof(VremeException))]
        public void KonstruktorVremeException()
        {
            new CalculationTable("SA", SqlDateTime.Parse("2018-07-02 02:00:00.000"), 90, SqlDateTime.Parse("2018-08-01 02:00:00.000"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void KonstruktorVrednostNegativnaException()
        {
            new CalculationTable("SA", SqlDateTime.Parse("2018-06-02 02:00:00.000"), -1, SqlDateTime.Parse("2018-06-01 02:00:00.000"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void KonstruktorVrednostPrekoracenjeException()
        {
            Double vrednost = Double.MaxValue;
            new CalculationTable("SA", SqlDateTime.Parse("2018-06-02 02:00:00.000"), vrednost , SqlDateTime.Parse("2018-06-01 02:00:00.000"));
        }
    }
}
