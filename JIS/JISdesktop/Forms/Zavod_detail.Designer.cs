namespace JIS.Forms
{
    partial class Zavod_detail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Zavod_detail));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.staj = new System.Windows.Forms.TextBox();
            this.date = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.vysledekBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jezdec_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kun_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chybyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trbodyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.casDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vyloucenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vysledekBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.staj);
            this.groupBox1.Controls.Add(this.date);
            this.groupBox1.Location = new System.Drawing.Point(21, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informace";
            // 
            // staj
            // 
            this.staj.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.staj.Location = new System.Drawing.Point(184, 41);
            this.staj.Name = "staj";
            this.staj.Size = new System.Drawing.Size(196, 22);
            this.staj.TabIndex = 1;
            // 
            // date
            // 
            this.date.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.date.Location = new System.Drawing.Point(550, 41);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(144, 22);
            this.date.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(468, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Datum";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(31, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pořadatelská stáj";
            this.label2.Click += new System.EventHandler(this.label2_Click);
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
            this.casDataGridViewTextBoxColumn,
            this.vyloucenDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.vysledekBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(21, 169);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(744, 376);
            this.dataGridView1.TabIndex = 5;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(205, 119);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(86, 24);
            this.comboBox2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(85, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Zvolit soutěž";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MistyRose;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.LightCoral;
            this.button1.Location = new System.Drawing.Point(315, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 24);
            this.button1.TabIndex = 5;
            this.button1.Text = "Zobrazit ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // vysledekBindingSource
            // 
            this.vysledekBindingSource.DataSource = typeof(JIS.ORM.Vysledek);
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
            // casDataGridViewTextBoxColumn
            // 
            this.casDataGridViewTextBoxColumn.DataPropertyName = "cas";
            this.casDataGridViewTextBoxColumn.HeaderText = "cas";
            this.casDataGridViewTextBoxColumn.Name = "casDataGridViewTextBoxColumn";
            this.casDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vyloucenDataGridViewTextBoxColumn
            // 
            this.vyloucenDataGridViewTextBoxColumn.DataPropertyName = "vyloucen";
            this.vyloucenDataGridViewTextBoxColumn.HeaderText = "vyloucen";
            this.vyloucenDataGridViewTextBoxColumn.Name = "vyloucenDataGridViewTextBoxColumn";
            this.vyloucenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Zavod_detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 557);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Zavod_detail";
            this.Text = "Detail závodu";
            this.Load += new System.EventHandler(this.Zavod_detail_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vysledekBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox staj;
        private System.Windows.Forms.TextBox date;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource vysledekBindingSource;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn jezdec_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn kun_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn chybyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trbodyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn casDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vyloucenDataGridViewTextBoxColumn;
    }
}