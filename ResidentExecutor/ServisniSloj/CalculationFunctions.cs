using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisniSloj
{
    public class CalculationFunctions : ICalculationFunctions
    {
        public float Average(List<float> listaPotrosnji)
        {
            if (listaPotrosnji == null)
                throw new ArgumentNullException();

            foreach (var item in listaPotrosnji)
            {
                if (item >= float.MaxValue)
                    throw new ArgumentOutOfRangeException();
            }
            return listaPotrosnji.Average();
        }
        public float Maximum(List<float> listaPotrosnji)
        {
            if (listaPotrosnji == null)
                throw new ArgumentNullException();

            foreach (var item in listaPotrosnji)
            {
                if (item >= float.MaxValue)
                    throw new ArgumentOutOfRangeException();
            }

            return listaPotrosnji.Max();
        }
        public float Minimum(List<float> listaPotrosnji)
        {
            if (listaPotrosnji == null)
                throw new ArgumentNullException();

            foreach (var item in listaPotrosnji)
            {
                if (item >= float.MaxValue)
                    throw new ArgumentOutOfRangeException();
            }

            return listaPotrosnji.Min();
        }
    }
}
