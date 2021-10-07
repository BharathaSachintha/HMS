using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class SubjectMasterDto
    {
        public string getName { get; set; }
        public string getCategory { get; set; }
        public string getDescription { get; set; }
        public DateTime? CreateDate { get; set; }
        public int SubjectID { get; set; }
        public int SubjectCatID { get; set; }
        public decimal PriceRate { get; set; }
        public List<ItemListGridDto> Getall { get; set; }
        public string SubjectCatName { get; set; }
        public DateTime? ModifiedDateTime { get; set; }

        public SubjectMasterDto()
        {
            Getall = new List<ItemListGridDto>();
        }
        public class ItemListGridDto
        {
            public string getName { get; set; }
            public string getCategory { get; set; }
            public string getDescription { get; set; }
            public DateTime? CreateDate { get; set; }
            public int SubjectID { get; set; }
            public int SubjectCatID { get; set; }
            public List<SubjectMasterDto> Getall { get; set; }
            public string SubjectCatName { get; set; }
            public DateTime? ModifiedDateTime { get; set; }

        }
    }
}
