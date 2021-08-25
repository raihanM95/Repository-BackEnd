using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_RepoModel.Entities
{
    public class RepoClient
    {
        [Key]
        public int RepoClientID { get; set; }
        public int RepoID { get; set; }
        [ForeignKey("RepoID")]
        public virtual RepositoryList RepositoryList { get; set; }
        public int ClientID { get; set; }
        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }

        [MaxLength(20)]
        public string Dates { get; set; }

    }
}
