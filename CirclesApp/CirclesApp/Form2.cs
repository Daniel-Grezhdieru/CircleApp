using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CirclesApp
{
    public partial class Form2 : Form
    {
        private Fo general;
        ColorDialog colorDialog = new ColorDialog();

        public Form2()
        {
            InitializeComponent();  
        }

        public Form2(Fo f)
        {
            InitializeComponent();
            general = f;

            label5.BackColor = general.color1;
            label6.BackColor = general.color2;
            numericUpDown1.Value = general.count;
            numericUpDown2.Value = general.radius;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK) 
            {
                label5.BackColor = colorDialog.Color; // меняем цвет для фона label5
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                label6.BackColor = colorDialog.Color; // меняем цвет для фона label6
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            general.Active();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            general.color1 = label5.BackColor;
            general.color2 = label6.BackColor;
            general.count = (int)numericUpDown1.Value;
            general.radius = (int)numericUpDown2.Value;
            Close();
        }
    }
}
