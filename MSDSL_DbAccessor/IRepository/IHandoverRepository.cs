using MSDSL_RepoModel.Dtos;
using MSDSL_RepoModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_DbAccessor.IRepository
{
    public interface IHandoverRepository
    {
        List<Object> GetHandoverList();
        HandoverMap UpdateHandOver(HandoverMap handover, out string errMsg);
    }
}
