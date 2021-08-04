using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ViewModels
{
    class LogInVM : BasePropertyChanged
    {
        UtilizatorBLL utilizatorBLL = new UtilizatorBLL();
        public LogInVM()
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
    }
}
