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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void ClearDataFromForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
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
            MUser user = new MUser(name, pass);
            MUser validuser = MUserDL.SignIN(user);
            if(validuser != null)
            {
                MessageBox.Show(" User is Valid");
            }
            else
            {
                MessageBox.Show(" User is INvalid!!!");
            }
            ClearDataFromForm();
        }
    }
}
