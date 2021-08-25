using MSDSL_RepoModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_RepoModel.Dtos
{
    public class RepoClientMap
    {
        public RepoClient RepoClient { get; set; }
        public IEnumerable<Client> Client { get; set; }
        public IEnumerable<RepositoryList> RepositoryList { get; set; }
    }
}
