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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(-3, -2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 527);
            this.tabControl1.TabIndex = 1;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "00:00 / 01:00",
            "01:00 / 02:00",
            "02:00 / 03:00",
            "03:00 / 04:00",
            "04:00 / 05:00",
            "05:00 / 06:00",
            "06:00 / 07:00",
            "07:00 / 08:00",
            "08:00 / 09:00",
            "09:00 / 10:00",
            "10:00 / 11:00",
            "11:00 / 12:00",
            "12:00 / 13:00",
            "13:00 / 14:00",
            "14:00 / 15:00",
            "15:00 / 16:00",
            "16:00 / 17:00",
            "17:00 / 18:00",
            "18:00 / 19:00",
            "19:00 / 20:00",
            "20:00 / 21:00",
            "21:00 / 22:00",
            "22:00 / 23:00",
            "23:00 / 24:00"});
            this.checkedListBox1.Location = new System.Drawing.Point(28, 76);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 436);
            this.checkedListBox1.TabIndex = 2;
            // 
            // WeeklyPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 524);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "WeeklyPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WeeklyPlan";
            this.Load += new System.EventHandler(this.WeeklyPlan_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Saat;
        private DataGridViewTextBoxColumn Pazartesi;
        private DataGridViewTextBoxColumn Çarşamba;
        private DataGridViewTextBoxColumn Perşembe;
        private DataGridViewTextBoxColumn Salı;
        private DataGridViewTextBoxColumn Cuma;
        private DataGridViewTextBoxColumn Cumartesi;
        private DataGridViewTextBoxColumn Pazar;
    }
}