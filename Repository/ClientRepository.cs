using clientsapi.DAL;
using clientsapi.Models;
using clientsapi.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clientsapi.Repository
{
    public class ClientRepository
    {
        private readonly ClientDAL _clientDAL;

        public ClientRepository()
        {
            _clientDAL = new ClientDAL();
        }

        public IEnumerable<ClientDTO> GetClients()
        {
            IEnumerable<ClientDTO> clients = _clientDAL.GetClients();
            return clients;
        }

        public Client GetClientById(string id)
        {
            Client client = _clientDAL.GetClientById(id);
            return client;
        }

        public Validation Add(Client client)
        {
            Validation validation = new Validation();
            try
            {
                _clientDAL.Add(client);
                validation.Message = "Cliente cadastrado com sucesso!";
                return validation;
            }
            catch(Exception)
            {
                validation.Error = "Não foi possível realizar o cadastro.";
                return validation;
                
            }

        }

        public Validation Remove(string id)
        {
            Validation validation = new Validation();
            Client client = _clientDAL.GetClientById(id);
            if(client == null || client.Id == 0)
            {
                validation.Error = "Cliente não encontrado";
                return validation;
            }
            _clientDAL.Remove(id);
            validation.Message = "Cliente removido com sucesso.";
            return validation;
        }

        public Validation Update(string id, Client client)
        {
            Validation validation = new Validation();
            try
            {
                Client getClient = _clientDAL.GetClientById(id);
                if(getClient == null || getClient.Id == 0)
                {
                    validation.Error = "Cliente não encontrado.";
                    return validation;
                }
                client.Id = Convert.ToInt32(id);
                _clientDAL.Update(client);
                validation.Message = "Cliente atualizado com sucesso!";
                return validation;
            }
            catch (Exception)
            {
                validation.Error = "Não foi possível atualizar as informações.";
                return validation;

            }
        }
    }
}