using AutomatskoUpravljanje;
using Contract;
using Contract.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomatskoUpravljanje
{
    [TestFixture]
    public class TestAutomatic
    {
        [Test]
        public void TestAUtomaticFunction()
        {
            List<PodaciIzBaze> list = new List<PodaciIzBaze>();
            list.Add(new PodaciIzBaze("BL", SqlDateTime.Parse(DateTime.Now.ToString()), 456));
            
            Assert.DoesNotThrow(() =>
            {
                new Automatik().Automatic(list);
            });
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAutomaticNull()
        {
            List<PodaciIzBaze> lista = null;

            new Automatik().Automatic(lista);
        }

        [Test]
        [ExpectedException(typeof(VremeException))]
        public void TestAUtomaticFunctionVreme()
        {
            List<PodaciIzBaze> list = new List<PodaciIzBaze>();
            list.Add(new PodaciIzBaze("BL", SqlDateTime.Parse((DateTime.Today.AddDays(+1)).ToString()), 456));

            new Automatik().Automatic(list);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAUtomaticFunctionID()
        {
            List<PodaciIzBaze> list = new List<PodaciIzBaze>();
            list.Add(new PodaciIzBaze(null, SqlDateTime.Parse(DateTime.Now.ToString()), 456));

            new Automatik().Automatic(list);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAUtomaticFunctionVrednost()
        {
            List<PodaciIzBaze> list = new List<PodaciIzBaze>();
            list.Add(new PodaciIzBaze("BL", SqlDateTime.Parse(DateTime.Now.ToString()), float.MaxValue));

            new Automatik().Automatic(list);
        }

       
    }
}
