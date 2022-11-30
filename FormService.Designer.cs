namespace deneme
{
    partial class FormService
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormService));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_anlikveri = new System.Windows.Forms.Label();
            this.lbl_communicationCounter = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.uygulamaAyarlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exceleAktarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exceldenTabloyaAktarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.fabrikaAyarlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bağlantıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ayarlarıYükleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayarlarıKaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.şifreDeğiştirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.temayıDeğiştirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.darkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsTemasıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yardımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iletişimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.kullanımKılavuzuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.button3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button4, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.button5, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.button6, 5, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1168, 614);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.ImageKey = "4.png";
            this.button3.ImageList = this.imageList1;
            this.button3.Location = new System.Drawing.Point(391, 63);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(188, 44);
            this.button3.TabIndex = 3;
            this.button3.Text = "Fabrika Ayarları";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "upload.png");
            this.imageList1.Images.SetKeyName(1, "download.png");
            this.imageList1.Images.SetKeyName(2, "arrows.png");
            this.imageList1.Images.SetKeyName(3, "1.png");
            this.imageList1.Images.SetKeyName(4, "2.png");
            this.imageList1.Images.SetKeyName(5, "3.png");
            this.imageList1.Images.SetKeyName(6, "4.png");
            this.imageList1.Images.SetKeyName(7, "5.png");
            this.imageList1.Images.SetKeyName(8, "6.png");
            this.imageList1.Images.SetKeyName(9, "7.png");
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.Description,
            this.MinValue,
            this.MaxValue,
            this.DefaultValue,
            this.Unit,
            this.Value});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 12);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(3, 113);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1162, 498);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Code
            // 
            this.Code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Code.FillWeight = 53.29949F;
            this.Code.HeaderText = "Parametreler";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Code.ToolTipText = "Bu parametrelerin girildiği alandır";
            // 
            // Description
            // 
            this.Description.FillWeight = 53.29949F;
            this.Description.HeaderText = "Açıklama";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MinValue
            // 
            this.MinValue.FillWeight = 53.29949F;
            this.MinValue.HeaderText = "Min. Değer";
            this.MinValue.Name = "MinValue";
            this.MinValue.ReadOnly = true;
            this.MinValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MaxValue
            // 
            this.MaxValue.FillWeight = 53.29949F;
            this.MaxValue.HeaderText = "Max. Değer";
            this.MaxValue.Name = "MaxValue";
            this.MaxValue.ReadOnly = true;
            this.MaxValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DefaultValue
            // 
            this.DefaultValue.FillWeight = 60F;
            this.DefaultValue.HeaderText = "Fabrika Ayarları";
            this.DefaultValue.Name = "DefaultValue";
            this.DefaultValue.ReadOnly = true;
            this.DefaultValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Unit
            // 
            this.Unit.FillWeight = 53.29949F;
            this.Unit.HeaderText = "Birim";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Value
            // 
            this.Value.FillWeight = 53.29949F;
            this.Value.HeaderText = "Kullanıcı Girişi";
            this.Value.Name = "Value";
            this.Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 6);
            this.panel1.Controls.Add(this.lbl_anlikveri);
            this.panel1.Controls.Add(this.lbl_communicationCounter);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1162, 54);
            this.panel1.TabIndex = 1;
            // 
            // lbl_anlikveri
            // 
            this.lbl_anlikveri.AutoSize = true;
            this.lbl_anlikveri.ForeColor = System.Drawing.Color.White;
            this.lbl_anlikveri.Location = new System.Drawing.Point(194, 20);
            this.lbl_anlikveri.Name = "lbl_anlikveri";
            this.lbl_anlikveri.Size = new System.Drawing.Size(38, 15);
            this.lbl_anlikveri.TabIndex = 3;
            this.lbl_anlikveri.Text = "label1";
            this.lbl_anlikveri.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_communicationCounter
            // 
            this.lbl_communicationCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_communicationCounter.AutoSize = true;
            this.lbl_communicationCounter.ForeColor = System.Drawing.Color.White;
            this.lbl_communicationCounter.Location = new System.Drawing.Point(1129, 20);
            this.lbl_communicationCounter.Name = "lbl_communicationCounter";
            this.lbl_communicationCounter.Size = new System.Drawing.Size(24, 15);
            this.lbl_communicationCounter.TabIndex = 3;
            this.lbl_communicationCounter.Text = "0/0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(172, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageKey = "1.png";
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(3, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Parametreleri Yükle";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.ImageKey = "2.png";
            this.button2.ImageList = this.imageList1;
            this.button2.Location = new System.Drawing.Point(197, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 44);
            this.button2.TabIndex = 3;
            this.button2.Text = "Parametreleri Oku";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button4.ImageKey = "3.png";
            this.button4.ImageList = this.imageList1;
            this.button4.Location = new System.Drawing.Point(585, 63);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(188, 44);
            this.button4.TabIndex = 4;
            this.button4.Text = "Ayarları Yükle";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button5.ImageKey = "6.png";
            this.button5.ImageList = this.imageList1;
            this.button5.Location = new System.Drawing.Point(779, 63);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(188, 44);
            this.button5.TabIndex = 5;
            this.button5.Text = "Ayarları Kaydet";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button6.ImageKey = "5.png";
            this.button6.ImageList = this.imageList1;
            this.button6.Location = new System.Drawing.Point(973, 63);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(192, 44);
            this.button6.TabIndex = 6;
            this.button6.Text = "Bağlantı Ayarları";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uygulamaAyarlarıToolStripMenuItem,
            this.düzenleToolStripMenuItem,
            this.yardımToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1168, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // uygulamaAyarlarıToolStripMenuItem
            // 
            this.uygulamaAyarlarıToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.uygulamaAyarlarıToolStripMenuItem.Checked = true;
            this.uygulamaAyarlarıToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uygulamaAyarlarıToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exceleAktarToolStripMenuItem,
            this.exceldenTabloyaAktarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.fabrikaAyarlarıToolStripMenuItem,
            this.bağlantıToolStripMenuItem,
            this.toolStripMenuItem2,
            this.ayarlarıYükleToolStripMenuItem,
            this.ayarlarıKaydetToolStripMenuItem});
            this.uygulamaAyarlarıToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.uygulamaAyarlarıToolStripMenuItem.Name = "uygulamaAyarlarıToolStripMenuItem";
            this.uygulamaAyarlarıToolStripMenuItem.Padding = new System.Windows.Forms.Padding(3, 0, 4, 0);
            this.uygulamaAyarlarıToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.uygulamaAyarlarıToolStripMenuItem.Text = "Dosya";
            // 
            // exceleAktarToolStripMenuItem
            // 
            this.exceleAktarToolStripMenuItem.Name = "exceleAktarToolStripMenuItem";
            this.exceleAktarToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.exceleAktarToolStripMenuItem.Text = "Tablodan Excel\'e Aktar";
            this.exceleAktarToolStripMenuItem.Click += new System.EventHandler(this.exceleAktarToolStripMenuItem_Click);
            // 
            // exceldenTabloyaAktarToolStripMenuItem
            // 
            this.exceldenTabloyaAktarToolStripMenuItem.Name = "exceldenTabloyaAktarToolStripMenuItem";
            this.exceldenTabloyaAktarToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.exceldenTabloyaAktarToolStripMenuItem.Text = "Excelden Tabloya Aktar";
            this.exceldenTabloyaAktarToolStripMenuItem.Click += new System.EventHandler(this.exceldenTabloyaAktarToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(192, 6);
            // 
            // fabrikaAyarlarıToolStripMenuItem
            // 
            this.fabrikaAyarlarıToolStripMenuItem.Name = "fabrikaAyarlarıToolStripMenuItem";
            this.fabrikaAyarlarıToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.fabrikaAyarlarıToolStripMenuItem.Text = "Fabrika Ayarları";
            this.fabrikaAyarlarıToolStripMenuItem.Click += new System.EventHandler(this.fabrikaAyarlarıToolStripMenuItem_Click);
            // 
            // bağlantıToolStripMenuItem
            // 
            this.bağlantıToolStripMenuItem.Name = "bağlantıToolStripMenuItem";
            this.bağlantıToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.bağlantıToolStripMenuItem.Text = "Bağlantı Ayarları";
            this.bağlantıToolStripMenuItem.Click += new System.EventHandler(this.bağlantıToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(192, 6);
            // 
            // ayarlarıYükleToolStripMenuItem
            // 
            this.ayarlarıYükleToolStripMenuItem.Name = "ayarlarıYükleToolStripMenuItem";
            this.ayarlarıYükleToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.ayarlarıYükleToolStripMenuItem.Text = "Ayarları Yükle";
            this.ayarlarıYükleToolStripMenuItem.Click += new System.EventHandler(this.ayarlarıYükleToolStripMenuItem_Click);
            // 
            // ayarlarıKaydetToolStripMenuItem
            // 
            this.ayarlarıKaydetToolStripMenuItem.Name = "ayarlarıKaydetToolStripMenuItem";
            this.ayarlarıKaydetToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.ayarlarıKaydetToolStripMenuItem.Text = "Ayarları Kaydet";
            this.ayarlarıKaydetToolStripMenuItem.Click += new System.EventHandler(this.ayarlarıKaydetToolStripMenuItem_Click);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.şifreDeğiştirToolStripMenuItem1,
            this.toolStripMenuItem4,
            this.temayıDeğiştirToolStripMenuItem1});
            this.düzenleToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.düzenleToolStripMenuItem.Text = "Ayarlar";
            // 
            // şifreDeğiştirToolStripMenuItem1
            // 
            this.şifreDeğiştirToolStripMenuItem1.Name = "şifreDeğiştirToolStripMenuItem1";
            this.şifreDeğiştirToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.şifreDeğiştirToolStripMenuItem1.Text = "Şifre Değiştir";
            this.şifreDeğiştirToolStripMenuItem1.Click += new System.EventHandler(this.şifreDeğiştirToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(151, 6);
            // 
            // temayıDeğiştirToolStripMenuItem1
            // 
            this.temayıDeğiştirToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.darkToolStripMenuItem,
            this.lightToolStripMenuItem,
            this.windowsTemasıToolStripMenuItem});
            this.temayıDeğiştirToolStripMenuItem1.Name = "temayıDeğiştirToolStripMenuItem1";
            this.temayıDeğiştirToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.temayıDeğiştirToolStripMenuItem1.Text = "Temayı Değiştir";
            // 
            // darkToolStripMenuItem
            // 
            this.darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            this.darkToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.darkToolStripMenuItem.Text = "Dark";
            this.darkToolStripMenuItem.Click += new System.EventHandler(this.darkToolStripMenuItem_Click);
            // 
            // lightToolStripMenuItem
            // 
            this.lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            this.lightToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.lightToolStripMenuItem.Text = "Light";
            this.lightToolStripMenuItem.Click += new System.EventHandler(this.lightToolStripMenuItem_Click);
            // 
            // windowsTemasıToolStripMenuItem
            // 
            this.windowsTemasıToolStripMenuItem.Name = "windowsTemasıToolStripMenuItem";
            this.windowsTemasıToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.windowsTemasıToolStripMenuItem.Text = "Windows teması";
            this.windowsTemasıToolStripMenuItem.Click += new System.EventHandler(this.windowsTemasıToolStripMenuItem_Click);
            // 
            // yardımToolStripMenuItem
            // 
            this.yardımToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iletişimToolStripMenuItem,
            this.toolStripMenuItem6,
            this.kullanımKılavuzuToolStripMenuItem1});
            this.yardımToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.yardımToolStripMenuItem.Name = "yardımToolStripMenuItem";
            this.yardımToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.yardımToolStripMenuItem.Text = "Yardım";
            // 
            // iletişimToolStripMenuItem
            // 
            this.iletişimToolStripMenuItem.Name = "iletişimToolStripMenuItem";
            this.iletişimToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.iletişimToolStripMenuItem.Text = "Hakkında";
            this.iletişimToolStripMenuItem.Click += new System.EventHandler(this.hakkındaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(165, 6);
            // 
            // kullanımKılavuzuToolStripMenuItem1
            // 
            this.kullanımKılavuzuToolStripMenuItem1.Name = "kullanımKılavuzuToolStripMenuItem1";
            this.kullanımKılavuzuToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.kullanımKılavuzuToolStripMenuItem1.Text = "Kullanım Kılavuzu";
            this.kullanımKılavuzuToolStripMenuItem1.Click += new System.EventHandler(this.kullanımKılavuzuToolStripMenuItem1_Click);
            // 
            // FormService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 638);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametre Ayarları";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormService_FormClosed);
            this.Load += new System.EventHandler(this.FormService_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Button button3;
        private Button button1;
        private Button button2;
        private Button button4;
        private Button button5;
        private Button button6;
        private PictureBox pictureBox1;
        private ImageList imageList1;
        private OpenFileDialog openFileDialog1;
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn MinValue;
        private DataGridViewTextBoxColumn MaxValue;
        private DataGridViewTextBoxColumn DefaultValue;
        private DataGridViewTextBoxColumn Unit;
        private DataGridViewTextBoxColumn Value;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem düzenleToolStripMenuItem;
        private ToolStripMenuItem şifreDeğiştirToolStripMenuItem1;
        private ToolStripMenuItem temayıDeğiştirToolStripMenuItem1;
        private ToolStripMenuItem yardımToolStripMenuItem;
        private ToolStripMenuItem iletişimToolStripMenuItem;
        private ToolStripMenuItem darkToolStripMenuItem;
        private ToolStripMenuItem lightToolStripMenuItem;
        private ToolStripMenuItem uygulamaAyarlarıToolStripMenuItem;
        private ToolStripMenuItem exceleAktarToolStripMenuItem;
        private ToolStripMenuItem exceldenTabloyaAktarToolStripMenuItem;
        private ToolStripMenuItem kullanımKılavuzuToolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem ayarlarıYükleToolStripMenuItem;
        private ToolStripMenuItem ayarlarıKaydetToolStripMenuItem;
        private ToolStripMenuItem bağlantıToolStripMenuItem;
        private ToolStripMenuItem fabrikaAyarlarıToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripMenuItem windowsTemasıToolStripMenuItem;
        private Label lbl_communicationCounter;
        private Label lbl_anlikveri;
    }
}