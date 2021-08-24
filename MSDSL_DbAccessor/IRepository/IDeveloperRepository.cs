using MSDSL_RepoModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_DbAccessor.IRepository
{
    public interface IDeveloperRepository
    {

        ICollection<Developer> GetDevelopers();
        Developer GetDeveloper(string developerName, out string errMsg);
        Developer GetDeveloperById(int developerId, out string errMsg);
        Developer CreateDeveloper(Developer developer, out string msg);
        Developer UpdateDeveloper(Developer developer);
        int DeleteDeveloper(int developerID, out string errMsg);
        bool IsUniqueDeveloper(string DeveloperName);
    }
}
