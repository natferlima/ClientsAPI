using clientsapi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace clientsapi.DAL
{
    public class ClientDAL
    {
        string connection = @"Data Source=LIMA\SQLEXPRESS;Initial Catalog=ClientsAPI;Integrated Security=True";

        public List<Client> GetClients()
        {
            List<Client> clients = new List<Client>();
            SqlConnection conn = new SqlConnection(connection);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Clients", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        var client = new Client();
                        client.Id = Convert.ToInt32(reader["Id"]);
                        client.Name = reader["Name"].ToString();
                        client.CPF = reader["CPF"].ToString();
                        client.Gender = reader["Gender"].ToString();
                        client.IdType = Convert.ToInt32(reader["IdType"]);
                        client.IdSituation = Convert.ToInt32(reader["IdSituation"]);
                        clients.Add(client);
                    }
                }
                return clients;
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

        public void Add(Client obj)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "Insert into Clientes (name, cpf, gender, idtype, idsituation) values (@name, @cpf, @gender, @idtype, @idsituation);select @@IDENTITY;";
                cmd.Parameters.AddWithValue("name", obj.Name);
                cmd.Parameters.AddWithValue("cpf", obj.CPF);
                cmd.Parameters.AddWithValue("gender", obj.Gender);
                cmd.Parameters.AddWithValue("idtype", obj.IdType);
                cmd.Parameters.AddWithValue("idsituation", obj.IdSituation);
                conn.Open();
                cmd.ExecuteScalar();
                //obj.Id = Convert.ToInt32(cmd.ExecuteScalar());
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

        public void Update(Client obj)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "update Clients set name=@name, cpf=@cpf, gender=@gender, idtype=@idtype, idsituation=@idsituation where id = @id;";
                cmd.Parameters.AddWithValue("id", obj.Id);
                cmd.Parameters.AddWithValue("name", obj.Name);
                cmd.Parameters.AddWithValue("cpf", obj.CPF);
                cmd.Parameters.AddWithValue("gender", obj.Gender);
                cmd.Parameters.AddWithValue("idtype", obj.IdType);
                cmd.Parameters.AddWithValue("idsituation", obj.IdSituation);
                conn.Open();
                cmd.ExecuteNonQuery();
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

        public void Remove(string id)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "delete from Clients where id = " + id;
                conn.Open();
                cmd.ExecuteNonQuery();
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

        public Client GetClientById(string id)
        {
            Client obj = new Client();
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {
                cmd.CommandText = "select * from clients where id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    obj.Id = Convert.ToInt32(reader["id"]);
                    obj.Name = reader["name"].ToString();
                    obj.CPF = reader["cpf"].ToString();
                    obj.Gender = reader["gender"].ToString();
                    obj.IdType = Convert.ToInt32(reader["idtype"]);
                    obj.IdSituation = Convert.ToInt32(reader["idSituation"]);
                }
                return obj;
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