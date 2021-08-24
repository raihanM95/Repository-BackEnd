using MSDSL_RepoModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_BLL.BLLContract
{
    public interface IDeveloperBLL
    {
        ICollection<DeveloperMap> GetDevelopers(out string errMsg);
        DeveloperMap GetDeveloper(string developerName, out string errMsg);
        DeveloperMap GetDeveloperById(int developerId, out string errMsg);
        DeveloperMap CreateDeveloper(DeveloperMap developer, out string msg);
        DeveloperMap UpdateDeveloper(DeveloperMap developer);
        int DeleteDeveloper(int developerID, out string errMsg);
        bool IsUniqueDeveloper(string DeveloperName);
    }
}
