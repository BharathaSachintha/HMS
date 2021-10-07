using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class StudentMasterDto
    {
        public String RFID { get; set; }
        public String Initials { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Address { get; set; }
        public String GuardianName { get; set; }
        public int ContactNo { get; set; }
        public String SchoolName { get; set; }
        public String SubjectID { get; set; }
        public String StudCategory { get; set; }
        public DateTime? CreateDate { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
