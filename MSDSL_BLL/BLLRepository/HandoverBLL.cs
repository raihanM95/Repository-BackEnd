using MSDSL_BLL.BLLContract;
using MSDSL_DbAccessor.IRepository;
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
        public Handover CreateHandOver(Handover handover, out string errMsg)
        {
            throw new NotImplementedException();
        }

        public string DeleteHandOver(int ID, out string errMsg)
        {
            throw new NotImplementedException();
        }

        public List<Handover> GetHandoverList()
        {
            return _handoverRepository.GetHandoverList();
        }

        public Handover UpdateHandOver(Handover handover, out string errMsg)
        {
            throw new NotImplementedException();
        }
    }
}
