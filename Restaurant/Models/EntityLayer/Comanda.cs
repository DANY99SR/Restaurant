using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    class Comanda : BasePropertyChanged
    {

        public Comanda(int idCom,string nume,string prenume,string adr,string st,double c_m,double c_t, string da,string ora,int idUt)
        {
            IdComanda = idCom;
            NumeClient = nume;
            PrenumeClient = prenume;
            Adresa = adr;
            Stare = st;
            CostMancare = c_m;
            CostTransport = c_t;
            Data = da;
            OraLivrarii = ora;
            IdUtilizator = idUt;
        }
        enum  StareComanda
        {
            Inregistrata,
            Se_pregateste,
            Se_livreaza,
            Livrata,
            Anulata
        }

        int idComanda;
        public int IdComanda
        {
            get
            {
                return idComanda;
            }
            set
            {
                idComanda = value;
                NotifyPropertyChanged("IdComanda");
            }
        }

        int idUtilizator;
        public int IdUtilizator
        {
            get
            {
                return idUtilizator;
            }
            set
            {
                idUtilizator = value;
                NotifyPropertyChanged("IdUtilizator");
            }
        }

        double costMancare;
        public double CostMancare
        {
            get
            {
                return costMancare;
            }
            set
            {
                costMancare = value;
                NotifyPropertyChanged("CostMancare");
            }
        }

        double costTransport;
        public double CostTransport
        {
            get
            {
                return costTransport;
            }
            set
            {
                costTransport = value;
                NotifyPropertyChanged("CostTransport");
            }
        }

        string data;
        public string Data
        {
            get
            {
                return "Data: "+ data;
            }
            set
            {
                data = value;
                NotifyPropertyChanged("Data");
            }
        }

        string numeClient;
        public string NumeClient
        {
            get
            {
                return numeClient;
            }
            set
            {
                numeClient = value;
                NotifyPropertyChanged("NumeClient");
            }
        }

        string prenumeClient;
        public string PrenumeClient
        {
            get
            {
                return prenumeClient;
            }
            set
            {
                prenumeClient = value;
                NotifyPropertyChanged("PrenumeClient");
            }
        }

        string adresa;
        public string Adresa
        {
            get
            {
                return adresa;
            }
            set
            {
                adresa = value;
                NotifyPropertyChanged("Adresa");
            }
        }


        string oraLivrarii;
        public string OraLivrarii
        {
            get
            {
                return "Ora livrarii: "+oraLivrarii;
            }
            set
            {
                oraLivrarii = value;
                NotifyPropertyChanged("OraLivrarii");
            }
        }

        string stare;
        public string Stare
        {
            get
            {
                return stare;
            }
            set
            {
                stare = value;
                NotifyPropertyChanged("Stare");
            }
        }


        public string AfisareCostMancare
        {
            get
            {
                return "Cost mancare: "+ CostMancare.ToString();
            }
        }

        public string AfisareCostTransport
        {
            get
            {
                return "Cost transport: " + CostTransport.ToString();
            }
        }

        public string AfisareCostTotal
        {
            get
            {
                return "Cost total: " + (CostMancare+CostTransport).ToString();
            }
        }
    }
}
