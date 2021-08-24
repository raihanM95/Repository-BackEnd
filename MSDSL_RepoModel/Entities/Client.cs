using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_RepoModel.Entities
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        [Required]
        public string Client_Name { get; set; }
    }
}
