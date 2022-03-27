using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biuro_nieruchomosci
{
    public partial class TypUzytkownika : Form
    {
        public TrybProgramu Tryb { get; set; }

        public TypUzytkownika()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tryb = TrybProgramu.Deweloper;

            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tryb = TrybProgramu.Klient;

            DialogResult = DialogResult.OK;
        }
    }
}
