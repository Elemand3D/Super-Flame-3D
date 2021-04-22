using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatorWinForm
{
    public partial class TaxiForm : Form
    {
        public bool life;
        public TaxiForm()
        {
            InitializeComponent();
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            life = false;
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            life = true;
            this.Close();

        }
    }
}
