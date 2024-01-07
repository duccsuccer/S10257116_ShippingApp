using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10257116_HospitalApp
{
    internal class Doctor : Person
    {
        public string Department { get; set; }
        public Dictionary<string, Patient> Patients { get; set; } = new();
        public Doctor() { }
        public Doctor(string nric, string name, string department) : base(nric, name)
        {
            Department = department;
        }
        public void AddPatient(Patient patient)
        {
            Patients.Add(patient.Nric, patient);
        }
        public void RemovePatient(Patient patient)
        {
            Patients.Remove(patient.Nric);
        }
        public override string ToString()
        {
            return base.ToString() + $" Department {Department}";
        }

    }
}
