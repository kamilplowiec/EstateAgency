using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biuro_nieruchomosci
{
    public partial class ListaZapytan : Form
    {
        public ListaZapytan()
        {
            InitializeComponent();
        }

        private void ListaZapytan_Shown(object sender, EventArgs e)
        {
            this.dataGridView1.DataBindingComplete += (o, _) =>
            {
                var dataGridView = o as DataGridView;
                if (dataGridView != null)
                {
                    dataGridView.Columns["Id"].Visible = false;

                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };

            using (DB db = new DB())
            {
                db.FlatForClient.Load();

                this.dataGridView1.DataSource = db.FlatForClient.Local.ToBindingList().Where(x => x.Accepted == false).Select(x =>
                    new
                    {
                        x.Id,
                        Nazwa = db.House.FirstOrDefault(h => h.Id == x.House_Id).Name,
                        Klient = db.Client.FirstOrDefault(c => c.Id == x.Client_Id).Name
                    }
                ).ToList();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DodawanieKlienta klient = new DodawanieKlienta();
            klient.FlatForClientId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());

            using (DB db = new DB())
            {
                klient.HouseId = db.FlatForClient.FirstOrDefault(x => x.Id == klient.FlatForClientId).House_Id;
            }

            klient.Tryb = TrybProgramu.Deweloper;

            var dr = klient.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                ListaZapytan_Shown(null, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
