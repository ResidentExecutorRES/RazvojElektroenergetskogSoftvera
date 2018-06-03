using Contract;
using NUnit.Framework;
using PristupDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPristupDb
{
    [TestFixture]
    public class TestInsertCalculationFunction
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestPosaljiInsertNull()
        {
            new InsertCaluculationFunction().PosaljiInsert(null);
        }

        [Test]
        public void TestPosaljiInsert()
        {
            string s = "INSERT INTO FunkcijaAverage (IDGeoPodrucja, VremeProracuna, AverageVrednost, PoslednjeVreme) VALUES ('BL', '2018-06-02 02:00:00.000', 176, '2018-06-01 03:04:00.000');";

            List<string> lista = new List<string>() { s };
            Assert.DoesNotThrow(() =>
            {
                new InsertCaluculationFunction().PosaljiInsert(lista);
            });
        }
    }
}
