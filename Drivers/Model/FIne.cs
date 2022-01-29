using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Model
{
    public class FIne
    {
        public int ID { get; set; }
        public int DataID { get; set; }
        public bool Success { get; set; }

        public virtual Data Data { get; set; }
    }
}
