using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class ClassMasterDto
    {
        public String LecturerID { get; set; }
        public String LectureName { get; set; }
        public String SubjectID { get; set; }
        public String SubjectName { get; set; }
        public String ClassCode { get; set; }
        public String Description { get; set; }
        public String Category { get; set; }
        public String Type { get; set; }
        public DateTime StartDate { get; set; }
        public decimal AdmissionFee { get; set; }
        public decimal MonthlyFee { get; set; }
        public String DateOfConduct { get; set; }
        public String StartTime { get; set; }
        public String EndTime { get; set; }
        public DateTime? CreateDate { get; set; }
        public Int64 classID { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
