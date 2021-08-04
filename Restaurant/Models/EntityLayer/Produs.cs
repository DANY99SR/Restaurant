using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    class Produs : BasePropertyChanged
    {
        
        public Produs(int id,string n, double p, int c, int c_t, string img, string cat, List<string> al)
        {
            Id_produs = id;
            Nume = n;
            Pret = p;
            Cantitate = c;
            CantitateTotala = c_t;
            Imagine = img;
            Categorie = cat;
            Alergeni = al;
        }

        int id_produs;

        public int Id_produs
        {
            get
            {
                return id_produs;
            }
            set
            {
                id_produs = value;
                NotifyPropertyChanged("Id_produs");
            }
        }

        string nume;
        public string Nume
        {
            get
            {
                return nume;
            }
            set
            {
                nume = value;
                NotifyPropertyChanged("Nume");
            }
        }

        double pret;

        public double Pret
        {
            get
            {
                return pret;
            }
            set
            {
                pret = value;
                NotifyPropertyChanged("Pret");
            }
        }

        int cantitate;
        public int Cantitate
        {
            get
            {
                return cantitate;
            }
            set
            {
                cantitate = value;
                NotifyPropertyChanged("Cantitate");
            }
        }

        int cantitateTotala;
        public int CantitateTotala
        {
            get
            {
                return cantitateTotala;
            }
            set
            {
                cantitateTotala = value;
                NotifyPropertyChanged("CantitateTotala");
            }
        }

        string imagine;

        public string Imagine
        {
            get
            {
                return imagine;
            }
            set
            {
                imagine = value;
                NotifyPropertyChanged("Imagine");
            }
        }


        string categorie;

        public string Categorie
        {
            get
            {
                return categorie;
            }
            set
            {
                categorie = value;
                NotifyPropertyChanged("Categorie");
            }
        }

        List<string> alergeni;

        public List<string> Alergeni
        {
            get
            {
                return alergeni;
            }
            set
            {
                alergeni = value;
                NotifyPropertyChanged("Alergeni");
            }
        }

        
        public string AfisareAlergeni
        {
            get
            {
                StringBuilder s = new StringBuilder();
                if (Alergeni.Count == 0)
                {
                    s.Append("Alergeni: /");
                }
                else
                {
                    s.Append("Alergeni: ");
                    for (int i = 0; i < Alergeni.Count - 1; i++)
                    {
                        s.Append(Alergeni[i]);
                        s.Append(", ");
                    }
                    s.Append(Alergeni[Alergeni.Count - 1]);
                }
                return s.ToString();
            }

        }

        public string AfisareCantitate
        {
            get
            {
                StringBuilder s = new StringBuilder();
                if(Categorie=="Bauturi")
                {
                    s.Append("(" + Cantitate.ToString() + "ml)");
                }
                else
                {
                    s.Append("(" + Cantitate.ToString() + "g)");
                }
                
                return s.ToString();
            }

        }
    }
}
