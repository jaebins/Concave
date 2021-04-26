using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omok
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void but_SinglePlay_Click(object sender, EventArgs e)
        {
            new Game_Client();
        }

        private void but_MakeRoom_Click(object sender, EventArgs e)
        {
            new ServerConnect(AddressInput.Text, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ServerConnect(AddressInput.Text, false);
        }
    }
}
