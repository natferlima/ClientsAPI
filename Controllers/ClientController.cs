using clientsapi.DAL;
using clientsapi.Models;
using clientsapi.Repository;
using clientsapi.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace clientsapi.Controllers
{
    public class ClientController : ApiController
    {
        private readonly ClientRepository _clientRepository;
        private readonly ClientValidator _clientValidator;

        public ClientController()
        {
            _clientRepository = new ClientRepository();
            _clientValidator = new ClientValidator();
        }
        public IHttpActionResult Get()
        {
            IEnumerable<Client> clients = _clientRepository.GetClients();
            return Ok(clients);
        }

        public IHttpActionResult Post(Client client)
        {
            Validation validation = _clientValidator.ValidatorAdd(client);
            if(validation.Error != null)
            {
                return BadRequest(validation.Error);
            }
            Validation result = _clientRepository.Add(client);
            if(result.Error != null)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Message);
        }

        public IHttpActionResult Delete(string id)
        {
            Validation validation = _clientRepository.Remove(id);
            if(validation.Error != null)
            {
                return BadRequest(validation.Error);
            }
            return Ok(validation.Message);
        }

        public IHttpActionResult Get(string id)
        {
            Client client = _clientRepository.GetClientById(id);
            if(client == null || client.Id == 0)
            {
                return BadRequest("Cliente não encontrado.");
            }
            return Ok(client);
        }

        public IHttpActionResult Put(Client client)
        {
            Validation validation = _clientRepository.Update(client);

            if(validation.Error != null)
            {
                return BadRequest(validation.Error);
            }

            return Ok(validation.Message);
        }
    }
}
