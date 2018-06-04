using Contract;
using Contract.Exceptions;
using ServisniSloj;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatskoUpravljanje
{
    public class Automatik
    {
        public  Dictionary<Tuple<int, string>, Tuple<DateTime, float>> Automatic(List<PodaciIzBaze> podaci)
        {
            ObradaPodatakaZaDB obrada = new ObradaPodatakaZaDB();
            GetValues obr = new GetValues();

            if (podaci == null)
                throw new ArgumentNullException();

            foreach (var item in podaci)
            {
                if (String.IsNullOrEmpty(item.ID))
                    throw new ArgumentNullException();
                if (item.Vrednost < 0 || item.Vrednost > float.MaxValue)
                    throw new ArgumentOutOfRangeException();
                if (item.Vreme > (SqlDateTime) DateTime.Now)
                    throw new VremeException();
            }

            ICalculationFunctions f = new CalculationFunctions();
            List<int> listaIDFunkcija = obr.GetIDFunkcija();

            Dictionary<string, List<float>> vrednostiZaOdredjenoPodrucje = obr.GetVrijednostiZaGeoPodrucje(podaci);
            Dictionary<Tuple<int, string>, Tuple<DateTime, float>> retVal = new Dictionary<Tuple<int, string>, Tuple<DateTime, float>>();

            foreach (var item1 in listaIDFunkcija)
            {
                foreach (var item2 in vrednostiZaOdredjenoPodrucje)
                {
                    if (item1 == 1)
                        retVal.Add(new Tuple<int, string>(1, item2.Key), new Tuple<DateTime, float>(DateTime.Now, f.Average(item2.Value)));
                    else if (item1 == 2)
                        retVal.Add(new Tuple<int, string>(2, item2.Key), new Tuple<DateTime, float>(DateTime.Now, f.Maximum(item2.Value)));
                    else if (item1 == 3)
                        retVal.Add(new Tuple<int, string>(3, item2.Key), new Tuple<DateTime, float>(DateTime.Now, f.Minimum(item2.Value)));
                   
                }
            }

            return retVal;
        }
    }
}
