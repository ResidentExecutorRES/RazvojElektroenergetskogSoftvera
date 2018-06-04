using Contract;
using Contract.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestContract
{
    [TestFixture]
    public class TestGetValues
    {
        [Test]
        public void TestKonskruktor()
        {
            Assert.DoesNotThrow(() =>
            {
                new GetValuesFromUI("6/4/2018 ", "02:02:02.000" ,"Banjaluka", 123);
            });
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestKonstruktorNull_1()
        {
            new GetValuesFromUI("", "02:02:02.000", "Banjaluka", 123);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestKonstruktorNull_2()
        {
            new GetValuesFromUI("6/4/2018 ", "", "Banjaluka", 123);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestKonstruktorNull_3()
        {
            new GetValuesFromUI("6/4/2018 ", "02:02:02.000", "", 123);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestKonstruktorOutOfRange()
        {
            new GetValuesFromUI("6/4/2018 ", "02:02:02.000", "Banjaluka", float.MaxValue);
        }

        [Test]
        [ExpectedException(typeof(VremeException))]
        public void TestKonstruktorVreme()
        {
            new GetValuesFromUI("9/4/2018 ", "02:02:02.000", "Banjaluka", 234);
        }


    }
}
