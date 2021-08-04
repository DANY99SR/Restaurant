using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    class UtilizatorDAL
    {
        internal ObservableCollection<Utilizator> GetAllUtilizatori()
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                ObservableCollection<Utilizator> result = new ObservableCollection<Utilizator>();
                SqlCommand cmd = new SqlCommand("SelectAllUtilizatori", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nume = reader.GetString(1);
                    string prenume = reader.GetString(2);
                    string mail = reader.GetString(3);
                    string tel = reader.GetString(4);
                    string adr = reader.IsDBNull(5) ? null : reader[5].ToString();

                    string par = reader.GetString(6);
                    string stat = reader.GetString(7);
                    Utilizator utilizator = new Utilizator(id, nume, prenume, mail, tel, adr, par, stat);
                    result.Add(utilizator);
                }
                return result;
            }
        }

        internal void AddClient(string n,string pren,string mail,string tel,string adr,string parl)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertClient", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdUtilizator=new SqlParameter("@id_utilizator", System.Data.SqlDbType.Int);
                paramIdUtilizator.Direction = System.Data.ParameterDirection.Output;
                SqlParameter paramNume = new SqlParameter("@nume", n);
                SqlParameter paramPrenume = new SqlParameter("@prenume", pren);
                SqlParameter paramMail = new SqlParameter("@mail", mail);
                SqlParameter paramTelefon = new SqlParameter("@telefon", tel);
                SqlParameter paramAdresa = new SqlParameter("@adresa", adr);
                SqlParameter paramParola = new SqlParameter("@parola", parl);
                SqlParameter paramStatut = new SqlParameter("@statut", "client");
                cmd.Parameters.Add(paramIdUtilizator);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramPrenume);
                cmd.Parameters.Add(paramMail);
                cmd.Parameters.Add(paramTelefon);
                cmd.Parameters.Add(paramAdresa);
                cmd.Parameters.Add(paramParola);
                cmd.Parameters.Add(paramStatut);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
