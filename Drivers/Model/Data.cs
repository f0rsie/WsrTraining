using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Model
{
    public class Data
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public string Region { get; set; }
        public string LicenseNumber { get; set; }
        public System.DateTime CreationDate { get; set; }
        public byte[] Photo { get; set; }

        public virtual Car Car { get; set; }
    }
}
