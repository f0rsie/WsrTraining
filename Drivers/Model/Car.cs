using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Model
{
    public class Car
    {
        public int ID { get; set; }
        public int DriverID { get; set; }
        public string Number { get; set; }

        public virtual Driver Driver { get; set; }
    }
}
