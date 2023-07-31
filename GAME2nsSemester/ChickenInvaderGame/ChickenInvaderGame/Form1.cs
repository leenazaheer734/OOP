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
    public partial class GameIntro : Form
    {
        public GameIntro()
        {
            InitializeComponent();
        }

        private void controls_BTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameControlsForm gamecontrol = new GameControlsForm();
            gamecontrol.Show();
        }

        private void Start_BTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameStartForm gsf = new GameStartForm();
            gsf.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameMissionForm gmf = new GameMissionForm();
            gmf.Show();
        }
    }
}
