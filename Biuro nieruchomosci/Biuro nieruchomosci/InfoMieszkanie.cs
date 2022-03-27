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
    public partial class InfoMieszkanie : Form
    {
        public InfoMieszkanie()
        {
            InitializeComponent();
        }

        public int Id { get; set; }

        private void InfoMieszkanie_Shown(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                House house;
                Parking parking = null;

                using (DB db = new DB())
                {
                    house = db.House.FirstOrDefault(x => x.Id == Id);

                    if (house != null)
                    {
                        parking = db.Parking.FirstOrDefault(x => x.House_Id == house.Id);
                    }
                }

                if (house != null)
                {
                    label10.Text = house.Name;
                    label11.Text = house.Address;
                    label12.Text = ((TypMieszkania)house.HouseType_Id).ToString();
                    label13.Text = house.Area_sm.ToString();
                    label14.Text = house.Cost_sm.ToString();
                    label15.Text = house.Level.ToString();

                    label16.Text = parking == null ? "BRAK" : "JEST";

                    if (parking != null)
                    {
                        label17.Text = parking.Address;
                        label18.Text = parking.Number;
                    }
                    else
                    {
                        label17.Text = "";
                        label18.Text = "";
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
