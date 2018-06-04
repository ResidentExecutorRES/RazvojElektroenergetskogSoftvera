using KorisnickiInterfejs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestKorisnickiInterface
{
    [TestFixture]
    public class TestUpisiCallback
    {
        [Test]
        public void TestUpisiCallbackKonstrukotor()
        {
            Assert.DoesNotThrow(() =>
            {
                new UpisiCallback().OnCallback("Send on callback");
            });       
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestUpisiCallbackNull()
        {
            new UpisiCallback().OnCallback(null);
        }

        
    }
}
