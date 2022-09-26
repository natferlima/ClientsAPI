using clientsapi.DAL;
using clientsapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clientsapi.Repository
{
    public class ClientSituationRepository
    {
        private readonly ClientSituationDAL _clientSituationDAL;

        public ClientSituationRepository()
        {
            _clientSituationDAL = new ClientSituationDAL();
        }

        public IEnumerable<ClientSituation> GetClientSituations()
        {
            IEnumerable<ClientSituation> clientSituations = _clientSituationDAL.GetClientSituations();
            return clientSituations;
        }
    }
}