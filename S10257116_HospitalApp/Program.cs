using S10257116_HospitalApp;
using System.Security;
using System.Text;

Dictionary<string, Room> roomDict = new();
Dictionary<string, Doctor> doctorDict = new();
Dictionary<string, Patient> patientDict = new();
InitData(roomDict, doctorDict);
CreatePatients(patientDict, roomDict);
int opt;
while (true)
{
    Console.Write("\r\n---------------- M E N U -----------------\r\n" +
    "[1] Assign patients to doctors\r\n" +
    "[2] Remove patient from doctor\r\n" +
    "[3] Add new patient\r\n" +
    "[0] Exit\r\n------------------------------------------\r\n" +
    "Enter your option : ");
    opt = Convert.ToInt32(Console.ReadLine());
    if (opt == 0)
    {
        break;
    }
    if (opt == 1)
    {
        AssignPatientsToDoctors(patientDict, doctorDict);
    }
    else if (opt == 2)
    {
        RemovePatientFromDoctor(doctorDict);
    }
    else if (opt == 3)
    {
        AddNewPatient(patientDict, roomDict);
    }
    else
    {
        Console.WriteLine("Option not Found.");
    }
}
    static void InitData(Dictionary<string, Room> roomDict, Dictionary<string, Doctor> doctorDict)
{
    Room r1 = new("#01-01", "C");
    Room r2 = new("#02-02", "B");
    Room r3 = new("#03-03", "A");
    Room r4 = new("#04-04", "A");
    roomDict.Add(r1.Location, r1);
    roomDict.Add(r2.Location, r2);
    roomDict.Add(r3.Location, r3);
    roomDict.Add(r4.Location, r4);

    Doctor d1 = new("S1234567A", "Tom", "Pediatrics");
    Doctor d2 = new("S2345678A", "Champ", "Oncology");
    Doctor d3 = new("S3456789B", "Terry", "Cardiology");
    doctorDict.Add(d1.Nric, d1);
    doctorDict.Add(d2.Nric, d2);
    doctorDict.Add(d3.Nric, d3);
}
static void CreatePatients(Dictionary<string, Patient> patientDict, Dictionary<string, Room> roomDict)
{
    string[] info = File.ReadAllLines("Patients.csv");
    foreach (string line in info.Skip(1))
    {
        string[] patients = line.Split(',');
        string nric = patients[0];  
        string name = patients[1];
        string location = patients[2];
        Patient patient = new Patient(nric, name, roomDict[location]);
        patientDict.Add(nric, patient);
    }
}

static void AssignPatientsToDoctors(Dictionary<string, Patient> patientDict, Dictionary<string, Doctor> doctorDict)
{
    string[] info = File.ReadAllLines("PatientsToDoctor.csv");
    foreach (string line in info.Skip(1))
    {
        string[] patientsTD = line.Split(",");
        string nric = patientsTD[0];
        string name = patientsTD[1];
        string docNric = patientsTD[2];
        string docName = patientsTD[3];
        string docDept = patientsTD[4];
        if (doctorDict.TryGetValue(docNric, out Doctor doctor))
        {
            Patient patient = patientDict[nric];
            doctor.AddPatient(patient);
        }
        else
        {
            Console.WriteLine($"Doctor with NRIC {docNric} not found.");
        }
    }    
    foreach (Doctor doctor in doctorDict.Values)
    {
        if (doctor.Patients.Count == 0)
        {
            break;
        }
        Console.WriteLine(doctor.ToString());
        Console.WriteLine("--------------------------------\nPATIENTS ASSIGNED");
        foreach (Patient patient in doctor.Patients.Values)
        {   
            Console.WriteLine(patient.ToString());
        }
        Console.WriteLine("--------------------------------");
    }

}
static void RemovePatientFromDoctor(Dictionary<string, Doctor> doctorDict)
{
    bool pfound = false;
    Console.Write("Enter NRIC of patient: ");
    string pNric = Console.ReadLine();
    foreach (Doctor doctor in doctorDict.Values)
    {
        if (doctor.Patients.ContainsKey(pNric))
        {
            Patient patient = doctor.Patients[pNric];
            doctor.RemovePatient(patient);
            pfound = true;
            break;
        }
        if (doctor.Patients.Count == 0)
        {
            break;
        }
        Console.WriteLine(doctor.ToString());
        Console.WriteLine("--------------------------------\nPATIENTS ASSIGNED");
        foreach (Patient patients in doctor.Patients.Values)
        {
            Console.WriteLine(patients.ToString());
        }
        Console.WriteLine("--------------------------------");
    }
    if (pfound == false) {Console.WriteLine($"Patient with NRIC {pNric} not found.");}
}
static void AddNewPatient(Dictionary<string, Patient> patientDict, Dictionary<string, Room> roomDict)
{
    Console.Write("NRIC: ");
    string addnric = Console.ReadLine();
    Console.Write("Name: ");
    string addname = Console.ReadLine();
    Console.Write("Location of room warded: ");
    string addloc = Console.ReadLine();
    Console.Write("Ward Class: ");
    string wclass = Console.ReadLine();
    Room newroom = new(addloc, wclass);
    Patient nPatient = new(addnric, addname, newroom);
    roomDict.Add(addloc, newroom);
    patientDict.Add(addnric, nPatient);
    StringBuilder csvStringBuilder = new StringBuilder();
    csvStringBuilder.AppendLine($"\n{addnric},{addname},{addloc}");
    string path = "Patients.csv";
    File.AppendAllText(path, csvStringBuilder.ToString());
    Console.WriteLine("Patient information added successfully.");
}
