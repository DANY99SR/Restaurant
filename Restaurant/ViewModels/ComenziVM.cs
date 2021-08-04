using Restaurant.Models;
using Restaurant.Models.BusinessLogicLayer;
using Restaurant.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ViewModels
{
    class ComenziVM : BasePropertyChanged
    {
        ComandaBLL comandaBLL = new ComandaBLL();
        public ComenziVM()
        {
            if(Meniu.utilizatorCurent.Statut=="client")
            {
                Comenzi = comandaBLL.SelectComenzileUnuiClient(Meniu.utilizatorCurent.Id_Utilizator);
            }
            else
            {
                Comenzi = comandaBLL.SelectToateComenzile();
            }
            
        }

        ObservableCollection<Comanda> comenzi;

        public ObservableCollection<Comanda> Comenzi
        {
            get
            {
                return comenzi;
            }
            set
            {
                comenzi = value;
                NotifyPropertyChanged("Comenzi");
            }

        }
    }
}
