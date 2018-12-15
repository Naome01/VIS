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
using JIScore;

namespace JISdata.Forms
{
    public partial class Vysledky : Form
    {
        VysledekFormModel model;
        public Vysledky(int sid)
        {
            InitializeComponent();
            model = new VysledekFormModel(sid);
        }

        private void Vysledky_Load(object sender, EventArgs e)
        {
            zavodyBox.DisplayMember = "info";
            zavodyBox.ValueMember = "zid";
            zavodyBox.DataSource = model.zavody;

            model.zid = (int)zavodyBox.SelectedValue;
            model.reloadSouteze();
            zavodyBox.SelectedValueChanged += ZavodyBox_SelectedValueChanged;

            soutezBox.DisplayMember = "obtiznost";
            soutezBox.ValueMember = "cid";
            soutezBox.DataSource = model.souteze;

            model.cid = (int)soutezBox.SelectedValue;

            soutezBox.SelectedValueChanged += SoutezBox_SelectedValueChanged;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowData();
        }
        private void ShowData()
        {
            Vysledek vysledek = DejVysledek();
            if (vysledek != null)
            {
                textBox1.Text = vysledek.jezdec_name;
                textBox4.Text = vysledek.kun_name;
                if (!vysledek.chyby.HasValue) numericUpDown1.Value = 0;
                else numericUpDown1.Value = vysledek.chyby.Value;
                if (!vysledek.cas.HasValue) textBox2.Text = "";
                else textBox2.Text = vysledek.cas.ToString();
                if (!vysledek.tr_body.HasValue) textBox5.Text = "";
                else textBox5.Text = vysledek.tr_body.ToString();
                if (!vysledek.vyloucen.HasValue) checkBox1.CheckState = CheckState.Unchecked;
                else
                {
                    if (vysledek.vyloucen.Value) checkBox1.CheckState = CheckState.Checked;
                    else checkBox1.CheckState = CheckState.Unchecked;
                }
            }
        }

        private  Vysledek DejVysledek()
        {
            // The "SelectionMode" property of the data grid view must be set to "FullRowSelect".
            if (dataGridView1.SelectedRows.Count == 1)
            {
                 Vysledek vysledek = dataGridView1.SelectedRows[0].DataBoundItem as  Vysledek;
                return vysledek;
            }
            else
            {
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            Vysledek vysledek = DejVysledek();

            vysledek.chyby = (int)numericUpDown1.Value;
            TimeSpan j;
            if (TimeSpan.TryParse(textBox2.Text, out j))
            {
                vysledek.cas = j;
            }
            else
            {
                errorProvider1.SetError(textBox2, "Špatná hodnota, zadejte čas ve formátu hh:mm:ss");
                return;
            }

            if (checkBox1.CheckState == CheckState.Checked) vysledek.vyloucen = true;
            else vysledek.vyloucen = false;

            model.updateVysledek(vysledek);
            vysledek =   VysledekTable.SelectId(vysledek.did, vysledek.cid);

            model.cid = (int)soutezBox.SelectedValue;

            Collection<Vysledek> vysledeky = VysledekTable.SelectSoutez(model.cid);
            BindingList<Vysledek> bindingList = new BindingList<Vysledek>(vysledeky);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingList;

        }

       

        private void SoutezBox_SelectedValueChanged(object sender, EventArgs e)
        {
            model.cid = (int)soutezBox.SelectedValue;

            Collection<Vysledek> vysledek = VysledekTable.SelectSoutez(model.cid);
            BindingList<Vysledek> bindingList = new BindingList<Vysledek>(vysledek);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingList;
        }

        private void ZavodyBox_SelectedValueChanged(object sender, EventArgs e)
        {
            model.zid = (int)zavodyBox.SelectedValue;
            model.reloadSouteze();
            soutezBox.DisplayMember = "obtiznost";
            soutezBox.ValueMember = "cid";
            soutezBox.DataSource = model.souteze;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                numericUpDown1.Value = 0;
                textBox2.Text = "";
                numericUpDown1.ReadOnly = true;
                textBox2.ReadOnly = true;
            }
            if (!checkBox1.Checked)
            {
                numericUpDown1.ReadOnly = false;
                textBox2.ReadOnly = false;
            }
        }
    }
}
