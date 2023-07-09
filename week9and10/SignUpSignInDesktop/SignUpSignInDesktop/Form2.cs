using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SignUpSignInDesktop.BL;
using SignUpSignInDesktop.DL;

namespace SignUpSignInDesktop
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void ClearDataFromForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 first = new Form1();
            first.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string pass = textBox2.Text;
            string role = textBox3.Text;
            string path = "data.txt";
            MUser user = new MUser(name,pass,role);
            MUserDL.addUserInList(user);
            MUserDL.storeUserInFile(user, path);

            MessageBox.Show("User Added Successfully");
            ClearDataFromForm();
        }
    }
}
