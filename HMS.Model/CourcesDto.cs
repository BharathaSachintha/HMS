using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class CourcesDto
    {
        public string RFID { get; set; }

        public int LectureID { get; set; }

        public int SubjectCatID { get; set; }

        public int SubjectID { get; set; }

        public decimal PriceRate { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime LastTransactionDate { get; set; }

        public int PaymentStatus { get; set; }
    }
}
