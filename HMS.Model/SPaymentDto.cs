using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class SPaymentDto
    {
        public int ID { get; set; }
        public String StudentID { get; set; }
        public String StudentName { get; set; }
        public int SubjectID { get; set; }

        public String LecturerID { get; set; }
        public string SubjectName { get; set; }
        public String Payment { get; set; }
        public DateTime? PaymentDate { get; set; }
        public String PaymentYear { get; set; }
        public String PaymentMonth { get; set; }

        public int PaymentStatus { get; set; }

        public int LectureStatus { get; set; }

        public DateTime LastTransactionDate { get; set; }
        public double PriceRate { get; set; }

    }
}
