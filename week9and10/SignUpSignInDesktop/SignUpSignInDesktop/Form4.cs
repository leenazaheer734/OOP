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
using SignUpSignInDesktop.BL;

namespace SignUpSignInDesktop
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            MUserDL.readDatafromFile();
            dataBind();
            int col1 = usersGV.Columns["Update"].Index;
            int col2 = usersGV.Columns["cb"].Index;
            usersGV.Columns["cb"].DisplayIndex = col1;
            usersGV.Columns["Update"].DisplayIndex = col2;

        }

        private void usersGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(usersGV.Columns["Update"].Index == e.ColumnIndex)
            {
                //   MUser obj = (MUser)usersGV.CurrentRow.DataBoundItem;
                // 2Darray [row, Name.Index]
                int usranmeIndex = usersGV.Columns["Name"].Index;

                string username = usersGV[usranmeIndex, e.RowIndex].Value.ToString()   ;
                string password = usersGV[usersGV.Columns["Password"].Index, e.RowIndex].Value.ToString();
                string role = usersGV[usersGV.Columns["Role"].Index, e.RowIndex].Value.ToString();
                // string ss = usersGV[usersGV.Columns["ss"].Index, e.RowIndex].Value.ToString();
                
                
                MUser obj = new MUser(username, password, role);
                MessageBox.Show(obj.Name);
            }
        }
        
        private void dataBind()
        {
            usersGV.DataSource = null;
            foreach(var o in MUserDL.UserList){
                                                                        // {Name, Password, Role, Obj.ss}
                usersGV.DataSource = MUserDL.UserList.Select( c => new { c.Name, c.Password, c.Role}).ToList();
            }
            // yield
            // usersGV.DataSource = MUserDL.UserList;
            usersGV.Refresh();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
