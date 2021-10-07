using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class ReceivedPaymentsDto
    {
        public String StudentId { get; set; }
        public int SubjectId { get; set; }
        public String LecturerId { get; set; }
        public string SubjectName { get; set; }
        public String LectureName { get; set; }
        public double topayment { get; set; }
        public double PriceRate { get; set; }
        public double toPay { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int id { get; set; }
        public int LectureStatus { get; set; }
    }
}
