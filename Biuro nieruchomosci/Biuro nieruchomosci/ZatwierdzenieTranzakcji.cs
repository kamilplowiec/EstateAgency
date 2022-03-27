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
    public partial class ZatwierdzenieTranzakcji : Form
    {
        public ZatwierdzenieTranzakcji()
        {
            InitializeComponent();

            comboBox1.Items.AddRange(Enum.GetNames(typeof(TypUzycia)).ToArray());
        }

        public int ClientId { get; set; }

        public int UseType { get; set; }
        public DateTime? DateTo { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            UseType = (int)Enum.Parse(typeof(TypUzycia), comboBox1.SelectedItem.ToString());

            if (comboBox1.SelectedItem.ToString() == "Wynajem")
            {
                DateTo = dateTimePicker1.Value;
            }

            DialogResult = DialogResult.OK;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(((ComboBox)sender).SelectedItem.ToString() == "Wynajem")
            {
                dateTimePicker1.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
            }
        }

        private void ZatwierdzenieTranzakcji_Shown(object sender, EventArgs e)
        {
            if(ClientId > 0)
            {
                using (DB db = new DB())
                {
                    var client = db.Client.FirstOrDefault(x => x.Id == ClientId);

                    if(client != null)
                    {
                        textBox1.Text = client.Name;
                    }
                }
            }
        }
    }
}
