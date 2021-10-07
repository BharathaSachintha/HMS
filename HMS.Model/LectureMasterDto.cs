using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class LectureMasterDto
    {
        public String FirstName { get; set; }
        public String Title { get; set; }

        public String Initials { get; set; }
        public String LastName { get; set; }

        public String Address { get; set; }
        public int LecturerID { get; set; }
        public decimal Rate { get; set; }

        public int NICNo { get; set; }

        public String ContactNo { get; set; }

        public String Email { get; set; }
        public int LecturerRate { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
