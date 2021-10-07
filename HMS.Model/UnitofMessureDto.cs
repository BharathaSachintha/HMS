using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class UnitofMessureDto
    {
        public int UomID { get; set; }

        public string Major { get; set; }

        public string Minor { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
