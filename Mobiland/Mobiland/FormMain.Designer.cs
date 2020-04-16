namespace Mobiland
{
    partial class FormMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemCatalog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelStaff = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.buttonShowReceipt = new System.Windows.Forms.Button();
            this.buttonCloseReceipt = new System.Windows.Forms.Button();
            this.buttonAddProductToReceipt = new System.Windows.Forms.Button();
            this.buttonCreateReceipt = new System.Windows.Forms.Button();
            this.labelSelectDate = new System.Windows.Forms.Label();
            this.comboBoxSelectStaff = new System.Windows.Forms.ComboBox();
            this.labelSelectStaff = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Product_key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category_key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manufacturer_key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobilandDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobilandDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.Black;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCatalog,
            this.toolStripMenuItemAbout,
            this.toolStripMenuItemExit});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItemCatalog
            // 
            this.toolStripMenuItemCatalog.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItemCatalog.Name = "toolStripMenuItemCatalog";
            this.toolStripMenuItemCatalog.Size = new System.Drawing.Size(87, 20);
            this.toolStripMenuItemCatalog.Text = "Справочник";
            this.toolStripMenuItemCatalog.Click += new System.EventHandler(this.toolStripMenuItemCatalog_Click);
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(94, 20);
            this.toolStripMenuItemAbout.Text = "О программе";
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(54, 20);
            this.toolStripMenuItemExit.Text = "Выход";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.buttonClear);
            this.panel2.Controls.Add(this.labelDate);
            this.panel2.Controls.Add(this.labelStaff);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.textBoxSearch);
            this.panel2.Controls.Add(this.labelSearch);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.buttonCreateReceipt);
            this.panel2.Controls.Add(this.labelSelectDate);
            this.panel2.Controls.Add(this.comboBoxSelectStaff);
            this.panel2.Controls.Add(this.labelSelectStaff);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 523);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1264, 206);
            this.panel2.TabIndex = 1;
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.AutoSize = true;
            this.buttonClear.BackColor = System.Drawing.Color.Black;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Location = new System.Drawing.Point(1216, 59);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(30, 31);
            this.buttonClear.TabIndex = 8;
            this.buttonClear.Text = "×";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Visible = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(482, 22);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(41, 19);
            this.labelDate.TabIndex = 8;
            this.labelDate.Text = "Дата";
            this.labelDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDate.Visible = false;
            // 
            // labelStaff
            // 
            this.labelStaff.AutoSize = true;
            this.labelStaff.Location = new System.Drawing.Point(173, 22);
            this.labelStaff.Name = "labelStaff";
            this.labelStaff.Size = new System.Drawing.Size(58, 19);
            this.labelStaff.TabIndex = 7;
            this.labelStaff.Text = "Кассир";
            this.labelStaff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelStaff.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.White;
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.Black;
            this.dateTimePicker1.Location = new System.Drawing.Point(402, 61);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearch.BackColor = System.Drawing.Color.Black;
            this.textBoxSearch.ForeColor = System.Drawing.Color.White;
            this.textBoxSearch.Location = new System.Drawing.Point(958, 60);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(252, 26);
            this.textBoxSearch.TabIndex = 7;
            this.textBoxSearch.Visible = false;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // labelSearch
            // 
            this.labelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(982, 22);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(206, 19);
            this.labelSearch.TabIndex = 6;
            this.labelSearch.Text = "Поиск по названию или коду";
            this.labelSearch.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.labelCount);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.buttonShowReceipt);
            this.groupBox1.Controls.Add(this.buttonCloseReceipt);
            this.groupBox1.Controls.Add(this.buttonAddProductToReceipt);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1262, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Продажа";
            this.groupBox1.Visible = false;
            // 
            // labelCount
            // 
            this.labelCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(298, 47);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(89, 19);
            this.labelCount.TabIndex = 10;
            this.labelCount.Text = "Количество";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown1.BackColor = System.Drawing.Color.Black;
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown1.ForeColor = System.Drawing.Color.White;
            this.numericUpDown1.Location = new System.Drawing.Point(402, 45);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 26);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonShowReceipt
            // 
            this.buttonShowReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowReceipt.BackColor = System.Drawing.Color.Black;
            this.buttonShowReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowReceipt.Location = new System.Drawing.Point(914, 41);
            this.buttonShowReceipt.Name = "buttonShowReceipt";
            this.buttonShowReceipt.Size = new System.Drawing.Size(147, 30);
            this.buttonShowReceipt.TabIndex = 9;
            this.buttonShowReceipt.Text = "Просмотреть чек";
            this.buttonShowReceipt.UseVisualStyleBackColor = false;
            this.buttonShowReceipt.Click += new System.EventHandler(this.buttonShowReceipt_Click);
            // 
            // buttonCloseReceipt
            // 
            this.buttonCloseReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCloseReceipt.BackColor = System.Drawing.Color.Black;
            this.buttonCloseReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseReceipt.Location = new System.Drawing.Point(1097, 41);
            this.buttonCloseReceipt.Name = "buttonCloseReceipt";
            this.buttonCloseReceipt.Size = new System.Drawing.Size(133, 30);
            this.buttonCloseReceipt.TabIndex = 10;
            this.buttonCloseReceipt.Text = "Закрыть чек";
            this.buttonCloseReceipt.UseVisualStyleBackColor = false;
            this.buttonCloseReceipt.Click += new System.EventHandler(this.buttonCloseReceipt_Click);
            // 
            // buttonAddProductToReceipt
            // 
            this.buttonAddProductToReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddProductToReceipt.BackColor = System.Drawing.Color.Black;
            this.buttonAddProductToReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddProductToReceipt.Location = new System.Drawing.Point(12, 41);
            this.buttonAddProductToReceipt.Name = "buttonAddProductToReceipt";
            this.buttonAddProductToReceipt.Size = new System.Drawing.Size(192, 30);
            this.buttonAddProductToReceipt.TabIndex = 6;
            this.buttonAddProductToReceipt.Text = "Добавить товар в чек";
            this.buttonAddProductToReceipt.UseVisualStyleBackColor = false;
            this.buttonAddProductToReceipt.Click += new System.EventHandler(this.buttonAddProductToReceipt_Click);
            // 
            // buttonCreateReceipt
            // 
            this.buttonCreateReceipt.BackColor = System.Drawing.Color.Black;
            this.buttonCreateReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateReceipt.Location = new System.Drawing.Point(667, 60);
            this.buttonCreateReceipt.Name = "buttonCreateReceipt";
            this.buttonCreateReceipt.Size = new System.Drawing.Size(128, 30);
            this.buttonCreateReceipt.TabIndex = 3;
            this.buttonCreateReceipt.Text = "Создать чек";
            this.buttonCreateReceipt.UseVisualStyleBackColor = false;
            this.buttonCreateReceipt.Click += new System.EventHandler(this.buttonCreateReceipt_Click);
            // 
            // labelSelectDate
            // 
            this.labelSelectDate.AutoSize = true;
            this.labelSelectDate.Location = new System.Drawing.Point(448, 22);
            this.labelSelectDate.Name = "labelSelectDate";
            this.labelSelectDate.Size = new System.Drawing.Size(109, 19);
            this.labelSelectDate.TabIndex = 2;
            this.labelSelectDate.Text = "Выберите дату";
            this.labelSelectDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxSelectStaff
            // 
            this.comboBoxSelectStaff.BackColor = System.Drawing.Color.Black;
            this.comboBoxSelectStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSelectStaff.ForeColor = System.Drawing.Color.White;
            this.comboBoxSelectStaff.FormattingEnabled = true;
            this.comboBoxSelectStaff.Location = new System.Drawing.Point(68, 60);
            this.comboBoxSelectStaff.Name = "comboBoxSelectStaff";
            this.comboBoxSelectStaff.Size = new System.Drawing.Size(269, 27);
            this.comboBoxSelectStaff.TabIndex = 1;
            // 
            // labelSelectStaff
            // 
            this.labelSelectStaff.AutoSize = true;
            this.labelSelectStaff.Location = new System.Drawing.Point(136, 22);
            this.labelSelectStaff.Name = "labelSelectStaff";
            this.labelSelectStaff.Size = new System.Drawing.Size(132, 19);
            this.labelSelectStaff.TabIndex = 0;
            this.labelSelectStaff.Text = "Выберите кассира";
            this.labelSelectStaff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product_key,
            this.Category_key,
            this.Manufacturer_key,
            this.Product_name,
            this.Price});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.Location = new System.Drawing.Point(0, 24);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView2.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Black;
            this.dataGridView2.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView2.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1264, 499);
            this.dataGridView2.TabIndex = 4;
            this.dataGridView2.Visible = false;
            this.dataGridView2.DoubleClick += new System.EventHandler(this.dataGridView2_DoubleClick);
            // 
            // Product_key
            // 
            this.Product_key.HeaderText = "Код товара";
            this.Product_key.MinimumWidth = 100;
            this.Product_key.Name = "Product_key";
            this.Product_key.ReadOnly = true;
            this.Product_key.Width = 125;
            // 
            // Category_key
            // 
            this.Category_key.HeaderText = "Код категории";
            this.Category_key.MinimumWidth = 100;
            this.Category_key.Name = "Category_key";
            this.Category_key.ReadOnly = true;
            this.Category_key.Width = 125;
            // 
            // Manufacturer_key
            // 
            this.Manufacturer_key.HeaderText = "Код производителя";
            this.Manufacturer_key.MinimumWidth = 100;
            this.Manufacturer_key.Name = "Manufacturer_key";
            this.Manufacturer_key.ReadOnly = true;
            this.Manufacturer_key.Width = 125;
            // 
            // Product_name
            // 
            this.Product_name.HeaderText = "Наименование";
            this.Product_name.MinimumWidth = 200;
            this.Product_name.Name = "Product_name";
            this.Product_name.ReadOnly = true;
            this.Product_name.Width = 350;
            // 
            // Price
            // 
            this.Price.HeaderText = "Цена";
            this.Price.MinimumWidth = 90;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 110;
            // 
            // FormMain
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1264, 729);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip2);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mobiland";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed_1);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobilandDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource dBDataSetBindingSource;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private System.Windows.Forms.BindingSource tovarBindingSource;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCatalog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button buttonCreateReceipt;
        private System.Windows.Forms.Label labelSelectDate;
        private System.Windows.Forms.ComboBox comboBoxSelectStaff;
        private System.Windows.Forms.Label labelSelectStaff;
        private System.Windows.Forms.BindingSource mobilandDataSetBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.Button buttonAddProductToReceipt;
        private System.Windows.Forms.Button buttonShowReceipt;
        private System.Windows.Forms.Button buttonCloseReceipt;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelStaff;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category_key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manufacturer_key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.Button buttonClear;
    }
}