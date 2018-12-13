using JISdata;
namespace JISdata.Forms
{
    partial class Vysledky
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vysledky));
            this.zavodyBox = new System.Windows.Forms.ComboBox();
            this.soutezBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.jezdec_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kun_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chybyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trbodyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vyloucenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.casDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vysledekBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vysledekBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // zavodyBox
            // 
            this.zavodyBox.FormattingEnabled = true;
            this.zavodyBox.Location = new System.Drawing.Point(130, 34);
            this.zavodyBox.Name = "zavodyBox";
            this.zavodyBox.Size = new System.Drawing.Size(212, 24);
            this.zavodyBox.TabIndex = 20;
            // 
            // soutezBox
            // 
            this.soutezBox.FormattingEnabled = true;
            this.soutezBox.Location = new System.Drawing.Point(130, 74);
            this.soutezBox.Name = "soutezBox";
            this.soutezBox.Size = new System.Drawing.Size(63, 24);
            this.soutezBox.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Závody";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Soutěž";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jezdec_name,
            this.kun_name,
            this.chybyDataGridViewTextBoxColumn,
            this.trbodyDataGridViewTextBoxColumn,
            this.vyloucenDataGridViewTextBoxColumn,
            this.casDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.vysledekBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(37, 131);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(343, 357);
            this.dataGridView1.TabIndex = 21;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // jezdec_name
            // 
            this.jezdec_name.DataPropertyName = "jezdec_name";
            this.jezdec_name.HeaderText = "Jezdec";
            this.jezdec_name.Name = "jezdec_name";
            this.jezdec_name.ReadOnly = true;
            // 
            // kun_name
            // 
            this.kun_name.DataPropertyName = "kun_name";
            this.kun_name.HeaderText = "Kůň";
            this.kun_name.Name = "kun_name";
            this.kun_name.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(488, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Jezdec";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(449, 398);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Trestné body";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(475, 355);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Vyloučen";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(508, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Čas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(463, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "Počet chyb";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(507, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "Kůň";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(585, 161);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(171, 22);
            this.textBox1.TabIndex = 28;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(585, 305);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(171, 22);
            this.textBox2.TabIndex = 29;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(585, 208);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(171, 22);
            this.textBox4.TabIndex = 31;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(585, 398);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(171, 22);
            this.textBox5.TabIndex = 32;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(585, 355);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 33;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(536, 456);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 32);
            this.button1.TabIndex = 34;
            this.button1.Text = "Uložit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chybyDataGridViewTextBoxColumn
            // 
            this.chybyDataGridViewTextBoxColumn.DataPropertyName = "chyby";
            this.chybyDataGridViewTextBoxColumn.HeaderText = "chyby";
            this.chybyDataGridViewTextBoxColumn.Name = "chybyDataGridViewTextBoxColumn";
            this.chybyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // trbodyDataGridViewTextBoxColumn
            // 
            this.trbodyDataGridViewTextBoxColumn.DataPropertyName = "tr_body";
            this.trbodyDataGridViewTextBoxColumn.HeaderText = "tr_body";
            this.trbodyDataGridViewTextBoxColumn.Name = "trbodyDataGridViewTextBoxColumn";
            this.trbodyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vyloucenDataGridViewTextBoxColumn
            // 
            this.vyloucenDataGridViewTextBoxColumn.DataPropertyName = "vyloucen";
            this.vyloucenDataGridViewTextBoxColumn.HeaderText = "vyloucen";
            this.vyloucenDataGridViewTextBoxColumn.Name = "vyloucenDataGridViewTextBoxColumn";
            this.vyloucenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // casDataGridViewTextBoxColumn
            // 
            this.casDataGridViewTextBoxColumn.DataPropertyName = "cas";
            this.casDataGridViewTextBoxColumn.HeaderText = "cas";
            this.casDataGridViewTextBoxColumn.Name = "casDataGridViewTextBoxColumn";
            this.casDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vysledekBindingSource
            // 
            this.vysledekBindingSource.DataSource = typeof(Vysledek);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(585, 255);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(86, 22);
            this.numericUpDown1.TabIndex = 35;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Vysledky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 523);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.zavodyBox);
            this.Controls.Add(this.soutezBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Vysledky";
            this.Text = "Výsledky";
            this.Load += new System.EventHandler(this.Vysledky_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vysledekBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox zavodyBox;
        private System.Windows.Forms.ComboBox soutezBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn jezdec_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn kun_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn chybyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trbodyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vyloucenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn casDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource vysledekBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}