using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    class UtilizatorBLL
    {
        public ObservableCollection<Utilizator> ListaUtilizatori { get; set; }

        UtilizatorDAL utilizatorDAL = new UtilizatorDAL();

        internal ObservableCollection<Utilizator> GetAllUtilizatori()
        {
            return utilizatorDAL.GetAllUtilizatori();
        }

        internal void AddClient(string n, string pren, string mail, string tel, string adr, string parl)
        {
            utilizatorDAL.AddClient(n, pren, mail, tel, adr, parl);
        }
    }
}
