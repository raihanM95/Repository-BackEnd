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
        List<Handover> GetHandoverList();
        string DeleteHandOver(int ID, out string errMsg);
        Handover CreateHandOver(Handover handover, out string errMsg);
        Handover UpdateHandOver(Handover handover, out string errMsg);
    }
}
