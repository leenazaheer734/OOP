using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    public partial class frmGameEnd : Form
    {
        public frmGameEnd(Image img)
        {
            InitializeComponent();
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void frmGameEnd_Load(object sender, EventArgs e)
        {

        }

        private void rstbutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void endbuton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;

        }
    }
}
