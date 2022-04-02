using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using MIS.Model;
using Receptionist.Service;

namespace MIS.GUI
{
    public partial class AddPatientForm : Form
    {
        private List<Patient> Patients { get; set; }

        public AddPatientForm(List<Patient> patients)
        {
            Patients = patients;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string patronymic = textBox4.Text;
            string birthDate = textBox3.Text;
            string passportSeries = textBox6.Text;
            string passportNumber = textBox7.Text;
            string snils = textBox8.Text;
            string insurancePolice = textBox9.Text;
            string registrationAddress = textBox10.Text;
            string residentialAddress = textBox11.Text;
            string profession = textBox12.Text;
            string phoneNumber = textBox13.Text;

            string inspectionDate = textBox5.Text;
            
            Patient patientToAdd = new Patient(name, surname, patronymic, birthDate, passportSeries, passportNumber, snils, 
                insurancePolice, registrationAddress, residentialAddress,
                profession, phoneNumber);

            if (isAlreadyExists(patientToAdd, Patients, out Patient patient))  // Если уже существует пациент
            {
                patient.LatestInspectionDate = inspectionDate;
                patient.Inspections.Add(new Inspection(inspectionDate));
            }
            else  // Если пациента еще не существует 
            {
                patientToAdd.Inspections = new List<Inspection>();
                patientToAdd.Inspections.Add(new Inspection(inspectionDate));
                patientToAdd.LatestInspectionDate = inspectionDate;
                Patients.Add(patientToAdd);
            }

            Helper.SaveData(Patients);
            
            Close();
        }
        
        /* Проверка уже существующего пациента */
        private static bool isAlreadyExists(Patient p, List<Patient> patients, out Patient patientToAdd)
        {
            bool isExists = false;
            patientToAdd = null;

            foreach (Patient patient in patients)
            {
                if (p.PassportSeries.Equals(patient.PassportSeries) 
                    && p.PassportNumber.Equals(patient.PassportNumber))
                {
                    isExists = true;
                    patientToAdd = patient;
                }
            }

            return isExists;
        }
    }
}