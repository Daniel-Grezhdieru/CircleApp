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
    public partial class Form3 : Form
    {
        private Fo general;
        public Form3()
        {
            InitializeComponent();
        }

        public Form3(Fo f)
        {
            InitializeComponent();
            general = f;
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            general.Active();
        }
    }
}
