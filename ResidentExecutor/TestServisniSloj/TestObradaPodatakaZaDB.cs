using Contract;
using Contract.Exceptions;
using Moq;
using NSubstitute;
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
    public class TestObradaPodatakaZaDB
    {


        [Test]
        public void TestInsertIntoTable()
        {
            Assert.DoesNotThrow(() =>
            {
                new ObradaPodatakaZaDB().Connect();
            });
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestDuplexSample()
        {
            new ObradaPodatakaZaDB().DuplexSample(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestInsertIntoTableNull()
        {
            new ObradaPodatakaZaDB().InsertIntoTable(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestInsertIntoTableDictKeyNull()
        {
            //Tuple<int, string> t1 = new Tuple<int, string>(1, "BL");
            Tuple<DateTime, float> t2 = new Tuple<DateTime, float>(DateTime.Now, 342);
            Dictionary<Tuple<int, string>, Tuple<DateTime, float>> dict = new Dictionary<Tuple<int, string>, Tuple<DateTime, float>>() { { null, t2} };
            List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>> l = new List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>>();
            l.Add(dict);
            new ObradaPodatakaZaDB().InsertIntoTable(l);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestInsertIntoTableDictValueNull()
        {
            Tuple<int, string> t1 = new Tuple<int, string>(1, "BL");
            //Tuple<DateTime, float> t2 = new Tuple<DateTime, float>(DateTime.Now, 342);
            Dictionary<Tuple<int, string>, Tuple<DateTime, float>> dict = new Dictionary<Tuple<int, string>, Tuple<DateTime, float>>() { { t1, null } };
            List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>> l = new List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>>();
            l.Add(dict);
            new ObradaPodatakaZaDB().InsertIntoTable(l);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInsertIntoTableDictKey_Item1_1_Null()
        {
            Tuple<int, string> t1 = new Tuple<int, string>(0, "BL");
            Tuple<DateTime, float> t2 = new Tuple<DateTime, float>(DateTime.Now, 342);
            Dictionary<Tuple<int, string>, Tuple<DateTime, float>> dict = new Dictionary<Tuple<int, string>, Tuple<DateTime, float>>() { { t1, t2 } };
            List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>> l = new List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>>();
            l.Add(dict);
            new ObradaPodatakaZaDB().InsertIntoTable(l);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInsertIntoTableDictKey_Item1_2_Null()
        {
            Tuple<int, string> t1 = new Tuple<int, string>(4, "BL");
            Tuple<DateTime, float> t2 = new Tuple<DateTime, float>(DateTime.Now, 342);
            Dictionary<Tuple<int, string>, Tuple<DateTime, float>> dict = new Dictionary<Tuple<int, string>, Tuple<DateTime, float>>() { { t1, t2 } };
            List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>> l = new List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>>();
            l.Add(dict);
            new ObradaPodatakaZaDB().InsertIntoTable(l);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestInsertIntoTableDictKey_Item_2_1Null()
        {
            Tuple<int, string> t1 = new Tuple<int, string>(1, "");
            Tuple<DateTime, float> t2 = new Tuple<DateTime, float>(DateTime.Now, 342);
            Dictionary<Tuple<int, string>, Tuple<DateTime, float>> dict = new Dictionary<Tuple<int, string>, Tuple<DateTime, float>>() { { t1, t2 } };
            List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>> l = new List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>>();
            l.Add(dict);
            new ObradaPodatakaZaDB().InsertIntoTable(l);
        }

        [Test]
        [ExpectedException(typeof(VremeException))]
        public void TestInsertIntoTableDictValue_Item_1_Vreme()
        {
            Tuple<int, string> t1 = new Tuple<int, string>(1, "BL");
            Tuple<DateTime, float> t2 = new Tuple<DateTime, float>(DateTime.Today.AddDays(+1), 342);
            Dictionary<Tuple<int, string>, Tuple<DateTime, float>> dict = new Dictionary<Tuple<int, string>, Tuple<DateTime, float>>() { { t1, t2 } };
            List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>> l = new List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>>();
            l.Add(dict);
            new ObradaPodatakaZaDB().InsertIntoTable(l);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInsertIntoTableDictValue_Item_2_MaxValue()
        {
            Tuple<int, string> t1 = new Tuple<int, string>(1, "BL");
            Tuple<DateTime, float> t2 = new Tuple<DateTime, float>(DateTime.Now, float.MaxValue);
            Dictionary<Tuple<int, string>, Tuple<DateTime, float>> dict = new Dictionary<Tuple<int, string>, Tuple<DateTime, float>>() { { t1, t2 } };
            List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>> l = new List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>>();
            l.Add(dict);
            new ObradaPodatakaZaDB().InsertIntoTable(l);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInsertIntoTableDictValue_Item_2_NegativnaVrednost()
        {
            Tuple<int, string> t1 = new Tuple<int, string>(1, "BL");
            Tuple<DateTime, float> t2 = new Tuple<DateTime, float>(DateTime.Now, -2 );
            Dictionary<Tuple<int, string>, Tuple<DateTime, float>> dict = new Dictionary<Tuple<int, string>, Tuple<DateTime, float>>() { { t1, t2 } };
            List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>> l = new List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>>();
            l.Add(dict);
            new ObradaPodatakaZaDB().InsertIntoTable(l);
        }




        [Test]
        public void TestSamojednoPodrucje()
        {
            List<PodaciIzBaze> list = new List<PodaciIzBaze>();
            list.Add(new PodaciIzBaze("BL", SqlDateTime.Parse(DateTime.Now.ToString()), 234));
            Assert.DoesNotThrow(() =>
            {
                new ObradaPodatakaZaDB().SamoPoJednoPodrucje(list);
            });
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSamoJednoPodrucjeNull()
        {
            List<PodaciIzBaze> list = null; //= new List<PodaciIzBaze>();
            //list.Add(new PodaciIzBaze("BL", SqlDateTime.Parse(DateTime.Now.ToString()), 234));
            new ObradaPodatakaZaDB().SamoPoJednoPodrucje(list);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSamoJednoPodrucjeNullString()
        {
            List<PodaciIzBaze> list = new List<PodaciIzBaze>();
            list.Add(new PodaciIzBaze(null, SqlDateTime.Parse(DateTime.Now.ToString()), 234));
            new ObradaPodatakaZaDB().SamoPoJednoPodrucje(list);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSamoJednoPodrucjeVrednostInvalid()
        {
            List<PodaciIzBaze> list = new List<PodaciIzBaze>();
            list.Add(new PodaciIzBaze("BL", SqlDateTime.Parse(DateTime.Now.ToString()), float.MaxValue));
            new ObradaPodatakaZaDB().SamoPoJednoPodrucje(list);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSamoJednoPodrucjeVremeInvalid()
        {
            List<PodaciIzBaze> list = new List<PodaciIzBaze>();
            list.Add(new PodaciIzBaze("BL", SqlDateTime.Parse((DateTime.Today.AddDays(+1)).ToString()), float.MaxValue));
            new ObradaPodatakaZaDB().SamoPoJednoPodrucje(list);
        }

        [Test]
        public void TestOnCallBack()
        {
            Assert.DoesNotThrow(() =>
            {
                new UpisiCallback2().OnCallback("message");
            });
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestOnCallBackNull()
        {
            new UpisiCallback2().OnCallback(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestProveriZaIf_IdNull()
        {
            //string id = "BL";
            SqlDateTime vreme = (SqlDateTime)DateTime.Now;
            int i = 1;

            new ObradaPodatakaZaDB().ProveriZaIf(null, vreme, i);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestProveriZaIf_I_1()
        {
            string id = "BL";
            SqlDateTime vreme = (SqlDateTime)DateTime.Now;
            int i = 4;
            new ObradaPodatakaZaDB().ProveriZaIf(id, vreme, i);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestProveriZaIf_I_2()
        {
            string id = "BL";
            SqlDateTime vreme = (SqlDateTime)DateTime.Now;
            int i = 0;
            new ObradaPodatakaZaDB().ProveriZaIf(id, vreme, i);
        }

        [Test]
        [ExpectedException(typeof(VremeException))]
        public void TestProveriZaIfVreme()
        {
            string id = "BL";
            SqlDateTime vreme = (SqlDateTime)(DateTime.Today.AddDays(+1));
            int i = 0;
            new ObradaPodatakaZaDB().ProveriZaIf(id, vreme, i);
        }


    }
}
