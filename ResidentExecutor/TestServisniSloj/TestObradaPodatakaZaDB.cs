using NUnit.Framework;
using ServisniSloj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServisniSloj
{
    [TestFixture]
    public class TestObradaPodatakaZaDB
    {
        [Test]
        public void TestInsertIntoTable()
        {
            List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>> listaUbacenihVrednostiWhile = new List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>>();
            Tuple<int, string> t1 = new Tuple<int, string>(1, "BL");
            Tuple<DateTime, float> t2 = new Tuple<DateTime, float>(DateTime.Now, 123);

            Dictionary<Tuple<int, string>, Tuple<DateTime, float>> dict = new Dictionary<Tuple<int, string>, Tuple<DateTime, float>>();
            dict.Add(t1, t2);
            listaUbacenihVrednostiWhile.Add(dict);

            Assert.DoesNotThrow(() =>
            {
                new ObradaPodatakaZaDB().InsertIntoTable(listaUbacenihVrednostiWhile);
            });
        }
    }
}
