using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10257116_HospitalApp
{
    internal class Person
    {
        public string Nric {  get; set; }
        public string Name { get; set; }
        public Person() { }
        public Person(string nric, string name)
        {
            Nric = nric;
            Name = name;
        }
        public override string ToString()
        {
            return $"NRIC: {Nric}, Name: {Name}";
        }
    }
}
