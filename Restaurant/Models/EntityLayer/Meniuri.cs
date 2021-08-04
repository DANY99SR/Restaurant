using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    class Meniuri : BasePropertyChanged
    {
        public Meniuri(int id, string n,List<Produs> prod,double p, string img, string cat, List<string> al)
        {
            Id_meniu = id;
            Nume = n;
            Produse = prod;
            Pret = p;
            Imagine = img;
            Categorie = cat;
            Alergeni = al;
        }


        int id_meniu;

        public int Id_meniu
        {
            get
            {
                return id_meniu;
            }
            set
            {
                id_meniu = value;
                NotifyPropertyChanged("Id_meniu");
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

        List<Produs> produse;

        public List<Produs> Produse
        {
            get
            {
                return produse;
            }
            set
            {
                produse = value;
                NotifyPropertyChanged("Produse");
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
                s.Append("(");
                for (int i = 0; i < Produse.Count - 1; i++)
                {
                    s.Append(Produse[i].Cantitate.ToString()+"g "+ Produse[i].Nume);
                    s.Append(", ");
                }
                s.Append(Produse[Produse.Count - 1].Cantitate.ToString()+"ml "+ Produse[Produse.Count - 1].Nume + ")");
                return s.ToString();
            }

        }
    }
}
