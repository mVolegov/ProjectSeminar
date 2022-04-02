using MIS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Receptionist.Service
{
    public class Helper
    {
        public static void SaveData(List<Patient> p)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            using (FileStream fileStream = new FileStream(
                @"..\..\Database\Patients.bin",
                FileMode.OpenOrCreate, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream, p);
            }
        }

        public static void LoadData(ref List<Patient> Patients)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            using (FileStream fileStream = new FileStream(
                @"..\..\Database\Patients.bin",
                FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (fileStream.Length != 0) Patients = (List<Patient>)binaryFormatter.Deserialize(fileStream);
            }
        }
    }
}
