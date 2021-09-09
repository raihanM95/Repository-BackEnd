using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_RepoModel.Entities
{
    public class Handover
    {
        [Key]
        public int ID { get; set; }
        public string ProjectID { get; set; }
        public string Prev_dev { get; set; }
        public string New_Dev { get; set; }
        public string Date { get; set; }
        public string AssignDate { get; set; }
        public int RepoID { get; set; }
        [ForeignKey(nameof(RepoID))]
        public virtual RepositoryList RepositoryList { get; set; }
        public int DevID { get; set; }
        [ForeignKey(nameof(DevID))]
        public virtual Developer Developer { get; set; }
    }
}
