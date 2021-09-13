using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_Utilities.Common
{
    public class BaseModel
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int Version { get; set; }
    }
}
