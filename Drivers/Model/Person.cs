using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Model
{
    public class Person
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public int PassportInfoID { get; set; }
        public int RegistrationAddressID { get; set; }
        public int LifeAddressID { get; set; }

        public virtual Address Address { get; set; }
        public virtual Address Address1 { get; set; }
        public virtual PassportInfo PassportInfo { get; set; }
    }
}
