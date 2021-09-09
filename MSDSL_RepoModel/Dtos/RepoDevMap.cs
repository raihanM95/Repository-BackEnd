using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_RepoModel.Dtos
{
    public class RepoDevMap
    {
        public int ID { get; set; }
        public bool IsFirstAssign { get; set; }
        public string AssignDate { get; set; }
        public string AssignFrom { get; set; }
        public int RepoID { get; set; }
        public int DevID { get; set; }
    }
}
