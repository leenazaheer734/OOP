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
    public partial class GameControlsForm : Form
    {
        public GameControlsForm()
        {
            InitializeComponent();
        }

        private void goBack_BTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameIntro gintrofrm = new GameIntro();
            gintrofrm.Show();
        }
    }
}
