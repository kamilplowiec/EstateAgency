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
    public partial class DodawanieMieszkania : Form
    {
        public DodawanieMieszkania()
        {
            InitializeComponent();

            comboBox2.Items.AddRange(Enum.GetNames(typeof(TypMieszkania)).ToArray());
        }

        public int Id { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            House house = new House();

            using (DB db = new DB())
            {
                if (Id > 0)
                {
                    house = db.House.FirstOrDefault(x => x.Id == Id);
                }

                house.Name = textBox1.Text;
                house.Address = textBox2.Text;

                decimal cost;
                if (decimal.TryParse(textBox3.Text, out cost))
                {
                    house.Cost_sm = cost;
                }

                decimal area;
                if (decimal.TryParse(textBox4.Text, out area))
                {
                    house.Area_sm = area;
                }

                house.HouseType_Id = (int)Enum.Parse(typeof(TypMieszkania), comboBox2.SelectedItem.ToString());
                house.Level = int.Parse(comboBox1.SelectedItem.ToString());


                if (Id == 0)
                    db.House.Add(house);

                db.SaveChanges();


                Parking parking = db.Parking.FirstOrDefault(x => x.House_Id == house.Id);

                if (checkBox1.Checked)
                {
                    if (parking != null)
                    {
                        parking.Address = textBox5.Text;
                        parking.Number = textBox6.Text;                        
                    }
                    else
                    {
                        parking = new Parking();

                        parking.House_Id = house.Id;
                        parking.Address = textBox5.Text;
                        parking.Number = textBox6.Text;

                        db.Parking.Add(parking);
                    }
                }
                else if (parking != null)
                {
                    db.Parking.Remove(parking);
                }

                db.SaveChanges();
            }

            DialogResult = DialogResult.OK;
        }

        private void DodawanieMieszkania_Shown(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                House house;
                using (DB db = new DB())
                {
                    house = db.House.FirstOrDefault(x => x.Id == Id);

                    Parking parking = db.Parking.FirstOrDefault(x => x.House_Id == house.Id);

                    if (parking != null)
                    {
                        checkBox1.Checked = true;
                        textBox5.Text = parking.Address;
                        textBox6.Text = parking.Number;
                    }
                }

                textBox1.Text = house.Name;
                textBox2.Text = house.Address;
                textBox3.Text = house.Cost_sm.ToString();
                textBox4.Text = house.Area_sm.ToString();

                comboBox1.SelectedItem = house.Level.ToString();
                comboBox2.SelectedItem = Enum.Parse(typeof(TypMieszkania), house.HouseType_Id.ToString()).ToString();


            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = textBox6.Enabled = ((CheckBox)sender).Checked;
        }
    }
}
