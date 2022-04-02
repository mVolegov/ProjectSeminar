using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using MIS.Model;
using System.Linq;
using Receptionist.Service;

namespace MIS.GUI
{
    public partial class ReceptionistMainMenuForm : Form
    {
        private Form LoginForm;
        private List<Patient> Patients = new List<Patient>();

        public ReceptionistMainMenuForm(Form loginForm)
        {
            LoginForm = loginForm;

            InitializeComponent();

            Helper.LoadData(ref Patients);

            PrintDataToDataGridView();
        }

        /* Добавление пациента */
        private void button1_Click(object sender, EventArgs e)
        {
            AddPatientForm addPatientForm = new AddPatientForm(Patients);
            addPatientForm.ShowDialog();
            
            Helper.LoadData(ref Patients);

            PrintDataToDataGridView();
        }

        /* Удаление пацента */
        private void button2_Click(object sender, EventArgs e)
        {
            Patient patientToDelete = GetSelectedPatient();

            Patients.Remove(patientToDelete);

            Helper.SaveData(Patients);

            Helper.LoadData(ref Patients);

            PrintDataToDataGridView();
        }

        /* Изменение данных пациента */
        private void button4_Click(object sender, EventArgs e)
        {
            Patient patientToEdit = GetSelectedPatient();

            patientToEdit.Name = textBox1.Text ;
            patientToEdit.Surname = textBox2.Text ;
            patientToEdit.Patronymic = textBox4.Text ;
            patientToEdit.BirthDate = textBox3.Text ;
            patientToEdit.PassportSeries = textBox6.Text ;
            patientToEdit.PassportNumber = textBox7.Text ;
            patientToEdit.Snils = textBox8.Text ;
            patientToEdit.InsurancePolice = textBox9.Text ;
            patientToEdit.RegistrationAddress = textBox10.Text;
            patientToEdit.ResidentialAddress = textBox11.Text;
            patientToEdit.Profession = textBox12.Text;
            patientToEdit.PhoneNumber = textBox13.Text;

            Helper.SaveData(Patients);

            Helper.LoadData(ref Patients);

            PrintDataToDataGridView();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Patient selectedPatient = GetSelectedPatient();

            textBox1.Text = selectedPatient.Name;
            textBox2.Text = selectedPatient.Surname;
            textBox4.Text = selectedPatient.Patronymic;
            textBox3.Text = selectedPatient.BirthDate;
            textBox6.Text = selectedPatient.PassportSeries;
            textBox7.Text = selectedPatient.PassportNumber;
            textBox8.Text = selectedPatient.Snils;
            textBox9.Text = selectedPatient.InsurancePolice;
            textBox10.Text = selectedPatient.RegistrationAddress;
            textBox11.Text = selectedPatient.ResidentialAddress;
            textBox12.Text = selectedPatient.Profession;
            textBox13.Text = selectedPatient.PhoneNumber;
        }

        /* Закрытие формы */
        private void button3_Click(object sender, EventArgs e)
        {
            LoginForm.Show();
            Close();
        }
              
        /* Вывод данных в dataGridView */
        private void PrintDataToDataGridView()
        {
            dataGridView1.DataSource = Patients;

            dataGridView1.Columns["Name"].HeaderText = "Имя";
            dataGridView1.Columns["Surname"].HeaderText = "Фамилия";
            dataGridView1.Columns["Patronymic"].HeaderText = "Отчество";
            dataGridView1.Columns["LatestInspectionDate"].HeaderText = "Дата приема";

            dataGridView1.Columns["BirthDate"].Visible = false;
            dataGridView1.Columns["PassportSeries"].Visible = false;
            dataGridView1.Columns["PassportNumber"].Visible = false;
            dataGridView1.Columns["Snils"].Visible = false;
            dataGridView1.Columns["InsurancePolice"].Visible = false;
            dataGridView1.Columns["RegistrationAddress"].Visible = false;
            dataGridView1.Columns["ResidentialAddress"].Visible = false;
            dataGridView1.Columns["Profession"].Visible = false;
            dataGridView1.Columns["PhoneNumber"].Visible = false;
        }

        /* Получение выбранного пацента из списка пацентов (DataGridView) */
        private Patient GetSelectedPatient()
        {
            Patient selPatient = dataGridView1.SelectedRows[0].DataBoundItem as Patient;

            return selPatient;
        }
    }
}