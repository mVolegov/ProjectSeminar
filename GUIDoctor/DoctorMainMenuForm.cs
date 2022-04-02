using MIS.Model;
using Receptionist.GUIDoctor;
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

namespace MIS.GUIDoctor
{
    public partial class DoctorMainMenuForm : Form
    {
        private Form LoginForm;
        private List<Patient> Patients;
        private List<Patient> TodayPatients = new List<Patient>();

        public DoctorMainMenuForm(Form loginForm)
        {
            InitializeComponent();
            LoginForm = loginForm;
            Helper.LoadData(ref Patients);
            PrintDataToDataGridView();
        }

        /* Просмотр истории записей */
        private void button1_Click(object sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm();
            historyForm.Show();
        }

        /* Выбор пациента на осмотр */
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Patient selectedPatient = GetSelectedPatient();

            CurrentInspectionForm currentInspectionForm = new CurrentInspectionForm(selectedPatient, Patients);

            currentInspectionForm.Text = "Осмотр: " + 
                selectedPatient.Surname + " " + 
                selectedPatient.Surname + " " +
                selectedPatient.Patronymic + " " +
                selectedPatient.LatestInspectionDate;

            currentInspectionForm.ShowDialog();

            Helper.LoadData(ref Patients);

            PrintDataToDataGridView();
        }

        /* Выход */
        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm.Show();
            Close();
        }

        /* Вывод пациентов, которые записаны на сегодня */
        private void PrintDataToDataGridView()
        {
            SelectDataFromDatabase();

            dataGridView1.DataSource = TodayPatients;

            dataGridView1.Columns["Name"].HeaderText = "Имя";
            dataGridView1.Columns["Surname"].HeaderText = "Фамилия";
            dataGridView1.Columns["Patronymic"].HeaderText = "Отчество";
            dataGridView1.Columns["BirthDate"].HeaderText = "Дата рождения";

            dataGridView1.Columns["LatestInspectionDate"].Visible = false;
            dataGridView1.Columns["PassportSeries"].Visible = false;
            dataGridView1.Columns["PassportNumber"].Visible = false;
            dataGridView1.Columns["Snils"].Visible = false;
            dataGridView1.Columns["InsurancePolice"].Visible = false;
            dataGridView1.Columns["RegistrationAddress"].Visible = false;
            dataGridView1.Columns["ResidentialAddress"].Visible = false;
            dataGridView1.Columns["Profession"].Visible = false;
            dataGridView1.Columns["PhoneNumber"].Visible = false;
        }

        private void LoadDataFromDatabase()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            using (FileStream fileStream = new FileStream(
                @"C:\Users\voleg\Desktop\БИ\Курсовая\Demo\MIS\Database\Patients.bin",
                FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (fileStream.Length != 0) Patients = (List<Patient>)binaryFormatter.Deserialize(fileStream);
            }
        }

        /* Выбор пациентов у которых записи на сегодня и они еще не осмотрены */
        private void SelectDataFromDatabase()
        {
            List<Patient> tempList = new List<Patient>();

            foreach (var patient in Patients)
            {
                foreach (var inspection in patient.Inspections)
                {
                    if (!inspection.IsInspected &&
                        inspection.InspectionDate.Equals(DateTime.Now.ToString("dd.MM.yyyy")))
                    {
                        tempList.Add(patient);
                    } 
                }
            }

            TodayPatients = tempList;
        }

        private Patient GetSelectedPatient()
        {
            Patient patient = dataGridView1.SelectedRows[0].DataBoundItem as Patient;

            return patient;
        }
    }
}
