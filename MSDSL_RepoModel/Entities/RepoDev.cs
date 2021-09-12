using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_RepoModel.Entities
{
    public class RepoDev
    {
        [Key]
        public int ID { get; set; }
        public bool IsFirstAssign { get; set; }
        public string AssignDate { get; set; }
        public string AssignFrom { get; set; }
        public string NewDev { get; set; }
        public string PrevDev { get; set; }
        public string NewDate { get; set; }
        public int RepoID { get; set; }
        [ForeignKey(nameof(RepoID))]
        public virtual RepositoryList RepositoryList { get; set; }
        public int DevID { get; set; }
        [ForeignKey(nameof(DevID))]
        public virtual Developer Developer { get; set; }
    }
}
