using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class LecturePaymentDto
    {
        public string LectureID { get; set; }

        public int SubjectID { get; set; }

        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public DateTime? TransactionDate { get; set; }
    }
}
