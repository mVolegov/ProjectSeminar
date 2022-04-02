using MIS.GUIDoctor;
using System;
using System.Windows.Forms;

namespace MIS.GUI
{
    public partial class LoginForm : Form
    {
        private string loginReceptionist = "Мария";
        private string passwordReceptionist = "1234";

        private string loginDoctor = "Иван";
        private string passwordDoctor = "4321";
        
        public LoginForm()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginEntered = textBox1.Text;
            string passwordEntered = textBox2.Text;

            if (loginEntered.Equals(loginReceptionist) && passwordEntered.Equals(passwordReceptionist))
            {
                ReceptionistMainMenuForm receptionistMainMenuForm = new ReceptionistMainMenuForm(this);
                receptionistMainMenuForm.Show();
                Hide();
            }
            else if (loginEntered.Equals(loginDoctor) && passwordEntered.Equals(passwordDoctor))
            {
                DoctorMainMenuForm doctorMainMenuForm = new DoctorMainMenuForm(this);
                doctorMainMenuForm.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Вы ввели неправильный логин или пароль!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}