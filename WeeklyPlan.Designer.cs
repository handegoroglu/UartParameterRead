namespace deneme
{
    partial class WeeklyPlan
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
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Saat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pazartesi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salı = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Çarşamba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Perşembe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cumartesi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pazar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(847, 891);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(839, 863);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Günler";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Saat,
            this.Pazartesi,
            this.Salı,
            this.Çarşamba,
            this.Perşembe,
            this.Cuma,
            this.Cumartesi,
            this.Pazar});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(839, 863);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Saat
            // 
            this.Saat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Saat.HeaderText = "Saat";
            this.Saat.Name = "Saat";
            this.Saat.ReadOnly = true;
            this.Saat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Pazartesi
            // 
            this.Pazartesi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Pazartesi.HeaderText = "Pazartesi";
            this.Pazartesi.Name = "Pazartesi";
            this.Pazartesi.ReadOnly = true;
            this.Pazartesi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Salı
            // 
            this.Salı.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Salı.HeaderText = "Salı";
            this.Salı.Name = "Salı";
            this.Salı.ReadOnly = true;
            this.Salı.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Çarşamba
            // 
            this.Çarşamba.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Çarşamba.HeaderText = "Çarşamba";
            this.Çarşamba.Name = "Çarşamba";
            this.Çarşamba.ReadOnly = true;
            this.Çarşamba.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Perşembe
            // 
            this.Perşembe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Perşembe.HeaderText = "Perşembe";
            this.Perşembe.Name = "Perşembe";
            this.Perşembe.ReadOnly = true;
            this.Perşembe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Cuma
            // 
            this.Cuma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cuma.HeaderText = "Cuma";
            this.Cuma.Name = "Cuma";
            this.Cuma.ReadOnly = true;
            this.Cuma.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Cumartesi
            // 
            this.Cumartesi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cumartesi.HeaderText = "Cumartesi";
            this.Cumartesi.Name = "Cumartesi";
            this.Cumartesi.ReadOnly = true;
            this.Cumartesi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Pazar
            // 
            this.Pazar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Pazar.HeaderText = "Pazar";
            this.Pazar.Name = "Pazar";
            this.Pazar.ReadOnly = true;
            this.Pazar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(839, 863);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hafta İçi";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(839, 863);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Hafta Sonu";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // WeeklyPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 889);
            this.Controls.Add(this.tabControl2);
            this.Name = "WeeklyPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WeeklyPlan";
            this.Load += new System.EventHandler(this.WeeklyPlan_Load);
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl2;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Saat;
        private DataGridViewTextBoxColumn Pazartesi;
        private DataGridViewTextBoxColumn Salı;
        private DataGridViewTextBoxColumn Çarşamba;
        private DataGridViewTextBoxColumn Perşembe;
        private DataGridViewTextBoxColumn Cuma;
        private DataGridViewTextBoxColumn Cumartesi;
        private DataGridViewTextBoxColumn Pazar;
    }
}
