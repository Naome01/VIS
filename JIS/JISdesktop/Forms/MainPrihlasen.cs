using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using JISdata;
using JISdata.DAO;
using JISdesktop.Forms;
using JISdata.Forms;

namespace JISdesktop.Forms
{
    public partial class MainPrihlasen : Form
    {
        public Staj staj;
        public Adresa adresa;
        public string maj;
        int i = 0;
        Collection<Soutez> newSouteze = new Collection<Soutez>();
        Form parent;
        
        public MainPrihlasen(Form parent, Staj staj)

        {
            this.parent = parent;
            InitializeComponent();
            this.staj = staj;
            adresa = AdresaTable.getInstance().getByID(staj.adresa);
        }

        private void MainPrihlasen_Load(object sender, EventArgs e)
        {
            textBox1.Text = staj.nazev;
            textBox2.Text = staj.telefon;
            maj =  OsobaTable.Select(staj.majitel).prijmeni + " " +  OsobaTable.Select(staj.majitel).jmeno;
            textBox3.Text = maj;
            textBox4.Text = adresa.ToString();

            Collection< Kun> kone =   KunTable.Select(staj.sid);
            BindingList< Kun> bindingList = new BindingList< Kun>(kone);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingList;

            Collection< Jezdec> jezdci =   JezdecTable.SelectStaj(staj.sid);
            BindingList< Jezdec> bindingListJ = new BindingList< Jezdec>(jezdci);
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = bindingListJ;

            Collection<Zavody> zavody =  ZavodyTable.SelectFuture(DateTime.Now);
            zavodyBox.DisplayMember = "info";
            zavodyBox.ValueMember = "zid";
            zavodyBox.DataSource = zavody;
            
            int zid = (int)zavodyBox.SelectedValue;
            Collection<Soutez> souteze =  SoutezTable.Select_zavod(zid);
            zavodyBox.SelectedValueChanged += ZavodyBox_SelectedValueChanged;

            soutezBox.DisplayMember = "obtiznost";
            soutezBox.ValueMember = "cid";
            soutezBox.DataSource = souteze;
            
            jezdecBox.DisplayMember = "jmeno";
            jezdecBox.ValueMember = "cislo_licence";
            jezdecBox.DataSource = jezdci;
                       
        }

        private void ZavodyBox_SelectedValueChanged(object sender, EventArgs e)
        {
            int zid = (int)zavodyBox.SelectedValue;
            Collection<Soutez> souteze =  SoutezTable.Select_zavod(zid);
            soutezBox.DisplayMember = "obtiznost";
            soutezBox.ValueMember = "cid";
            soutezBox.DataSource = souteze;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            staj.telefon = textBox2.Text;
            Adresa adresa = new Adresa();
            //staj.adresa = textBox4.Text;
            staj.nazev = textBox1.Text;
            if(maj != textBox3.Text)
            {
                errorProvider1.SetError(textBox3, "Majitele nejze změnit, zbytek údajů byl úspěšně změněn");
            }
             StajTable.Update(staj);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            int zid = (int)zavodyBox.SelectedValue;
            string cislo_licence = (string)jezdecBox.SelectedValue;
            if ( JezdecTable.Select(cislo_licence).licence == false)
            {
                errorProvider1.SetError(jezdecBox, "Nelze přihlásit jezdce bez platné licence.");
                return;
            }
            string kun = kunText.Text;
            if (kun == null ||  KunTable.Select(kun) == null)
            {
                errorProvider1.SetError(kunText, "Nutno zadat platnou hodnotu.");
                return;
            }
            int cid = (int)soutezBox.SelectedValue;
            if ( KunTable.Select(kun).licence == false)
            {
                errorProvider1.SetError(kunText, "Nelze přihlásit koně bez platné licence.");
                return;
            }
             VysledekTable.Prihlas( KunTable.Select(kun),  JezdecTable.Select(cislo_licence),  SoutezTable.Select(cid));
            zavodyBox.ResetText();
            jezdecBox.ResetText();
            kunText.ResetText();
            soutezBox.ResetText();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Zavody newZavody = new Zavody();
            newZavody.sid = staj.sid;
            newZavody.datum = dateTimePicker1.Value;

            newZavody =  ZavodyTable.Insert(newZavody);

            foreach(var soutez in newSouteze)
            {
                soutez.zid = newZavody.zid;
                 SoutezTable.Insert(soutez);
            }
            textObtiznost.ResetText();
            textLimit.ResetText();
            dateTimePicker1.ResetText();
            newSouteze.Clear();
            BindingList< Soutez> bindingList = new BindingList< Soutez>(newSouteze);
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.DataSource = bindingList;
            MainPrihlasen_Load(sender, e);
            
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Soutez soutez = new Soutez();
            soutez.obtiznost = textObtiznost.Text;
            TimeSpan j;
            if (TimeSpan.TryParse(textLimit.Text, out j))
            {
                soutez.limit = j;
            }
            else
            {
                errorProvider1.SetError(textLimit, "Špatná hodnota, zadejte čas ve formátu hh:mm:ss");
                return;
            }
            newSouteze.Add(soutez);
            BindingList< Soutez> bindingList = new BindingList< Soutez>(newSouteze);
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.DataSource = bindingList;
        }

        private void vkládáníVýsledkůToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Vysledky form = new Vysledky(staj.sid);
            form.Show();
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
