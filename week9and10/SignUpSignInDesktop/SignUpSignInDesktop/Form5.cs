using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SignUpSignInDesktop.DL;

namespace SignUpSignInDesktop
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            MUserDL.readDatafromFile();
            userGV.DataSource = MUserDL.UserList;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void DataBind()
        {
            userGV.DataSource = null;
            userGV.DataSource = MUserDL.UserList;
            userGV.Refresh();
        }

        private void userGV_Click(object sender, EventArgs e)
        {

        }
    }
}
