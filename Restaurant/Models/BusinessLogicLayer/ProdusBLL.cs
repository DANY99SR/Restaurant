using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    class ProdusBLL
    {
        public ObservableCollection<Produs> ProductList { get; set; }

        ProdusDAL productDAL = new ProdusDAL();

        internal ObservableCollection<Produs> GetAllProducts()
        {
            return productDAL.GetAllProducts();
        }

        internal void UpdateProdus(Produs produs)
        {
            productDAL.UpdateProdus(produs);
        }

        internal ObservableCollection<Produs> SelectProduseCareAuAlergen(string alergen)
        {
            return productDAL.SelectProduseCareContinAlergen(alergen);
        }

        internal ObservableCollection<Produs> SelectProduseCareNuAuAlergen(string alergen)
        {
            return productDAL.SelectProduseCareNuContinAlergen(alergen);
        }

        internal ObservableCollection<Produs> SelectProduseCareContinNume(string s)
        {
            return productDAL.SelectProduseCareContinNume(s);
        }

        internal ObservableCollection<Produs> SelectProduseCareNuContinNume(string s)
        {
            return productDAL.SelectProduseCareNuContinNume(s);
        }
    }
}
