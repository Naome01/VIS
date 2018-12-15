using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JIScore;
using JISdata;
using JISdata.DAO;

namespace JISdesktop.Forms
{
    public partial class JezdecPrihlasen : Form
    {
        JezdecFormModel model;
        Form parent;
        public JezdecPrihlasen(Form parent, Jezdec jezdec)
        {
            this.parent = parent;
            model = new JezdecFormModel(jezdec);
            InitializeComponent();
        }

        private void JezdecPrihlasen_Load(object sender, EventArgs e)
        {
            textBox1.Text = model.osoba.jmeno;
            textBox2.Text = model.osoba.prijmeni;
            textBox3.Text = model.jezdec.telefon;
            textBox4.Text = model.osoba.email;

            textBoxUlice.Text = model.adresa.ulice;
            textBoxMesto.Text = model.adresa.mesto;
            textBoxCP.Text = model.adresa.cislo_popisne;



            if (model.jezdec.licence.HasValue && !model.jezdec.licence.Value)
            {
                label7.Text = "Nemáte platnou licenci";
                label8.Text = "Nelze se prihlásit na závody";
                soutezBox.Hide();
                comboBox1.Hide();
                zavodyBox.Hide();
                label10.Text = "";
                button2.Hide();
            }
            else
            {
                zavodyBox.DisplayMember = "info";
                zavodyBox.ValueMember = "zid";
                zavodyBox.DataSource = model.zavody;

                int zid = (int)zavodyBox.SelectedValue;
                Collection<Soutez> souteze = model.getSouteze(zid);
                zavodyBox.SelectedValueChanged += ZavodyBox_SelectedValueChanged;

                soutezBox.DisplayMember = "obtiznost";
                soutezBox.ValueMember = "cid";
                soutezBox.DataSource = souteze;


                comboBox1.DisplayMember = "jmeno";
                comboBox1.ValueMember = "cislo_licence";
                comboBox1.DataSource = model.kone;

                zavodyBox.ResetText();
                comboBox1.ResetText();
                soutezBox.ResetText();
            }
                BindingList<Zavody> bindingListZ = new BindingList<Zavody>(model.zavody);
                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.DataSource = bindingListZ;

                BindingList<VysledekJezdce> bindingListV = new BindingList<VysledekJezdce>(model.vysledky);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = bindingListV;

            

        }
        private void ZavodyBox_SelectedValueChanged(object sender, EventArgs e)
        {
            int zid = (int)zavodyBox.SelectedValue;
            Collection<Soutez> souteze = model.getSouteze(zid);
            soutezBox.DisplayMember = "obtiznost";
            soutezBox.ValueMember = "cid";
            soutezBox.DataSource = souteze;
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void zavodyBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            int zid = (int)zavodyBox.SelectedValue;

            string kun = comboBox1.SelectedValue.ToString();
            
            int cid = (int)soutezBox.SelectedValue;

            model.PrihlasDvojici(zid, cid, kun, model.jezdec.cislo_licence);
            BindingList<VysledekJezdce> bindingListV = new BindingList<VysledekJezdce>(model.vysledky);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingListV;
            zavodyBox.ResetText();
            comboBox1.ResetText();
            soutezBox.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String email = textBox4.Text;
           
            Adresa adresa = new Adresa
            {
                aid = -1,
                ulice = textBoxUlice.Text,
                cislo_popisne = textBoxCP.Text,
                mesto = textBoxMesto.Text
            };
            adresa.aid = AdresaTable.getInstance().findAddress(adresa.ulice, adresa.cislo_popisne, adresa.mesto);

            if (adresa.aid == -1) adresa.aid = AdresaTable.getInstance().Insert(adresa);
            model.osoba.adresa = adresa.aid;
            model.osoba.email = email;

            OsobaTable.Update(model.osoba);
            if(!model.osoba.jmeno.Equals(textBox1.Text) || !model.osoba.prijmeni.Equals(textBox2.Text))
            {
                Osoba newOsoba = model.osoba;
                newOsoba.jmeno = textBox1.Text;
                newOsoba.prijmeni = textBox2.Text;
                newOsoba.oid = (model.osoba.oid * -1) - 1;

                OsobaTable.InsertChange(newOsoba);
                MessageBox.Show(this, "Byla zaslána žádost o potvrzení změn", "", MessageBoxButtons.OK);

            }

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want exit?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    parent.Close();
                    break;
            }
        }
    }
}
