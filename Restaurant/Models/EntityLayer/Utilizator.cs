using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Utilizator : BasePropertyChanged
    {
        public Utilizator(int id,string n_f,string pren,string mail,string tel,string adr,string psw, string st)
        {
            Id_Utilizator = id;
            NumeFamilie = n_f;
            Prenume = pren;
            Email = mail;
            Telefon = tel;
            Adresa = adr;
            Parola = psw;
            Statut = st;
        }

        int id_Utilizator;
        public int Id_Utilizator
        {
            get
            {
                return id_Utilizator;
            }
            set
            {
                id_Utilizator = value;
                NotifyPropertyChanged("Id_Utilizator");
            }
        }

        string numeFamilie;
        public string NumeFamilie
        { 
            get
            {
                return numeFamilie;
            }
            set
            {
                numeFamilie = value;
                NotifyPropertyChanged("NumeFamilie");
            }
        }

        string prenume;
        public string Prenume
        {
            get
            {
                return prenume;
            }
            set
            {
                prenume = value;
                NotifyPropertyChanged("Prenume");
            }
        }

        string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
            }
        }

        string telefon;
        public string Telefon
        {
            get
            {
                return telefon;
            }
            set
            {
                telefon = value;
                NotifyPropertyChanged("Telefon");
            }
        }

        int? a = 0;

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

        string parola;
        public string Parola
        {
            get
            {
                return parola;
            }
            set
            {
                parola = value;
                NotifyPropertyChanged("Parola");
            }
        }

        string statut;
        public string Statut
        {
            get
            {
                return statut;
            }
            set
            {
                statut = value;
                NotifyPropertyChanged("Statut");
            }
        }
    }
}
