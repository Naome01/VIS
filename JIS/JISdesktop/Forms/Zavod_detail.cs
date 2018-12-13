using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JIS.Forms
{
    public partial class Zavod_detail : Form
    {
        private ORM.Zavody zavod;
        private bool newRecord;


        public Zavod_detail()
        {
            InitializeComponent();
        }

        private void Zavod_detail_Load(object sender, EventArgs e)
        {

        }

        public bool OpenRecord(object primaryKey)
        {
            if (primaryKey != null)
            {
                int zid = (int)primaryKey;
                zavod = ORM.DAO.Sqls.ZavodyTable.Select(zid);
                newRecord = false;
            }
            
            BindData();
            return true;
        }

        private void BindData()
        {
            Collection<ORM.Soutez> souteze = ORM.DAO.Sqls.SoutezTable.Select_zavod(zavod.zid);
            comboBox2.DisplayMember = "obtiznost";
            comboBox2.ValueMember = "cid";
            comboBox2.DataSource = souteze;

            if (zavod != null)
            {
                staj.Text = zavod.stajName;
            }
            else
            {
                staj.Text = string.Empty;
            }

            date.Text = zavod.datum.ToShortDateString();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cid = (int)comboBox2.SelectedValue;

            Collection<JIS.ORM.Vysledek> vysledek = JIS.ORM.DAO.Sqls.VysledekTable.SelectSoutez(cid);
            BindingList<JIS.ORM.Vysledek> bindingList = new BindingList<JIS.ORM.Vysledek>(vysledek);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingList;
            
        }
    }
}
