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
        string name;
        Player player1;
        public TaxiForm(Player player1, string name)
        {
            InitializeComponent();
            this.name = name;
            label1.Text = name;
            this.player1 = player1;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            player1.life = true;
        }
    }
}
