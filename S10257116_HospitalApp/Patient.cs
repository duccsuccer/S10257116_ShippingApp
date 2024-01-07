using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10257116_HospitalApp
{
    internal class Patient : Person
    {
        public Room WardedAt { get; set; }
        public Patient() { }
        public Patient(string nric, string name, Room wardedat) : base(nric, name)
        {
            WardedAt = wardedat;
        }
        public override string ToString()
        {
            return base.ToString() + $" Warded At: {WardedAt}";
        }
    }
    
}
