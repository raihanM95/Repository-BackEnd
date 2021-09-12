using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_RepoModel.Dtos
{
    public class HandoverMap
    {
        public int ID { get; set; }
        public int New_Dev { get; set; }
        public string NewDate { get; set; }
        public bool IsFirstAssign { get; set; }
        public int repoID { get; set; }
        public int devID { get; set; }
    }
}
