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
                   
                    StajPrihlasen form = new StajPrihlasen(this, staj);
                    form.Show();
                    this.Hide();
                }
                else errorProvider.SetError(textHeslo, "Špatné ID nebo heslo.");
            }
            else if(textID.Text.Equals("Admin") && textHeslo.Text.Equals("AdminHeslo"))
            {
                AdminForm form = new AdminForm(this);
                form.Show();
                this.Hide();
            }

            else
            {
                Jezdec jezdec = JezdecTable.Select(textID.Text);
                if(jezdec == null) errorProvider.SetError(textHeslo, "Špatné ID");
                if (jezdec.heslo == textHeslo.Text)
                {

                    JezdecPrihlasen form = new JezdecPrihlasen(this, jezdec);
                    form.Show();
                    this.Hide();
                }
                else errorProvider.SetError(textHeslo, "Špatné ID nebo heslo.");

            }

        }
    }
}
