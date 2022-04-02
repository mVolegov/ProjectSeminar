using MIS.Model;
using Receptionist.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Receptionist.GUIDoctor
{
    public partial class CurrentInspectionForm : Form
    {
        private Patient Patient;
        private List<Patient> Patients;

        public CurrentInspectionForm(Patient patient, List<Patient> patients)
        {
            InitializeComponent();
            Patient = patient;
            Patients = patients;

            label26.Text = patient.Name;
            label25.Text = patient.Surname;
            label24.Text = patient.Patronymic;
            label23.Text = patient.BirthDate;
            label22.Text = patient.PassportSeries;
            label21.Text = patient.PassportNumber;
            label20.Text = patient.Snils;
            label19.Text = patient.InsurancePolice;
            label18.Text = patient.RegistrationAddress;
            label17.Text = patient.ResidentialAddress;
            label16.Text = patient.Profession;
            label14.Text = patient.PhoneNumber;
        }

        /* Сохранение данных нового осмотра */
        private void button1_Click(object sender, EventArgs e)
        {
            Patients.Remove(Patient);

            Inspection currentInspection = Patient.Inspections[Patient.Inspections.Count - 1];  // Последний осмотр (по идее пустой)

            currentInspection.Complaints = richTextBox1.Text;
            currentInspection.Anamnesis = richTextBox2.Text;
            currentInspection.ObjectiveExamination = richTextBox3.Text;
            currentInspection.StLocalis = richTextBox4.Text;
            currentInspection.UltrasoundData = richTextBox5.Text;
            currentInspection.Diagnosis = richTextBox6.Text;
            currentInspection.Recomendations = richTextBox7.Text;
            currentInspection.Treatment = richTextBox8.Text;

            currentInspection.IsInspected = true;

            Patients.Add(Patient);

            Helper.SaveData(Patients);

            Close();
        }
    }
}
