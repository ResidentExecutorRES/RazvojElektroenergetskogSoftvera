using Contract;
using Moq;
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
    public class TestConnect
    {

        [Test]
        public void TestVratiRedove()
        {
            Assert.DoesNotThrow(() =>
            {
                new Connect().VratiRedove();
            });
        }

        [Test]
        public void TestDanasnjiDatumFja()
        {
            Assert.DoesNotThrow(() =>
            {
                new Konekcija().DanasnjiDatum();
            });
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpisiPosaljiInsert()
        {
            string s = "INSERT INTO Tabela (IdGeoPodrucja, VremeProracuna, Vrednost)";
            new Upisi().PosaljiInsert(s);
        }

    }
}
