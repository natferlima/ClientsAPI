using clientsapi.Models;
using clientsapi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace clientsapi.Controllers
{
    public class ClientTypeController : ApiController
    {
        private readonly ClientTypeRepository _clientTypeRepository;

        public ClientTypeController()
        {
            _clientTypeRepository = new ClientTypeRepository();
        }
        public IHttpActionResult Get()
        {
            IEnumerable<ClientType> clientTypes = _clientTypeRepository.GetClientTypes();
            return Ok(clientTypes);
        }
    }
}
