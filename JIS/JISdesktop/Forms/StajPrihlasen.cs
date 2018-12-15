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
using JISdata;
using JISdata.DAO;
using JISdata.Forms;
using JIScore;

namespace JISdesktop.Forms
{
    public partial class StajPrihlasen : Form
    {

        StajFormModel model;
        int i = 0;
        Form parent;

        public StajPrihlasen(Form parent, Staj staj)

        {
            this.parent = parent;
            model = new StajFormModel(staj);
            InitializeComponent();
        }

        private void StajPrihlasen_Load(object sender, EventArgs e)
        {
            textBox1.Text = model.staj.nazev;
            textBox2.Text = model.staj.telefon;
            textBox3.Text = model.maj;
            textBoxUlice.Text = model.adresa.ulice;
            textBoxMesto.Text = model.adresa.mesto;
            textBoxCP.Text = model.adresa.cislo_popisne;

            BindingList<Kun> bindingList = new BindingList<Kun>(model.kone);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingList;

            BindingList<Zavody> bindingListZ = new BindingList<Zavody>(model.zavodyStaj);
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = bindingListZ;

           

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            
            model.saveChanges(textBox2.Text, textBox1.Text, textBoxUlice.Text, textBoxCP.Text, textBoxMesto.Text);
        }

       

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           

            Zavody newZavody = new Zavody();
            newZavody.sid = model.staj.sid;
            newZavody.datum = dateTimePicker1.Value;

            newZavody = ZavodyTable.Insert(newZavody);

            foreach (var soutez in model.newSouteze)
            {
                soutez.zid = newZavody.zid;
                SoutezTable.Insert(soutez);
            }
            textObtiznost.ResetText();
            textLimit.ResetText();
            dateTimePicker1.ResetText();
            model.newSouteze.Clear();
            BindingList<Soutez> bindingList = new BindingList<Soutez>(model.newSouteze);
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.DataSource = bindingList;
            StajPrihlasen_Load(sender, e);

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
            model.newSouteze.Add(soutez);
            BindingList<Soutez> bindingList = new BindingList<Soutez>(model.newSouteze);
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.DataSource = bindingList;
        }

        private void vkládáníVýsledkůToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Vysledky form = new Vysledky(model.staj.sid);
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
