namespace deneme
{
    partial class FormRemotControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRemotControl));
            this.ac_button = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.kademe1_button = new System.Windows.Forms.Button();
            this.kademe2_button = new System.Windows.Forms.Button();
            this.kademe3_button = new System.Windows.Forms.Button();
            this.baglantı_ayarbutton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kapat_button = new System.Windows.Forms.Button();
            this.ayar_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ac_button
            // 
            this.ac_button.ImageIndex = 6;
            this.ac_button.ImageList = this.imageList1;
            this.ac_button.Location = new System.Drawing.Point(1, 131);
            this.ac_button.Name = "ac_button";
            this.ac_button.Size = new System.Drawing.Size(178, 28);
            this.ac_button.TabIndex = 0;
            this.ac_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ac_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ac_button.UseVisualStyleBackColor = true;
            this.ac_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "logo-h(1).png");
            this.imageList1.Images.SetKeyName(1, "shutdown (1).png");
            this.imageList1.Images.SetKeyName(2, "shutdown.png");
            this.imageList1.Images.SetKeyName(3, "settings (1).png");
            this.imageList1.Images.SetKeyName(4, "gears.png");
            this.imageList1.Images.SetKeyName(5, "5.png");
            this.imageList1.Images.SetKeyName(6, "power-off (1).png");
            this.imageList1.Images.SetKeyName(7, "power-off.png");
            this.imageList1.Images.SetKeyName(8, "settingsss.png");
            this.imageList1.Images.SetKeyName(9, "1kademe.png");
            this.imageList1.Images.SetKeyName(10, "2kademe.png");
            this.imageList1.Images.SetKeyName(11, "3kademe.png");
            this.imageList1.Images.SetKeyName(12, "usb.png");
            this.imageList1.Images.SetKeyName(13, "calendar (1).png");
            this.imageList1.Images.SetKeyName(14, "calendar (2).png");
            this.imageList1.Images.SetKeyName(15, "calendar.png");
            this.imageList1.Images.SetKeyName(16, "schedule.png");
            // 
            // kademe1_button
            // 
            this.kademe1_button.ImageIndex = 9;
            this.kademe1_button.ImageList = this.imageList1;
            this.kademe1_button.Location = new System.Drawing.Point(1, 197);
            this.kademe1_button.Name = "kademe1_button";
            this.kademe1_button.Size = new System.Drawing.Size(178, 28);
            this.kademe1_button.TabIndex = 2;
            this.kademe1_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kademe1_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.kademe1_button.UseVisualStyleBackColor = true;
            // 
            // kademe2_button
            // 
            this.kademe2_button.ImageIndex = 10;
            this.kademe2_button.ImageList = this.imageList1;
            this.kademe2_button.Location = new System.Drawing.Point(1, 230);
            this.kademe2_button.Name = "kademe2_button";
            this.kademe2_button.Size = new System.Drawing.Size(178, 28);
            this.kademe2_button.TabIndex = 3;
            this.kademe2_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kademe2_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.kademe2_button.UseVisualStyleBackColor = true;
            // 
            // kademe3_button
            // 
            this.kademe3_button.ImageIndex = 11;
            this.kademe3_button.ImageList = this.imageList1;
            this.kademe3_button.Location = new System.Drawing.Point(1, 263);
            this.kademe3_button.Name = "kademe3_button";
            this.kademe3_button.Size = new System.Drawing.Size(178, 28);
            this.kademe3_button.TabIndex = 4;
            this.kademe3_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kademe3_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.kademe3_button.UseVisualStyleBackColor = true;
            // 
            // baglantı_ayarbutton
            // 
            this.baglantı_ayarbutton.ImageIndex = 12;
            this.baglantı_ayarbutton.ImageList = this.imageList1;
            this.baglantı_ayarbutton.Location = new System.Drawing.Point(6, 94);
            this.baglantı_ayarbutton.Name = "baglantı_ayarbutton";
            this.baglantı_ayarbutton.Size = new System.Drawing.Size(45, 30);
            this.baglantı_ayarbutton.TabIndex = 5;
            this.baglantı_ayarbutton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.baglantı_ayarbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.baglantı_ayarbutton.UseVisualStyleBackColor = true;
            this.baglantı_ayarbutton.Click += new System.EventHandler(this.button6_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // kapat_button
            // 
            this.kapat_button.ImageIndex = 7;
            this.kapat_button.ImageList = this.imageList1;
            this.kapat_button.Location = new System.Drawing.Point(1, 164);
            this.kapat_button.Name = "kapat_button";
            this.kapat_button.Size = new System.Drawing.Size(178, 28);
            this.kapat_button.TabIndex = 1;
            this.kapat_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kapat_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.kapat_button.UseVisualStyleBackColor = true;
            // 
            // ayar_button
            // 
            this.ayar_button.ImageIndex = 5;
            this.ayar_button.ImageList = this.imageList1;
            this.ayar_button.Location = new System.Drawing.Point(128, 94);
            this.ayar_button.Name = "ayar_button";
            this.ayar_button.Size = new System.Drawing.Size(45, 30);
            this.ayar_button.TabIndex = 7;
            this.ayar_button.UseVisualStyleBackColor = true;
            this.ayar_button.Click += new System.EventHandler(this.button7_Click);
            // 
            // button1
            // 
            this.button1.ImageIndex = 14;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(67, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 30);
            this.button1.TabIndex = 8;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormRemotControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(180, 297);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ayar_button);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.baglantı_ayarbutton);
            this.Controls.Add(this.kademe3_button);
            this.Controls.Add(this.kademe2_button);
            this.Controls.Add(this.kademe1_button);
            this.Controls.Add(this.kapat_button);
            this.Controls.Add(this.ac_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRemotControl";
            this.Text = "Parametre";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button ac_button;
        private ImageList imageList1;
        private Button kademe1_button;
        private Button kademe2_button;
        private Button kademe3_button;
        private Button baglantı_ayarbutton;
        private PictureBox pictureBox1;
        private Button kapat_button;
        private Button ayar_button;
        private Button button1;
    }
}