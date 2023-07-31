using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChickenInvaderGame
{
    public partial class GameOverForm : Form
    {
        public GameOverForm(int num)
        {
            InitializeComponent();
            if(num == 1)
            {
                formlabelmain.Visible = true;
                wonlabel.Visible = false;
            }
            else if (num == 2)
            {
                formlabelmain.Visible = false;
                wonlabel.Visible = true;
            }
        }

        private void playAgain_BTN_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void exit_BTN_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
    }
}
