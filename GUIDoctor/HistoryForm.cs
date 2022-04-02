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
    public partial class HistoryForm : Form
    {
        private List<Patient> Patients = new List<Patient>();

        public HistoryForm()
        {
            InitializeComponent();

            Helper.LoadData(ref Patients);

            PrintDataToGridView1();
        }

        /* Выбор из списка пациетов */
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Patient selectedPatient = GetSelectedPatient();

            PrintDataToGridView2(selectedPatient);
        }

        /* Выбор из списка истории записей пациента */
        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Patient selectedPatient = GetSelectedPatient();
            Inspection selectedInspection = GetSelectedInspection();

            PreviousInspectionForm previousInspectionForm = new PreviousInspectionForm(selectedPatient, selectedInspection);

            previousInspectionForm.Text = "Осмотр. " 
                + selectedPatient.LatestInspectionDate + " "
                + selectedPatient.Surname + " " 
                + selectedPatient.Name + " " 
                + selectedPatient.Patronymic;

            previousInspectionForm.Show();
        }

        /* Закрытие */
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PrintDataToGridView1()
        {
            dataGridView1.DataSource = Patients;

            dataGridView1.Columns["Name"].HeaderText = "Имя";
            dataGridView1.Columns["Surname"].HeaderText = "Фамилия";
            dataGridView1.Columns["Patronymic"].HeaderText = "Отчество";
            dataGridView1.Columns["BirthDate"].HeaderText = "Дата рождения";

            dataGridView1.Columns["PassportSeries"].Visible = false;
            dataGridView1.Columns["PassportNumber"].Visible = false;
            dataGridView1.Columns["Snils"].Visible = false;
            dataGridView1.Columns["InsurancePolice"].Visible = false;
            dataGridView1.Columns["RegistrationAddress"].Visible = false;
            dataGridView1.Columns["ResidentialAddress"].Visible = false;
            dataGridView1.Columns["Profession"].Visible = false;
            dataGridView1.Columns["PhoneNumber"].Visible = false;
            dataGridView1.Columns["LatestInspectionDate"].Visible = false;
        }

        private void PrintDataToGridView2(Patient selPatient)
        {
            label26.Text = selPatient.Name;
            label25.Text = selPatient.Surname;
            label24.Text = selPatient.Patronymic;
            label23.Text = selPatient.BirthDate;
            label22.Text = selPatient.PassportSeries;
            label21.Text = selPatient.PassportNumber;
            label20.Text = selPatient.Snils;
            label19.Text = selPatient.InsurancePolice;
            label18.Text = selPatient.RegistrationAddress;
            label17.Text = selPatient.ResidentialAddress;
            label16.Text = selPatient.Profession;
            label2.Text = selPatient.PhoneNumber;

            label1.Text = selPatient.Surname + "\n" 
                + selPatient.Name + "\n" 
                + selPatient.Patronymic;

            dataGridView2.DataSource = selPatient.Inspections;

            dataGridView2.Columns["InspectionDate"].HeaderText = "Дата осмотра";

            dataGridView2.Columns["IsInspected"].Visible = false;
            dataGridView2.Columns["Complaints"].Visible = false;
            dataGridView2.Columns["IsInspected"].Visible = false;
            dataGridView2.Columns["Anamnesis"].Visible = false;
            dataGridView2.Columns["ObjectiveExamination"].Visible = false;
            dataGridView2.Columns["StLocalis"].Visible = false;
            dataGridView2.Columns["UltrasoundData"].Visible = false;
            dataGridView2.Columns["Diagnosis"].Visible = false;
            dataGridView2.Columns["Recomendations"].Visible = false;
            dataGridView2.Columns["Treatment"].Visible = false;
        }

        private Patient GetSelectedPatient()
        {
            return dataGridView1.SelectedRows[0].DataBoundItem as Patient;
        }

        private Inspection GetSelectedInspection()
        {
            return dataGridView2.SelectedRows[0].DataBoundItem as Inspection;
        }
    }
}
