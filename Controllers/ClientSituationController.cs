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
    public class ClientSituationController : ApiController
    {
        private readonly ClientSituationRepository _clientSituationRepository;

        public ClientSituationController()
        {
            _clientSituationRepository = new ClientSituationRepository();
        }
        public IHttpActionResult Get()
        {
            IEnumerable<ClientSituation> clientSituations = _clientSituationRepository.GetClientSituations();
            return Ok(clientSituations);
        }
    }
}
