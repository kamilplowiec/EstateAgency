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
    public partial class Glowne : Form
    {
        public Glowne()
        {
            InitializeComponent();
        }

        TrybProgramu Tryb { get; set; }

        private void Glowne_Shown(object sender, EventArgs e)
        {
            TypUzytkownika typ = new TypUzytkownika();

            var dr = typ.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                Tryb = typ.Tryb;
            }
            else
            {
                Close();
            }

            if (Tryb == TrybProgramu.Deweloper)
            {
                button3.Visible = true;
                button5.Visible = true;
            }
            else
            {
                button2.Visible = true;
            }

            button1_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows[0].Index < 0)
            {
                MessageBox.Show("Wybierz mieszkanie z listy");
                return;
            }

            DodawanieKlienta klient = new DodawanieKlienta();
            klient.Tryb = Tryb;
            klient.HouseId = int.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["Id"].Value.ToString());
            klient.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DodawanieMieszkania mieszkanie = new DodawanieMieszkania();
            var dr = mieszkanie.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                button1_Click(null, null);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LadujWyszukiwarke(textBox1.Text);
        }

        private void LadujWyszukiwarke(string text)
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
                db.House.Load();

                if (Tryb == TrybProgramu.Klient)
                {
                    this.dataGridView1.DataSource = db.House.Local.ToBindingList().Where(x => (string.IsNullOrEmpty(text) ? x.Id > 0 : (x.Name.Contains(text) || x.Address.Contains(text))) && db.FlatForClient.FirstOrDefault(f => f.House_Id == x.Id && f.Accepted == true) == null).Select(x =>
                        new
                        {
                            x.Id,
                            Nazwa = x.Name,
                            Typ = ((TypMieszkania)x.HouseType_Id).ToString(),
                            Piętro = x.Level,
                            Cena = x.Cost_sm * x.Area_sm,
                            Adres = x.Address,
                            Parking = db.Parking.FirstOrDefault(p => p.House_Id == x.Id) != null
                        }
                    ).ToList();
                }
                else
                {
                    this.dataGridView1.DataSource = db.House.Local.ToBindingList().Where(x => string.IsNullOrEmpty(text) ? x.Id > 0 : (x.Name.Contains(text) || x.Address.Contains(text))).Select(x =>
                        new
                        {
                            x.Id,
                            Nazwa = x.Name,
                            Typ = ((TypMieszkania)x.HouseType_Id).ToString(),
                            Piętro = x.Level,
                            Cena = x.Cost_sm * x.Area_sm,
                            Adres = x.Address,
                            Parking = db.Parking.FirstOrDefault(p => p.House_Id == x.Id) != null,
                            Wynajete = db.FlatForClient.FirstOrDefault(f => f.House_Id == x.Id && f.Accepted == true) != null
                        }
                    ).ToList();
                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tryb == TrybProgramu.Deweloper)
            {
                DodawanieMieszkania mieszkanie = new DodawanieMieszkania();
                mieszkanie.Id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                var dr = mieszkanie.ShowDialog(this);

                if (dr == DialogResult.OK)
                {
                    button1_Click(null, null);
                }
            }
            else
            {
                InfoMieszkanie info = new InfoMieszkanie();
                info.Id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                info.ShowDialog(this);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListaZapytan lista = new ListaZapytan();
            lista.ShowDialog(this);

            LadujWyszukiwarke(textBox1.Text);
        }
    }

    public enum TrybProgramu
    {
        Deweloper = 1,
        Klient = 2
    }

    public enum TypMieszkania
    {
        Blok = 1,
        Jednorodzinny = 2,
        Blizniak = 3
    }

    public enum TypUzycia
    {
        Wynajem = 1,
        Kupno = 2
    }
}
