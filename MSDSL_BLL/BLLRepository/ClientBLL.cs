using AutoMapper;
using MSDSL_DbAccessor.IRepository;
using MSDSL_RepoModel.Dtos;
using MSDSL_RepoModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_BLL.BLLRepository
{
    public class ClientBLL : IClientBLL
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;

        public ClientBLL(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }
        public ClientMap CreateClient(ClientMap client, out string msg)
        {            
            bool isClientExist = _clientRepository.IsUniqueClient(client.Client_Name);
            if (isClientExist)
            {
                msg = "Client already exist";
                return null;
            }
            Client clientObj = _mapper.Map<Client>(client);
            var ObjData= _clientRepository.CreateClient(clientObj,out msg);
            return _mapper.Map<ClientMap>(ObjData);

        }

        public int DeleteClient(int clientID, out string errMsg)
        {
            return   _clientRepository.DeleteClient(clientID,out errMsg);
        }


        public ClientMap GetClient(string clientName, out string errMsg)
        {
            return _mapper.Map<ClientMap>(
               _clientRepository.GetClient(clientName,out errMsg));
        }
        public ClientMap GetClientById(int clientId, out string errMsg)
        {
            return _mapper.Map<ClientMap>(
               _clientRepository.GetClientById(clientId, out errMsg));
        }

        public ICollection<ClientMap> GetClients(out string errMsg)
        {
            errMsg = string.Empty;
            var ObjResult = _clientRepository.GetClients();
            if(ObjResult == null)
            {
                errMsg = "No data found.";
                return null;
            }
            return _mapper.Map<List<ClientMap>>(
               ObjResult);
        }


        public bool IsUniqueClient(string ClientName)
        {
            return _clientRepository.IsUniqueClient(ClientName);
        }

        public ClientMap UpdateClient(ClientMap client)
        {
            Client clientObj = _mapper.Map<Client>(client);
            var ObjData = _clientRepository.UpdateClient(clientObj);
            return _mapper.Map<ClientMap>(ObjData);
        }
    }
}
