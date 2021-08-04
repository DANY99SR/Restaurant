using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models.BusinessLogicLayer
{
    class MeniuriBLL
    {
        public ObservableCollection<Meniuri> ListaMeniuri { get; set; }

        MeniuriDAL meniuriDAL = new MeniuriDAL();

        internal ObservableCollection<Meniuri> GetAllMeniuri()
        {
            return meniuriDAL.GetAllMeniuri();
        }

        internal ObservableCollection<Meniuri> SelectMeniuriCuAlergen(string alergen)
        {
            return meniuriDAL.SelectMeniuriCuAlergen(alergen);
        }

        internal ObservableCollection<Meniuri> SelectMeniuriFaraAlergen(string alergen)
        {
            return meniuriDAL.SelectMeniuriFaraAlergen(alergen);
        }

        internal ObservableCollection<Meniuri> SelectMeniuriCareContinNume(string n)
        {
            return meniuriDAL.SelectMeniuriCuNume(n);
        }

        internal ObservableCollection<Meniuri> SelectMeniuriCareNuContinNume(string n)
        {
            return meniuriDAL.SelectMeniuriFaraNume(n);
        }
    }
}
