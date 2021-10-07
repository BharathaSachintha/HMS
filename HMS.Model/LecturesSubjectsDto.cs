using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class LecturesSubjectsDto
    {
        public string LectureID { get; set; }

        public string LectureName { get; set; }

        public int SubjectCatID { get; set; }

        public int SubjectID { get; set; }

        public string SubjectName { get; set; }

        public decimal PriceRate { get; set; }

        public List<LecturesSubjectssDtos> Getall { get; set; }

        public LecturesSubjectsDto()
        {
            Getall = new List<LecturesSubjectssDtos>();
        }
        public class LecturesSubjectssDtos
        {
            public string LectureID { get; set; }

            public string LectureName { get; set; }

            public int SubjectCatID { get; set; }

            public int SubjectID { get; set; }

            public string SubjectName { get; set; }

            public decimal PriceRate { get; set; }
        }
    }
}
