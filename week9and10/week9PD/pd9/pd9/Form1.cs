using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pd9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            addItemsInComboBox();
        }
        public void addItemsInComboBox()
        {
            comboBox1.Items.Add("Noor Fatima");
            comboBox1.Items.Add("Leena Zaheer");
            comboBox1.Items.Add("Affera Fatima");
            comboBox1.Items.Add("Muneeba Haya");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedText.ToString();
        }
    }
}
