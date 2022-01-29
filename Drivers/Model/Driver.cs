using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Model
{
    public class Driver
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public int JobInfoID { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
        public string Description { get; set; }

        public virtual JobInfo JobInfo { get; set; }
        public virtual Person Person { get; set; }
    }
}
