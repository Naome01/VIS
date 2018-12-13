using System;
using System.Collections.Generic;
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
    public partial class Prihlaseni : Form
    {
        public int id;
        
        public Prihlaseni(int ID)
        {
            InitializeComponent();
            textID.Text = ID.ToString();
            
            textHeslo.PasswordChar = '*';
        }
        public Prihlaseni()
        {
            InitializeComponent();

            textHeslo.PasswordChar = '*';
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Prihlaseni_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id;
            
            if (int.TryParse(textID.Text, out id))
            {
                Staj staj = StajTable.Select(id);
                if (staj.heslo == textHeslo.Text)
                {
                   
                    MainPrihlasen form = new MainPrihlasen(this, staj);
                    form.Show();
                    this.Hide();
                }
                else errorProvider.SetError(textHeslo, "Špatné ID nebo heslo.");
            }

            else errorProvider.SetError(textID, "Špatné ID.");

        }
    }
}
