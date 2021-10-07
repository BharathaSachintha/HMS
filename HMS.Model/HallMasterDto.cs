using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class HallMasterDto
    {
        public String HallName { get; set; }
        public String HallDescription{ get; set; }
        public String StudentCapacity { get; set; }
        public DateTime? CreateDate { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
