using clientsapi.Data;
using clientsapi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace clientsapi.DAL
{
    public class ClientSituationDAL
    {
        string connection = Connection.GetConnectionString();

        public List<ClientSituation> GetClientSituations()
        {
            List<ClientSituation> clientSituations = new List<ClientSituation>();
            SqlConnection conn = new SqlConnection(connection);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ClientSituations", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        var clientSituation = new ClientSituation();
                        clientSituation.Id = Convert.ToInt32(reader["Id"]);
                        clientSituation.Description = reader["Description"].ToString();
                        clientSituations.Add(clientSituation);
                    }
                }
                return clientSituations;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            finally
            {
                conn.Close();
            }

        }
    }
}