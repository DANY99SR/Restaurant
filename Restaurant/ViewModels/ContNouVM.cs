using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Restaurant.ViewModels
{
    class ContNouVM : BasePropertyChanged
    {
        UtilizatorBLL utilizatorBLL = new UtilizatorBLL();

        public ContNouVM()
        {
            ListaUtilizatori = utilizatorBLL.GetAllUtilizatori();
        }
        public ObservableCollection<Utilizator> ListaUtilizatori
        {
            get
            {
                return utilizatorBLL.ListaUtilizatori;
            }
            set
            {
                utilizatorBLL.ListaUtilizatori = value;
                NotifyPropertyChanged("ProductList");
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

        string mail;
        public string Mail
        {
            get
            {
                return mail;
            }
            set
            {
                mail = value;
                NotifyPropertyChanged("Mail");
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
        public bool CautareEmail(string email)
        {
            for(int i=0;i<ListaUtilizatori.Count;i++)
            {
                if (ListaUtilizatori[i].Email == email)
                    return true;
            }
            return false;
        }

        public bool VerificareTelefon(string telefon)
        {
            for(int i=0;i<telefon.Length;i++)
            {
                if (telefon[i] < '0' || telefon[i] > '9')
                    return false;
            }
            return true;
        }
        public void AdaugaClient(object param)
        {
            if(Nume==null || Nume==string.Empty)
            {
                MessageBox.Show("Va rugam introduceti numele!");
            }
            else if(Prenume == null||Prenume ==string.Empty)
            {
                MessageBox.Show("Va rugam introduceti prenumele!");
            }
            else if (Mail == null || Mail == string.Empty)
            {
                MessageBox.Show("Va rugam introduceti e-mail-ul!");
            }
            else if (CautareEmail(Mail))
            {
                MessageBox.Show("E-mail-ul este deja folosit, va rugam introduceti altul!");
            }
            else if (Telefon == null || Telefon == string.Empty)
            {
                MessageBox.Show("Va rugam introduceti numarul de telefon!");
            }
            else if (!VerificareTelefon(Telefon))
            {
                MessageBox.Show("Numarul de telefon trebuie sa contina doar cifre !");
            }
            else if (Adresa == null || Adresa == string.Empty)
            {
                MessageBox.Show("Va rugam introduceti adresa de livrare!");
            }
            else if (Parola == null || Parola == string.Empty)
            {
                MessageBox.Show("Va rugam alegeti o parola!");
            }
            else if(Parola.Length<4 || Parola.Length>16)
            {
                MessageBox.Show("Parola trebuie sa aibe intre 4-16 caractere");
            }
            else
            {
                utilizatorBLL.AddClient(Nume, Prenume, Mail, Telefon, Adresa, Parola);
                MessageBox.Show("Cont creat cu succes !");
            }
            
        }
        private ICommand adaugaClientNou;
        public ICommand AdaugaClientNou
        {
            get
            {
                if (adaugaClientNou == null)
                {
                    adaugaClientNou = new RelayCommand(AdaugaClient);
                }
                return adaugaClientNou;
            }
        }
    }
}
