using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models.DataAccessLayer
{
    class ComandaDAL
    {
        internal void AddComanda(string stare, double costMancare, double costTransport, DateTime dataLivarii, TimeSpan oraLivrarii, int idUtilizator)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertComanda", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdComanda = new SqlParameter("@id_comanda", System.Data.SqlDbType.Int);
                paramIdComanda.Direction = System.Data.ParameterDirection.Output;
                SqlParameter paramStare = new SqlParameter("@stare", stare);
                SqlParameter paramCostMancare = new SqlParameter("@cost_mancare", costMancare);
                SqlParameter paramCostTransport = new SqlParameter("@cost_transport", costTransport);
                SqlParameter paramDataLivrarii = new SqlParameter("@data", dataLivarii);
                SqlParameter paramOraLivrarii = new SqlParameter("@ora_livrarii", oraLivrarii);
                SqlParameter paramIdUtilizator = new SqlParameter("@id_utilizator", idUtilizator);

                cmd.Parameters.Add(paramIdComanda);
                cmd.Parameters.Add(paramStare);
                cmd.Parameters.Add(paramCostMancare);
                cmd.Parameters.Add(paramCostTransport);
                cmd.Parameters.Add(paramDataLivrarii);
                cmd.Parameters.Add(paramOraLivrarii);
                cmd.Parameters.Add(paramIdUtilizator);
                connection.Open();
                cmd.ExecuteNonQuery();

            }
        }

        internal void AddComandaProdus(int idComanda, int idProdus, int bucati)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertComandaProdus", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdComandaProdus = new SqlParameter("@id_comanda_produs", System.Data.SqlDbType.Int);
                paramIdComandaProdus.Direction = System.Data.ParameterDirection.Output;
                SqlParameter paramIdComanda = new SqlParameter("@id_comanda", idComanda);
                SqlParameter paramIdProdus = new SqlParameter("@id_produs", idProdus);
                SqlParameter paramBucati = new SqlParameter("@bucati", bucati);

                cmd.Parameters.Add(paramIdComandaProdus);
                cmd.Parameters.Add(paramIdComanda);
                cmd.Parameters.Add(paramIdProdus);
                cmd.Parameters.Add(paramBucati);
                connection.Open();
                cmd.ExecuteNonQuery();

            }
        }

        internal void AddComandaMeniu(int idComanda, int idMeniu, int bucati)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertComandaMeniu", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdComandaProdus = new SqlParameter("@id_comanda_meniu", System.Data.SqlDbType.Int);
                paramIdComandaProdus.Direction = System.Data.ParameterDirection.Output;
                SqlParameter paramIdComanda = new SqlParameter("@id_comanda", idComanda);
                SqlParameter paramIdMeniu = new SqlParameter("@id_meniu", idMeniu);
                SqlParameter paramBucati = new SqlParameter("@bucati", bucati);

                cmd.Parameters.Add(paramIdComandaProdus);
                cmd.Parameters.Add(paramIdComanda);
                cmd.Parameters.Add(paramIdMeniu);
                cmd.Parameters.Add(paramBucati);
                connection.Open();
                cmd.ExecuteNonQuery();

            }
        }

        internal ObservableCollection<Comanda> SelectComenzileUnuiClient(int idUtilizator)
        {
            ObservableCollection<Comanda> result = new ObservableCollection<Comanda>();
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("SelectComenzileUnuiClient", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdUtilizator = new SqlParameter("@id_utilizator", idUtilizator);
                cmd.Parameters.Add(paramIdUtilizator);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int idComanda = reader.GetInt32(0);
                    string nume = reader.GetString(1);
                    string prenume = reader.GetString(2);
                    string adresa = reader.GetString(3);
                    string stare = reader.GetString(4);
                    double cost_mancare = reader.GetDouble(5);
                    double cost_transport = reader.GetDouble(6);
                    DateTime dateTime = reader.GetDateTime(7);
                    StringBuilder date = new StringBuilder();
                    date.Append(dateTime.Year.ToString() + "/" + dateTime.Month.ToString() + "/" + dateTime.Day.ToString());
                    TimeSpan timeSpan = reader.GetTimeSpan(8);
                    string time = timeSpan.ToString();
                    time = time.Substring(0, 8);
                    Comanda comanda = new Comanda(idComanda, nume, prenume, adresa, stare, cost_mancare, cost_transport, date.ToString(),time, idUtilizator);
                    result.Add(comanda);
                }
            }
            return result;
        }


        internal ObservableCollection<Comanda> SelectToateComenzile()
        {
            ObservableCollection<Comanda> result = new ObservableCollection<Comanda>();
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("SelectToateComenzile", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int idComanda = reader.GetInt32(0);
                    string nume = reader.GetString(1);
                    string prenume = reader.GetString(2);
                    string adresa = reader.GetString(3);
                    string stare = reader.GetString(4);
                    double cost_mancare = reader.GetDouble(5);
                    double cost_transport = reader.GetDouble(6);
                    DateTime dateTime = reader.GetDateTime(7);
                    StringBuilder date = new StringBuilder();
                    date.Append(dateTime.Year.ToString() + "/" + dateTime.Month.ToString() + "/" + dateTime.Day.ToString());
                    TimeSpan timeSpan = reader.GetTimeSpan(8);
                    string time = timeSpan.ToString();
                    time = time.Substring(0, 8);
                    int idUtilizator = reader.GetInt32(9);
                    Comanda comanda = new Comanda(idComanda, nume, prenume, adresa, stare, cost_mancare, cost_transport, date.ToString(), time, idUtilizator);
                    result.Add(comanda);
                }
            }
            return result;
        }
    }
}
