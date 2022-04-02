using MIS.Model;
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
    public partial class PreviousInspectionForm : Form
    {
        public PreviousInspectionForm(Patient patient, Inspection inspection)
        {
            InitializeComponent();

            richTextBox1.Text = inspection.Complaints;
            richTextBox2.Text = inspection.Anamnesis;
            richTextBox3.Text = inspection.ObjectiveExamination;
            richTextBox4.Text = inspection.StLocalis;
            richTextBox5.Text = inspection.UltrasoundData;
            richTextBox6.Text = inspection.Diagnosis;
            richTextBox7.Text = inspection.Recomendations;
            richTextBox8.Text = inspection.Treatment;

            label2.Text = patient.Surname + " " + patient.Name + " " + patient.Patronymic;
            label5.Text = inspection.InspectionDate;
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

        /* Закрытие */
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
