using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pd9.DL;
using pd9.BL;

namespace pd9
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            MUserDL.loaddumydata();
            dataBind();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataBind()
        {
            usersGV.DataSource = null;
            foreach (var o in MUserDL.getList())
            {
                // {Name, Password, Role}
                usersGV.DataSource = MUserDL.getList().Select(c => new { c.Name, c.Password, c.Role, c.Product.price }).ToList();
            }

            // yield

            //usersGV.DataSource = MUserDL.getList();

            usersGV.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MUserDL.deleteUserFromList(usersGV.CurrentRow.Index);
            dataBind();
            usersGV.Refresh();
            MessageBox.Show("Data is successfully deleted");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (MUserDL.findUserInList(name))
            {
                label1.Text = "User Is Available"; 
            }
            else
            {
                label1.Text = "User not Available";
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {
             
        }
    }
}
