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
    public class TestGetSelectQuery
    {
        [Test]
        public void TestGetFromUneseneVrednosti()
        {
            string check = "SELECT * FROM UneseneVrednosti";
            Assert.DoesNotThrow(() =>
            {
                String select = new GetSelectQuery().GetFromUneseneVrednosti();
                Assert.AreEqual(check, select);
            });
        }

        [Test]
        public void TestGetFromUneseneVrednostiDate()
        {
            string check = "SELECT * FROM UneseneVrednosti WHERE CONVERT(DATE, VremeMerenja) = CONVERT(DATE, GETDATE())";
            Assert.DoesNotThrow(() =>
            {
                String select = new GetSelectQuery().GetFromUneseneVrednostiDate();
                Assert.AreEqual(check, select);
            });
        }

        [Test]
        public void TestGetFromFunkcijaAverage()
        {
            string check = "SELECT * FROM FunkcijaAverage";
            Assert.DoesNotThrow(() =>
            {
                String select = new GetSelectQuery().GetFromFunkcijaAverage();
                Assert.AreEqual(check, select);
            });
        }

        [Test]
        public void TestGetFromFunkcijaMaximum()
        {
            string check = "SELECT * FROM FunkcijaMaximum";
            Assert.DoesNotThrow(() =>
            {
                String select = new GetSelectQuery().GetFromFunkcijaMaximum();
                Assert.AreEqual(check, select);
            });
        }

        [Test]
        public void TestGetFromFunkcijaMinimum()
        {
            string check = "SELECT * FROM FunkcijaMinimum";
            Assert.DoesNotThrow(() =>
            {
                String select = new GetSelectQuery().GetFromFunkcijaMinimum();
                Assert.AreEqual(check, select);
            });
        }

    }
}
