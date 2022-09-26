using clientsapi.DAL;
using clientsapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clientsapi.Repository
{
    public class ClientTypeRepository
    {
        private readonly ClientTypeDAL _clientTypeDAL;

        public ClientTypeRepository()
        {
            _clientTypeDAL = new ClientTypeDAL();
        }

        public IEnumerable<ClientType> GetClientTypes()
        {
            IEnumerable<ClientType> clientTypes = _clientTypeDAL.GetClientTypes();
            return clientTypes;
        }
    }
}