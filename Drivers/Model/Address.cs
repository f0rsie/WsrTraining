using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Model
{
    public class Address
    {
        public int ID { get; set; }
        public int CityID { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }

        public virtual City City { get; set; }
    }
}
