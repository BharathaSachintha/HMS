using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class InvProductDto
    {
        public string ProductID { get; set; }

        public string ProductName { get; set; }

        public int UomID { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
