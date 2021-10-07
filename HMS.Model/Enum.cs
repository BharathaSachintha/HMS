using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class Enum
    {
        public enum PaymentMode
        {
            NotPaid = 1,
            Paid = 2
        }
    }
    public enum DataEntryMode
    {
        Add = 1,
        View = 2,
        Edit = 3,
        pageLoad = 600
    }
}
