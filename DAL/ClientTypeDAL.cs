using clientsapi.Data;
using clientsapi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace clientsapi.DAL
{
    public class ClientTypeDAL
    {
        string connection = Connection.GetConnectionString();

        public List<ClientType> GetClientTypes()
        {
            List<ClientType> clientTypes = new List<ClientType>();
            SqlConnection conn = new SqlConnection(connection);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ClientTypes", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        var clientType = new ClientType();
                        clientType.Id = Convert.ToInt32(reader["Id"]);
                        clientType.Description = reader["Description"].ToString();
                        clientTypes.Add(clientType);
                    }
                }
                return clientTypes;
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