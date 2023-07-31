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
    public partial class GameMissionForm : Form
    {
        public GameMissionForm()
        {
            InitializeComponent();
        }

        private void GameMissionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void goBack_BTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameIntro gi = new GameIntro();
            gi.Show();
        }
    }
}
