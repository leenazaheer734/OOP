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

namespace bankGUI
{
    public partial class ViewCBalance : UserControl
    {
        public ViewCBalance()
        {
            InitializeComponent();
            moneyBox_lbl.Text = ExtraDL.CurrentClient.Account.Balance.ToString();
        }
    }
}
