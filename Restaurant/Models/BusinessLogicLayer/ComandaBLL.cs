using Restaurant.Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models.BusinessLogicLayer
{
    class ComandaBLL
    {
        ComandaDAL comandaDAL = new ComandaDAL();
        public ObservableCollection<Comanda> ListaUtilizatori { get; set; }

        internal void AddComanda(string stare, double costMancare, double costTransport, DateTime dataLivarii, TimeSpan oraLivrarii, int idUtilizator)
        {

            comandaDAL.AddComanda(stare, costMancare, costTransport, dataLivarii, oraLivrarii, idUtilizator);
        }

        internal ObservableCollection<Comanda> SelectComenzileUnuiClient(int idUtilizator)
        {
            return comandaDAL.SelectComenzileUnuiClient(idUtilizator);
        }

        internal ObservableCollection<Comanda> SelectToateComenzile()
        {
            return comandaDAL.SelectToateComenzile();
        }

        internal void AddComandaProdus(int idComanda, int idProdus, int bucati)
        {
            comandaDAL.AddComandaProdus(idComanda, idProdus, bucati);
        }

        internal void AddComandaMeniu(int idComanda, int idMeniu, int bucati)
        {
            comandaDAL.AddComandaMeniu(idComanda, idMeniu, bucati);
        }
    }
}
