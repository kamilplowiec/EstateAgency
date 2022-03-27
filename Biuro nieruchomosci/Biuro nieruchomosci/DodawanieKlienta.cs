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
    public partial class DodawanieKlienta : Form
    {
        public DodawanieKlienta()
        {
            InitializeComponent();
        }

        public TrybProgramu Tryb { get; set; }

        public int HouseId { get; set; }

        public int FlatForClientId { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            

            FlatForClient flatForClient = new FlatForClient();
            Client client = new Client();

            using (DB db = new DB())
            {
                if(FlatForClientId > 0)
                {
                    flatForClient = db.FlatForClient.FirstOrDefault(x => x.Id == FlatForClientId);
                    client = db.Client.FirstOrDefault(x => x.Id == flatForClient.Client_Id);
                }

                client.Name = textBox1.Text;
                client.Phone = textBox2.Text;
                client.Email = textBox3.Text;


                if (Tryb == TrybProgramu.Deweloper && checkBox1.Checked)
                {
                    ZatwierdzenieTranzakcji zatwierdzenie = new ZatwierdzenieTranzakcji();
                    zatwierdzenie.ClientId = client.Id;
                    var dr = zatwierdzenie.ShowDialog(this);

                    if (dr == DialogResult.OK)
                    {
                        flatForClient.UseType_Id = zatwierdzenie.UseType;
                        flatForClient.DateTo = zatwierdzenie.DateTo;
                        flatForClient.Accepted = true;
                    }
                    else
                        return;
                }


                if (FlatForClientId == 0)
                {
                    db.Client.Add(client);
                    db.SaveChanges();

                    flatForClient.DateTo = null;
                    flatForClient.UseType_Id = 0;
                    flatForClient.Client_Id = client.Id;

                    flatForClient.Accepted = checkBox1.Checked;
                    flatForClient.House_Id = HouseId;

                    db.FlatForClient.Add(flatForClient);

                    db.SaveChanges();
                }
                else
                {
                    db.SaveChanges();
                }
            }

            if (Tryb == TrybProgramu.Klient)
            {
                MessageBox.Show("Poczekaj teraz na decyzję dewelopera.");
            }

            DialogResult = DialogResult.OK;
        }

        private void DodawanieKlienta_Shown(object sender, EventArgs e)
        {
            House house;
            FlatForClient flatForClient = null;
            Client client = null; ;

            using (DB db = new DB())
            {
                house = db.House.FirstOrDefault(x => x.Id == HouseId);

                if (FlatForClientId > 0)
                {
                    flatForClient = db.FlatForClient.FirstOrDefault(x => x.Id == FlatForClientId);

                    if(flatForClient != null)
                    {
                        client = db.Client.FirstOrDefault(x => x.Id == flatForClient.Client_Id);
                    }
                }
            }

            textBox4.Text = house.Name + ", " + house.Address;

            if (client != null)
            {
                textBox1.Text = client.Name;
                textBox2.Text = client.Phone;
                textBox3.Text = client.Email;
            }

            if (Tryb == TrybProgramu.Deweloper)
            {
                checkBox1.Visible = true;

                if (FlatForClientId > 0)
                {
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                }
            }
        }
    }
}
