using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_RepoModel.Entities
{
    public class RepositoryList
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string RepositoryName { get; set; }
        public string URL { get; set; }
        public string ToolsTech { get; set; }
        public string Comments { get; set; }
        public string RepoType { get; set; }
        public string CreateDate { get; set; }
        public string LastUpdate { get; set; }
    }
}
