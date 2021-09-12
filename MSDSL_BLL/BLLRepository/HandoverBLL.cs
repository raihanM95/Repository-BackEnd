using MSDSL_BLL.BLLContract;
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
    public class HandoverBLL : IHandoverBLL
    {
        private readonly IHandoverRepository _handoverRepository;
        public HandoverBLL(IHandoverRepository handoverRepository)
        {
            _handoverRepository = handoverRepository;
        }

        public List<Object> GetHandoverList()
        {
            return _handoverRepository.GetHandoverList();
        }

        public HandoverMap UpdateHandOver(HandoverMap handover, out string errMsg)
        {
            return _handoverRepository.UpdateHandOver(handover, out errMsg);
        }
    }
}
