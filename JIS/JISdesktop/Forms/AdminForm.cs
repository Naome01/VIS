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

namespace JISdesktop.Forms
{
    public partial class AdminForm : Form
    { Collection<Osoba> zadosti;
        Osoba newOsoba;
        Osoba oldOsoba;
        Form parent;

        public AdminForm(Form par)
        {
            parent = par;
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

            InitializeBoxes();
        }
        private void InitializeBoxes()
        {
            zadosti = OsobaTable.SelectCHanges();
            zavodyBox.DisplayMember = "prijmeni";
            zavodyBox.ValueMember = "oid";
            zavodyBox.DataSource = zadosti;
            zavodyBox.ResetText();
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
            textBox4.ResetText();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void zavodyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            newOsoba = zadosti.Single(s => s.oid == (int)zavodyBox.SelectedValue);
            textBox1.Text = newOsoba.jmeno;
            textBox2.Text = newOsoba.prijmeni;

            int tmp = (newOsoba.oid * -1) - 1;
           oldOsoba = OsobaTable.Select(tmp);

            textBox3.Text = oldOsoba.jmeno;
            textBox4.Text = oldOsoba.prijmeni;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength ==0) return;
            oldOsoba.jmeno = newOsoba.jmeno;
            oldOsoba.prijmeni = newOsoba.prijmeni;

            OsobaTable.Update(oldOsoba);
            OsobaTable.Delete(newOsoba.oid);
            MessageBox.Show(this, "Uloženo", "", MessageBoxButtons.OK);
            InitializeBoxes();

            //InitializeComponent();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0) return;

            OsobaTable.Delete(newOsoba.oid);
            MessageBox.Show(this, "Email s odůvodněním zaslat na adresu: " + oldOsoba.email, "Zamítnuto", MessageBoxButtons.OK);
            InitializeBoxes();

            // InitializeComponent();


        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            parent.Close();
        }
    }
}
