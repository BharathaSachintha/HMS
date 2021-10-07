using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class HallAllocationMasterDto
    {
        public String HallID { get; set; }

        public String HallName { get; set; }

        public String ClassID { get; set; }
        public String ClassName { get; set; }
        public DateTime ScheduleDate { get; set; }

        public String StartTime { get; set; }

        public String EndTime { get; set; }
        public DateTime? CreateDate { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
