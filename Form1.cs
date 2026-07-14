using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistrationSystem
{
    public partial class Form1 : Form
    {
        private bool IsValidPhoneNumber(string phone)
        {
            foreach (char c in phone)
            {
                if (!char.IsDigit(c) && c != ' ' && c != '+' && c != '-')
                {
                    return false;
                }
            }

            return true;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbCourse.Items.Add("C# Programming");
            cmbCourse.Items.Add("Web Development");
            cmbCourse.Items.Add("Database Management");
            cmbCourse.Items.Add("Mobile App Development");
            cmbCourse.Items.Add("Artificial Intelligence");
            cmbCourse.Items.Add("Cybersecurity");

            cmbCourse.SelectedIndex = -1;
            txtStudentId.Focus();

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string studentId = txtStudentId.Text.Trim();
            string studentName = txtStudentName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (studentId == "")
            {
                MessageBox.Show("Please enter the Student ID.",
                                "Missing Student ID",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtStudentId.Focus();
                return;
            }

            if (studentName == "")
            {
                MessageBox.Show("Please enter the Student Name.",
                                "Missing Student Name",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtStudentName.Focus();
                return;
            }

            string gender = "";

            if (rdoMale.Checked)
            {
                gender = "Male";
            }
            else if (rdoFemale.Checked)
            {
                gender = "Female";
            }
            else
            {
                MessageBox.Show("Please select a gender.",
                                "Missing Gender",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                return;
            }

            if (cmbCourse.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a course.",
                                "Missing Course",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                cmbCourse.Focus();
                return;
            }

            if (email == "")
            {
                MessageBox.Show("Please enter the email address.",
                                "Missing Email",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtEmail.Focus();
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.",
                                "Invalid Email",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtEmail.Focus();
                return;
            }

            if (phone == "")
            {
                MessageBox.Show("Please enter the phone number.",
                                "Missing Phone Number",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtPhone.Focus();
                return;
            }

            if (!IsValidPhoneNumber(phone))
            {
                MessageBox.Show("Please enter a valid phone number.",
                                "Invalid Phone Number",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtPhone.Focus();
                return;
            }

            if (!chkAgree.Checked)
            {
                MessageBox.Show("Please confirm that the information entered is correct.",
                                "Confirmation Required",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                chkAgree.Focus();
                return;
            }

            string course = cmbCourse.SelectedItem.ToString();
            DateTime dateOfBirth = dtpDateOfBirth.Value;

            rtbOutput.Clear();

            rtbOutput.AppendText("STUDENT REGISTRATION DETAILS\n");
            rtbOutput.AppendText("----------------------------------------\n");
            rtbOutput.AppendText($"Student ID     : {studentId}\n");
            rtbOutput.AppendText($"Student Name   : {studentName}\n");
            rtbOutput.AppendText($"Gender         : {gender}\n");
            rtbOutput.AppendText($"Date of Birth  : {dateOfBirth.ToShortDateString()}\n");
            rtbOutput.AppendText($"Course         : {course}\n");
            rtbOutput.AppendText($"Email          : {email}\n");
            rtbOutput.AppendText($"Phone Number   : {phone}\n");

            MessageBox.Show("Student registration completed successfully.",
                            "Registration Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStudentId.Clear();
            txtStudentName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();

            rdoMale.Checked = false;
            rdoFemale.Checked = false;

            cmbCourse.SelectedIndex = -1;
            dtpDateOfBirth.Value = DateTime.Today;

            chkAgree.Checked = false;

            rtbOutput.Clear();

            txtStudentId.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?",
                                                  "Confirm Exit",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }





     
}
