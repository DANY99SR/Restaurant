using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    class ProdusDAL
    {

        private ObservableCollection<Produs> SelectAlergeniPentruProduse(List<int> id, List<string> nume, List<double> pret, List<int> cantitate, List<int> cantitate_totala, List<string> imagine, List<string> categorie)
        {
            ObservableCollection<Produs> result = new ObservableCollection<Produs>();
            for (int i = 0; i < id.Count; i++)
            {
                List<string> alergeni = new List<string>();
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand cmd = new SqlCommand("SelectAlergeniiUnuiProdus", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter paramNumeProdus = new SqlParameter("@nume", nume[i]);
                    cmd.Parameters.Add(paramNumeProdus);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        alergeni.Add(reader.GetString(0));
                    }
                }

                Produs p = new Produs(id[i], nume[i], pret[i], cantitate[i], cantitate_totala[i], imagine[i], categorie[i], alergeni);
                result.Add(p);
            }
            return result;
        }
        internal ObservableCollection<Produs> GetAllProducts()
        {
            List<int> id = new List<int>();
            List<string> nume = new List<string>();
            List<double> pret = new List<double>();
            List<int> cantitate = new List<int>();
            List<int> cantitate_totala = new List<int>();
            List<string> imagine = new List<string>();
            List<string> categorie = new List<string>();

            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("SelectAllProducts", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id.Add(reader.GetInt32(0));
                    nume.Add(reader.GetString(1));
                    pret.Add(reader.GetDouble(2));
                    cantitate.Add(reader.GetInt32(3));
                    cantitate_totala.Add(reader.GetInt32(4));
                    imagine.Add(reader.GetString(5));
                    categorie.Add(reader.GetString(6));
                }
            }
            ObservableCollection<Produs> result = SelectAlergeniPentruProduse(id, nume, pret, cantitate, cantitate_totala, imagine, categorie);
            return result;
        }

        internal void UpdateProdus(Produs produs)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateProdus", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdProdus = new SqlParameter("@id", produs.Id_produs);
                SqlParameter paramNume = new SqlParameter("@nume", produs.Nume);
                SqlParameter paramPret = new SqlParameter("@pret", produs.Pret);
                SqlParameter paramCantitate = new SqlParameter("@cantitate", produs.Cantitate);
                SqlParameter paramCantitateTotala = new SqlParameter("@cantitate_totala", produs.CantitateTotala);
                SqlParameter paramImagine = new SqlParameter("@imagine", produs.Imagine);

                cmd.Parameters.Add(paramIdProdus);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramPret);
                cmd.Parameters.Add(paramCantitate);
                cmd.Parameters.Add(paramCantitateTotala);
                cmd.Parameters.Add(paramImagine);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }


        internal ObservableCollection<Produs> SelectProduseCareContinAlergen(string alergen)
        {
            List<int> id = new List<int>();
            List<string> nume = new List<string>();
            List<double> pret = new List<double>();
            List<int> cantitate = new List<int>();
            List<int> cantitate_totala = new List<int>();
            List<string> imagine = new List<string>();
            List<string> categorie = new List<string>();

            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("SelectProduseCareAuAlergen", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramNumeAlergen = new SqlParameter("@nume_alergen", alergen);

                cmd.Parameters.Add(paramNumeAlergen);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id.Add(reader.GetInt32(0));
                    nume.Add(reader.GetString(1));
                    pret.Add(reader.GetDouble(2));
                    cantitate.Add(reader.GetInt32(3));
                    cantitate_totala.Add(reader.GetInt32(4));
                    imagine.Add(reader.GetString(5));
                    categorie.Add(reader.GetString(6));
                }
            }
            ObservableCollection<Produs> result = SelectAlergeniPentruProduse(id, nume, pret, cantitate, cantitate_totala, imagine, categorie);
            return result;
        }

        internal ObservableCollection<Produs> SelectProduseCareNuContinAlergen(string alergen)
        {
            List<int> id = new List<int>();
            List<string> nume = new List<string>();
            List<double> pret = new List<double>();
            List<int> cantitate = new List<int>();
            List<int> cantitate_totala = new List<int>();
            List<string> imagine = new List<string>();
            List<string> categorie = new List<string>();

            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("SelectProduseCareNuAuAlergen", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramNumeAlergen = new SqlParameter("@nume_alergen", alergen);

                cmd.Parameters.Add(paramNumeAlergen);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id.Add(reader.GetInt32(0));
                    nume.Add(reader.GetString(1));
                    pret.Add(reader.GetDouble(2));
                    cantitate.Add(reader.GetInt32(3));
                    cantitate_totala.Add(reader.GetInt32(4));
                    imagine.Add(reader.GetString(5));
                    categorie.Add(reader.GetString(6));
                }
            }
            ObservableCollection<Produs> result = SelectAlergeniPentruProduse(id, nume, pret, cantitate, cantitate_totala, imagine, categorie);
            return result;
        }


        internal ObservableCollection<Produs> SelectProduseCareContinNume(string n)
        {
            List<int> id = new List<int>();
            List<string> nume = new List<string>();
            List<double> pret = new List<double>();
            List<int> cantitate = new List<int>();
            List<int> cantitate_totala = new List<int>();
            List<string> imagine = new List<string>();
            List<string> categorie = new List<string>();

            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("SelectProduseCareContinNume", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@nume", n);

                cmd.Parameters.Add(paramNume);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id.Add(reader.GetInt32(0));
                    nume.Add(reader.GetString(1));
                    pret.Add(reader.GetDouble(2));
                    cantitate.Add(reader.GetInt32(3));
                    cantitate_totala.Add(reader.GetInt32(4));
                    imagine.Add(reader.GetString(5));
                    categorie.Add(reader.GetString(6));
                }
            }
            ObservableCollection<Produs> result = SelectAlergeniPentruProduse(id, nume, pret, cantitate, cantitate_totala, imagine, categorie);
            return result;
        }

        internal ObservableCollection<Produs> SelectProduseCareNuContinNume(string n)
        {
            List<int> id = new List<int>();
            List<string> nume = new List<string>();
            List<double> pret = new List<double>();
            List<int> cantitate = new List<int>();
            List<int> cantitate_totala = new List<int>();
            List<string> imagine = new List<string>();
            List<string> categorie = new List<string>();

            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("SelectProduseCareNuContinNume", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@nume", n);

                cmd.Parameters.Add(paramNume);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id.Add(reader.GetInt32(0));
                    nume.Add(reader.GetString(1));
                    pret.Add(reader.GetDouble(2));
                    cantitate.Add(reader.GetInt32(3));
                    cantitate_totala.Add(reader.GetInt32(4));
                    imagine.Add(reader.GetString(5));
                    categorie.Add(reader.GetString(6));
                }
            }
            ObservableCollection<Produs> result = SelectAlergeniPentruProduse(id, nume, pret, cantitate, cantitate_totala, imagine, categorie);
            return result;
        }
    }
}
