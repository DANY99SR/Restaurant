using Restaurant.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    class MeniuriDAL
    {
        private ObservableCollection<Meniuri> SelectProduseleMeniului(List<int> id_meniu, List<string> nume_meniu, List<string> imagine_meniu, List<string> categorie_meniu)
        {
            ObservableCollection<Meniuri> result = new ObservableCollection<Meniuri>();
            for (int i = 0; i < id_meniu.Count; i++)
            {
                List<int> id_produs = new List<int>();
                List<string> nume_produs = new List<string>();
                List<double> pret_produs = new List<double>();
                List<int> cantitate_produs = new List<int>();
                List<int> cantitate_totala_produs = new List<int>();
                List<string> imagine_produs = new List<string>();
                List<string> categorie_produs = new List<string>();

                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand cmd = new SqlCommand("SelectProdusePentruMeniu", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter idMeniu = new SqlParameter("@id_meniu", id_meniu[i]);
                    cmd.Parameters.Add(idMeniu);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id_produs.Add(reader.GetInt32(0));
                        Console.WriteLine(reader.GetFieldType(1).ToString());
                        pret_produs.Add(reader.GetInt32(1));
                        cantitate_produs.Add(reader.GetInt32(2));
                        nume_produs.Add(reader.GetString(3));
                        imagine_produs.Add(reader.GetString(4));
                        cantitate_totala_produs.Add(reader.GetInt32(5));
                        categorie_produs.Add(reader.GetString(6));
                    }
                }

                List<Produs> produse_meniu = new List<Produs>();
                for (int j = 0; j < id_produs.Count; j++)
                {
                    List<string> alergeni = new List<string>();
                    using (SqlConnection connection = DALHelper.Connection)
                    {
                        SqlCommand cmd = new SqlCommand("SelectAlergeniiUnuiProdus", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter paramNumeProdus = new SqlParameter("@nume", nume_produs[j]);
                        cmd.Parameters.Add(paramNumeProdus);
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            alergeni.Add(reader.GetString(0));
                        }
                    }

                    Produs p = new Produs(id_produs[j], nume_produs[j], pret_produs[j], cantitate_produs[j], cantitate_totala_produs[j], imagine_produs[j], categorie_produs[j], alergeni);
                    produse_meniu.Add(p);
                }
                List<string> al = new List<string>();
                double pret = 0;
                for (int j = 0; j < produse_meniu.Count; j++)
                {
                    pret += produse_meniu[j].Pret;
                    List<string> aux = produse_meniu[j].Alergeni;
                    for (int k = 0; k < aux.Count; k++)
                    {
                        bool gasit = false;
                        for (int x = 0; x < al.Count; x++)
                        {
                            if (aux[k] == al[x])
                                gasit = true;
                        }

                        if (!gasit)
                        {
                            al.Add(aux[k]);
                        }
                    }
                }
                int reducere = Convert.ToInt32(ConfigurationManager.AppSettings["reducereMeniu"]);
                pret = pret - (pret * reducere) / 100;
                Meniuri m = new Meniuri(id_meniu[i], nume_meniu[i], produse_meniu, pret, imagine_meniu[i], categorie_meniu[i], al);
                result.Add(m);
            }

            return result;
        }
        internal ObservableCollection<Meniuri> GetAllMeniuri()
        {
            List<int> id_meniu = new List<int>();
            List<string> nume_meniu = new List<string>();
            List<string> imagine_meniu = new List<string>();
            List<string> categorie_meniu = new List<string>();

            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("SelectAllMeniuri", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id_meniu.Add(reader.GetInt32(0));
                    nume_meniu.Add(reader.GetString(1));
                    imagine_meniu.Add(reader.GetString(2));
                    categorie_meniu.Add(reader.GetString(3));
                }
            }

            ObservableCollection<Meniuri> result = SelectProduseleMeniului(id_meniu, nume_meniu, imagine_meniu, categorie_meniu);

            return result;
        }

        internal ObservableCollection<Meniuri> SelectMeniuriCuAlergen(string alergen)
        {
            List<int> id_meniu = new List<int>();
            List<string> nume_meniu = new List<string>();
            List<double> pret_meniu = new List<double>();
            List<string> imagine_meniu = new List<string>();
            List<string> categorie_meniu = new List<string>();

            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("SelectMeniuriCareAuAlergen", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramNumeAlergen = new SqlParameter("@nume_alergen", alergen);

                cmd.Parameters.Add(paramNumeAlergen);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id_meniu.Add(reader.GetInt32(0));
                    nume_meniu.Add(reader.GetString(1));
                    imagine_meniu.Add(reader.GetString(2));
                    categorie_meniu.Add(reader.GetString(3));
                }
            }

            ObservableCollection<Meniuri> result = SelectProduseleMeniului(id_meniu, nume_meniu, imagine_meniu, categorie_meniu);

            return result;
        }

        internal ObservableCollection<Meniuri> SelectMeniuriFaraAlergen(string alergen)
        {
            List<int> id_meniu = new List<int>();
            List<string> nume_meniu = new List<string>();
            List<double> pret_meniu = new List<double>();
            List<string> imagine_meniu = new List<string>();
            List<string> categorie_meniu = new List<string>();

            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("SelectMeniuriCareNuAuAlergen", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramNumeAlergen = new SqlParameter("@nume_alergen", alergen);

                cmd.Parameters.Add(paramNumeAlergen);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id_meniu.Add(reader.GetInt32(0));
                    nume_meniu.Add(reader.GetString(1));
                    imagine_meniu.Add(reader.GetString(2));
                    categorie_meniu.Add(reader.GetString(3));
                }
            }

            ObservableCollection<Meniuri> result = SelectProduseleMeniului(id_meniu, nume_meniu, imagine_meniu, categorie_meniu);

            return result;
        }



        internal ObservableCollection<Meniuri> SelectMeniuriCuNume(string n)
        {
            List<int> id_meniu = new List<int>();
            List<string> nume_meniu = new List<string>();
            List<double> pret_meniu = new List<double>();
            List<string> imagine_meniu = new List<string>();
            List<string> categorie_meniu = new List<string>();

            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("SelectMeniuriCareContinNume", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@nume", n);

                cmd.Parameters.Add(paramNume);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id_meniu.Add(reader.GetInt32(0));
                    nume_meniu.Add(reader.GetString(1));
                    imagine_meniu.Add(reader.GetString(2));
                    categorie_meniu.Add(reader.GetString(3));
                }
            }

            ObservableCollection<Meniuri> result = SelectProduseleMeniului(id_meniu, nume_meniu, imagine_meniu, categorie_meniu);

            return result;
        }


        internal ObservableCollection<Meniuri> SelectMeniuriFaraNume(string n)
        {
            List<int> id_meniu = new List<int>();
            List<string> nume_meniu = new List<string>();
            List<double> pret_meniu = new List<double>();
            List<string> imagine_meniu = new List<string>();
            List<string> categorie_meniu = new List<string>();

            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("SelectMeniuriCareNuContinNume", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@nume", n);

                cmd.Parameters.Add(paramNume);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id_meniu.Add(reader.GetInt32(0));
                    nume_meniu.Add(reader.GetString(1));
                    imagine_meniu.Add(reader.GetString(2));
                    categorie_meniu.Add(reader.GetString(3));
                }
            }

            ObservableCollection<Meniuri> result = SelectProduseleMeniului(id_meniu, nume_meniu, imagine_meniu, categorie_meniu);

            return result;
        }
    }
}
