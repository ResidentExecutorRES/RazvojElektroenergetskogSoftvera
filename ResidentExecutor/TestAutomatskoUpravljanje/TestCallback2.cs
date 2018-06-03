using AutomatskoUpravljanje;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomatskoUpravljanje
{
    [TestFixture]
    public class TestCallback2
    {
        [Test]
        public void TestOnCallback()
        {
            Assert.DoesNotThrow(() =>
            {
                new UpisiCallback2().OnCallback("Message is not empty");
            });
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestArgumentNullException()
        {
            new UpisiCallback2().OnCallback(null);
        }
    }
}
