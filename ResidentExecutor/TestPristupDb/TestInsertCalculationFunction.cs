using Contract;
using NUnit.Framework;
using NUnit.Mocks;
using PristupDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

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
        [ExpectedException(typeof(ArgumentException))]
        public void TestPosaljiInsert()
        {
            string s = "INSERT INTO FunkcijaAverage (IDGeoPodrucja, VremeProracuna, AverageVrednost, PoslednjeVreme)  ('BL', '2018-06-02 02:00:00.000', 176, '2018-06-01 03:04:00.000');";

            List<string> lista = new List<string>() { s };
           
            new InsertCaluculationFunction().PosaljiInsert(lista);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPosaljiInsert_1()
        {
            string s = " FunkcijaAverage (IDGeoPodrucja, VremeProracuna, AverageVrednost, PoslednjeVreme)  ('BL', '2018-06-02 02:00:00.000', 176, '2018-06-01 03:04:00.000');";

            List<string> lista = new List<string>() { s };

            new InsertCaluculationFunction().PosaljiInsert(lista);
        }
    }
}
