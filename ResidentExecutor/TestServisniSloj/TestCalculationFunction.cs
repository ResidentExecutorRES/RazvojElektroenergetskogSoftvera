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
    public class TestCalculationFunction
    {
        [Test]
        public void TestAverage()
        {
            Assert.DoesNotThrow(() =>
            {
                new CalculationFunctions().Average(new List<float>() { 5, 10, 15, 23, 6, 12, 50 });
            });
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullExceptionAverage()
        {
            List<float> lista = null;

            new CalculationFunctions().Average(lista);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAutoOfRangeExceptionAverage()
        {
            List<float> lista = new List<float>() {float.MaxValue,999,2};

            new CalculationFunctions().Average(lista);
        }

        [Test]
        public void TestMaximum()
        {
            Assert.DoesNotThrow(() =>
            {
                new CalculationFunctions().Maximum(new List<float>() { 5, 10, 15, 23, 6, 12, 50 });
            });
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullExceptionMaximum()
        {
            List<float> lista = null;

            new CalculationFunctions().Maximum(lista);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAutoOfRangeExceptionMaximum()
        {
            List<float> lista = new List<float>() { float.MaxValue, 999, 2 };

            new CalculationFunctions().Maximum(lista);
        }

        [Test]
        public void TestMinimum()
        {
            Assert.DoesNotThrow(() =>
            {
                new CalculationFunctions().Minimum(new List<float>() { 5, 10, 15, 23, 6, 12, 50 });
            });
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullExceptionMinimum()
        {
            List<float> lista = null;

            new CalculationFunctions().Minimum(lista);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAutoOfRangeExceptionMinimum()
        {
            List<float> lista = new List<float>() { float.MaxValue, 999, 2 };

            new CalculationFunctions().Minimum(lista);
        }
    }
}
