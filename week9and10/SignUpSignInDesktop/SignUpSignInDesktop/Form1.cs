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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string load)
        {
            InitializeComponent();

            string path = "data.txt";
            if (MUserDL.readDatafromFile(path))
            {
                MessageBox.Show(" Data Loaded from FIle");
            }
            else
            {
                MessageBox.Show(" Data  NOT Loaded !!");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked && checkBox2.Checked)
            {
                MessageBox.Show(" Select One Textbox");
            }
            else if (checkBox1.Checked)
            {
                Form2 signUp = new Form2();
                signUp.Show();
            }
            else if(checkBox2.Checked)
            {
                Form3 signIn = new Form3();
                signIn.Show();
            }
            this.Hide();
        }
    }
}
