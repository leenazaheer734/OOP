using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bankGUI.DL;
using System.Windows.Forms;

namespace bankGUI
{
    public partial class closeAcc : UserControl
    {
        public closeAcc()
        {
            InitializeComponent();
            dataBind();
        }

        private void closeAcc_Load(object sender, EventArgs e)
        {

        }
        private void dataBind()
        {
            delAcc_GV.DataSource = null;
            foreach (var o in ClientDL.getClientList())
            {
                // {Name, Password, Role, Obj.ss}
                delAcc_GV.DataSource = ClientDL.getClientList().Select(c => new { c.Account.AccountNumber,c.ClientCred.Username, c.ClientCred.Password, c.Account.Balance }).ToList();
            }
            // yield
            // usersGV.DataSource = MUserDL.UserList;
            delAcc_GV.Refresh();
        }

    }
}
