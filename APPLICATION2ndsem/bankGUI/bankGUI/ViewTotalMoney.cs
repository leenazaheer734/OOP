using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bankGUI.DL;
using bankGUI.BL;

namespace bankGUI
{
    public partial class ViewTotalMoney : UserControl
    {
        public ViewTotalMoney()
        {
            InitializeComponent();
        }
        private void ViewTotalMoney_Load(object sender, EventArgs e)
        {
            Double total = ClientDL.Totalmoney();
            moneyBox_lbl.Text = total.ToString();
        }
    }
}
