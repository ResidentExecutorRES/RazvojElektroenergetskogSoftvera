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
    public class TestPathHelper
    {
        [Test]
        public void TestGetPathRezidentneFunkcije()
        {
            string check = @"../../../rezidentne_funkcije.xml";
            Assert.DoesNotThrow(() =>
            {
                String path = new PathHelper().GetPathRezidentneFunkcije();
                Assert.AreEqual(check, path);
            });
        }

        [Test]
        public void TestGetPathGeoPodrucja()
        {
            string check = @"../../../geo_podrucja.xml";
            Assert.DoesNotThrow(() =>
            {
                String path = new PathHelper().GetPathGeoPodrucja();
                Assert.AreEqual(check, path);
            });
        }
    }
}
