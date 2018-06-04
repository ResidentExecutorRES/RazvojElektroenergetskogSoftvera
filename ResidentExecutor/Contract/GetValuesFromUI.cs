using Contract.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class GetValuesFromUI
    {
        private string _datum;
        private string _vreme;
        private string _geoPodrucje;
        private float _unesenaPotrosnja;

        public GetValuesFromUI()
        {

        }

        public GetValuesFromUI(string d, string v, string g, float u)
        {
            if (String.IsNullOrEmpty(d) || String.IsNullOrEmpty(v) || String.IsNullOrEmpty(g))
                throw new ArgumentNullException();

            if (u >= float.MaxValue || u < 0)
                throw new ArgumentOutOfRangeException();

            if (SqlDateTime.Parse(d + v) > (SqlDateTime)DateTime.Now)
                throw new VremeException();

            _datum = d;
            _vreme = v;
            _geoPodrucje = g;
            _unesenaPotrosnja = u;
        }

        public string Datum { get => _datum; set => _datum = value; }
        public string Vreme { get => _vreme; set => _vreme = value; }
        public string GeoPodrucje { get => _geoPodrucje; set => _geoPodrucje = value; }
        public float UnesenaPotrosnja { get => _unesenaPotrosnja; set => _unesenaPotrosnja = value; }


    }
}
