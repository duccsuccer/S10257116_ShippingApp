using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10257116_HospitalApp
{
    internal class Room
    {
        public string Location { get; set; }
        public string WardClass { get; set; }
        public Room() { }
        public Room (string location, string wardClass)
        {
            Location = location;
            WardClass = wardClass;
        }
        public override string ToString()
        {
            return $"Location: {Location}, Ward Clas: {WardClass}";
        }
    }
}
