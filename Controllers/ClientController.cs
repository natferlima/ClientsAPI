using clientsapi.DAL;
using clientsapi.Models;
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
        private readonly ClientDAL _clientDAL;

        public ClientController()
        {
            _clientDAL = new ClientDAL();
        }
        public IHttpActionResult Get()
        {
            IEnumerable<Client> clients = _clientDAL.GetClients();
            return Ok(clients);
        }

        public IHttpActionResult Post(Client client)
        {
            _clientDAL.Add(client);
            return Ok();
        }

        public IHttpActionResult Delete(string id)
        {
            _clientDAL.Remove(id);
            return Ok();
        }

        public IHttpActionResult Get(string id)
        {
            Client client = _clientDAL.GetClientById(id);
            return Ok(client);
        }

        public IHttpActionResult Put(Client client)
        {
            _clientDAL.Update(client);
            return Ok();
        }
    }
}
