using Contract;
using Contract.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace KorisnickiInterfejs
{
    public partial class MainWindow : Window
    {
        GetValuesFromUI get = new GetValuesFromUI();

        //private string _datum;
        //private string _vreme;
        //private string get.GeoPodrucja;
        //private float get.UnesenaPotrosnja;

        private PathHelper path = new PathHelper();
        private string address = "net.tcp://localhost:10100/IConnect";
        private string addressDuplex = "net.tcp://localhost:10102/IUpisi";

        private NetTcpBinding binding = new NetTcpBinding();
        public List<PodaciIzBaze> podaciIzBaze = new List<PodaciIzBaze>();
        private RadSaXML radSaXML = new RadSaXML();
        //public string Datum { get => _datum; set => _datum = value; }
        //public string Vreme { get => _vreme; set => _vreme = value; }
        //public string GeoPodrucje { get => get.GeoPodrucja; set => get.GeoPodrucja = value; }
        //public float UnesenaPotrosnja { get => get.UnesenaPotrosnja; set => get.UnesenaPotrosnja = value; }

        public MainWindow()
        {
            InitializeComponent();
            geoCombo.ItemsSource = GeoPodrucja.geoPodrucja.Values;

            if (!File.Exists(path.GetPathGeoPodrucja()))
                new RadSaXML().NapraviXMLGeoPOdrucja();
        }
        private bool Validate()
        {
            bool retVal = true;

            #region GeoComboValidacija
            if (geoCombo.SelectedItem == null)
            {
                retVal = false;
                geoGreska.Content = "Izaberite jednu od ponudjenih vrednosti";
                geoGreska.BorderThickness = new Thickness(0);
                geoGreska.BorderBrush = Brushes.Red;
            }
            else
            {
                get.GeoPodrucje = geoCombo.Text.ToString();
                geoGreska.Content = "";
                geoGreska.BorderBrush = Brushes.Transparent;
                geoLabel.BorderBrush = Brushes.White;
            }
            #endregion

            #region PotrosnjaValidacija
            if (potrosnjaTextBox.Text.Trim().Equals(""))
            {
                retVal = false;
                potrosnjaGreska.Content = "Polje ne sme biti prazno.";
                potrosnjaGreska.BorderThickness = new Thickness(0);
                potrosnjaGreska.BorderBrush = Brushes.Red;
            }
            else if (float.TryParse(potrosnjaTextBox.Text, out float potrosnja))
            {
                if (potrosnja < 0)
                {
                    retVal = false;
                    potrosnjaGreska.Content = "Potrosnja ne sme biti negativna vrednost.";
                    potrosnjaGreska.BorderThickness = new Thickness(0);
                    potrosnjaGreska.BorderBrush = Brushes.Red;

                }
                else
                {
                    get.UnesenaPotrosnja = potrosnja;
                    potrosnjaGreska.Content = "";
                    potrosnjaGreska.BorderBrush = Brushes.Transparent;
                    potrosnjaTextBox.BorderBrush = Brushes.White;
                }
            }
            else
            {
                retVal = false;
                potrosnjaGreska.Content = "Potrosnja mora biti broj";
                potrosnjaGreska.BorderThickness = new Thickness(0);
                potrosnjaGreska.BorderBrush = Brushes.Red;
            }
            #endregion

            #region DateTimeValidacija
            if (vremeTextBox.Text.Trim().Equals("") || vremeTextBox2.Text.Trim().Equals("") || vremeTextBox3.Text.Trim().Equals(""))
            {
                retVal = false;
                vremeGreska.Content = "Sva polja za vreme morate uneti.";
                vremeGreska.BorderThickness = new Thickness(0);
                vremeGreska.BorderBrush = Brushes.Red;
            }
            else if (int.TryParse(vremeTextBox.Text, out int sati) &&
                    int.TryParse(vremeTextBox2.Text, out int minuti) &&
                    int.TryParse(vremeTextBox3.Text, out int sekunde))
            {
                if ((sati < 0 || sati > 24) || (minuti < 0 || minuti > 60) || (sekunde < 0 || sekunde > 60))
                {
                    retVal = false;
                    vremeGreska.Content = "Unesite validne vrednosti za vreme.";
                    vremeGreska.BorderThickness = new Thickness(0);
                    vremeGreska.BorderBrush = Brushes.Red;
                }
                else
                {
                    get.Vreme = sati.ToString() + ":" + minuti.ToString() + ":" + sekunde.ToString() + ".000";
                    vremeGreska.Content = "";
                    vremeGreska.BorderBrush = Brushes.Transparent;
                    vremeTextBox.BorderBrush = Brushes.White;
                    vremeTextBox2.BorderBrush = Brushes.White;
                    vremeTextBox3.BorderBrush = Brushes.White;
                }

            }
            else
            {
                retVal = false;
                vremeGreska.Content = "Niste uneli validne vrednosti za vreme";
                vremeGreska.BorderThickness = new Thickness(0);
                vremeGreska.BorderBrush = Brushes.Red;
            }


            DateTime dateTime1 = datumPicker.DisplayDate;
            DateTime dateTime2 = DateTime.Now;
            DateTime dateTime3 = new DateTime();

            dateTime3.AddYears(dateTime2.Year - 5);

            if (datumPicker.Text.Equals(""))
            {
                retVal = false;
                datumGreska.Content = "Odaberite vreme";
                datumGreska.BorderThickness = new Thickness(0);
                datumGreska.BorderBrush = Brushes.Red;
            }
            else if (datumPicker.SelectedDate.Value.Date > DateTime.Now)
            {
                retVal = false;
                datumGreska.Content = "Nije moguc unos vremena u buducnosti";
                datumGreska.BorderThickness = new Thickness(0);
                datumGreska.BorderBrush = Brushes.Red;
            }
            else if (DateTime.Compare(dateTime1, new DateTime(2013, 1, 1)) < 0)
            {
                retVal = false;
                datumGreska.Content = "Ne postoje merenja za taj datum";
                datumGreska.BorderThickness = new Thickness(0);
                datumGreska.BorderBrush = Brushes.Red;
            }
            else if(SqlDateTime.Parse((datumPicker.SelectedDate.Value.Date.ToString().Replace("12:00:00 AM", "") + get.Vreme).ToString()) > 
                    SqlDateTime.Parse(DateTime.Now.ToString()))
            {
                retVal = false;
                vremeGreska.Content = "Nije moguce uneti vreme u buducnosti.";
                vremeGreska.BorderThickness = new Thickness(0);
                vremeGreska.BorderBrush = Brushes.Red;
            }
            else
            {

                get.Datum = datumPicker.SelectedDate.Value.Date.ToShortDateString();
                datumGreska.Content = "";
                vremeGreska.BorderBrush = Brushes.Transparent;
                datumPicker.BorderBrush = Brushes.White;
            }

            #endregion

            return retVal;
        }

        private void DuplexSample(string s)
        {
            if (String.IsNullOrEmpty(s))
                throw new ArgumentNullException();

            EndpointAddress address = new EndpointAddress(addressDuplex);

            var clientCallback = new UpisiCallback();
            var context = new InstanceContext(clientCallback);

            var factory = new DuplexChannelFactory<IUpisi>(clientCallback, binding, address);

            IUpisi messageChanel = factory.CreateChannel();
            Task.Run(() => messageChanel.PosaljiInsert(s));
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                string idGeoPodrucja = "";
                bool nadjenoUTabeli = false;
                string[] trimovano = get.Datum.Split('/');                
                string datum = trimovano[2] + "-" + trimovano[0] + "-" + trimovano[1] + " " + get.Vreme;
                IConnect proxy = new ChannelFactory<IConnect>(binding, new EndpointAddress(address)).CreateChannel();

                SqlDateTime d = SqlDateTime.Parse(datum);
                podaciIzBaze = proxy.VratiRedove();

                foreach (var item in GeoPodrucja.geoPodrucja)
                {
                    if (item.Value == get.GeoPodrucje)
                        idGeoPodrucja = item.Key;
                }                

                foreach (var item in podaciIzBaze)
                {
                    if(item.ID == idGeoPodrucja && item.Vreme == d)
                    {
                        nadjenoUTabeli = true;
                        break;
                    }
                }                

               string upit = "INSERT INTO UneseneVrednosti " +
                      "(IDGeoPodrucja, VremeMerenja, Vrednost) " +
                      "VALUES ('" + idGeoPodrucja + "', '" + datum + "', " + get.UnesenaPotrosnja + ")";

                if (nadjenoUTabeli == false)
                    DuplexSample(upit);

                UneseniPodaci uneseni = new UneseniPodaci();
                this.Close();
                uneseni.ShowDialog();              
            }
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void IzmijeniXML_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(path.GetPathRezidentneFunkcije()))
                radSaXML.NapraviXMLFunkcije();
            else
                radSaXML.IzmeniXML();
        }

    }
}
