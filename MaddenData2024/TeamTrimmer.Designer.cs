namespace MaddenDataScraper_2024
{
	partial class TeamTrimmer
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveDatacsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showDataCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.formatRTFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoTrimTeamsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoTrimFreeAgentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hTMLToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.spinFreeAgentCount = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.richTextBoxPositions = new System.Windows.Forms.RichTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.spinAutoCut = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnTrimNow = new System.Windows.Forms.Button();
			this.comboManualTrimPositions = new System.Windows.Forms.ComboBox();
			this.spinManualTrim = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.button1 = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.spinFreeAgentCount)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.spinAutoCut)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.spinManualTrim)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.autoToolStripMenuItem,
            this.openToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1689, 33);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDataToolStripMenuItem,
            this.saveDataToolStripMenuItem,
            this.saveDatacsvToolStripMenuItem,
            this.showDataCSVToolStripMenuItem,
            this.formatRTFToolStripMenuItem,
            this.quitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// loadDataToolStripMenuItem
			// 
			this.loadDataToolStripMenuItem.Name = "loadDataToolStripMenuItem";
			this.loadDataToolStripMenuItem.Size = new System.Drawing.Size(456, 34);
			this.loadDataToolStripMenuItem.Text = "Load Data";
			this.loadDataToolStripMenuItem.Click += new System.EventHandler(this.loadDataToolStripMenuItem_Click);
			// 
			// saveDataToolStripMenuItem
			// 
			this.saveDataToolStripMenuItem.Name = "saveDataToolStripMenuItem";
			this.saveDataToolStripMenuItem.Size = new System.Drawing.Size(456, 34);
			this.saveDataToolStripMenuItem.Text = "Save  Data (.js)";
			this.saveDataToolStripMenuItem.Click += new System.EventHandler(this.saveDataToolStripMenuItem_Click);
			// 
			// saveDatacsvToolStripMenuItem
			// 
			this.saveDatacsvToolStripMenuItem.Name = "saveDatacsvToolStripMenuItem";
			this.saveDatacsvToolStripMenuItem.Size = new System.Drawing.Size(456, 34);
			this.saveDatacsvToolStripMenuItem.Text = "Save Data (Madden Converter .csv format)";
			this.saveDatacsvToolStripMenuItem.Click += new System.EventHandler(this.saveDatacsvToolStripMenuItem_Click);
			// 
			// showDataCSVToolStripMenuItem
			// 
			this.showDataCSVToolStripMenuItem.Name = "showDataCSVToolStripMenuItem";
			this.showDataCSVToolStripMenuItem.Size = new System.Drawing.Size(456, 34);
			this.showDataCSVToolStripMenuItem.Text = "Show Data (Madden Converter .csv format)";
			this.showDataCSVToolStripMenuItem.Click += new System.EventHandler(this.showDataCSVToolStripMenuItem_Click);
			// 
			// formatRTFToolStripMenuItem
			// 
			this.formatRTFToolStripMenuItem.Name = "formatRTFToolStripMenuItem";
			this.formatRTFToolStripMenuItem.Size = new System.Drawing.Size(456, 34);
			this.formatRTFToolStripMenuItem.Text = "Format RTF";
			this.formatRTFToolStripMenuItem.Visible = false;
			this.formatRTFToolStripMenuItem.Click += new System.EventHandler(this.formatRTFToolStripMenuItem_Click);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(456, 34);
			this.quitToolStripMenuItem.Text = "Close";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
			// 
			// autoToolStripMenuItem
			// 
			this.autoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoTrimTeamsToolStripMenuItem,
            this.autoTrimFreeAgentsToolStripMenuItem});
			this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
			this.autoToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
			this.autoToolStripMenuItem.Text = "Auto Trim";
			// 
			// autoTrimTeamsToolStripMenuItem
			// 
			this.autoTrimTeamsToolStripMenuItem.Name = "autoTrimTeamsToolStripMenuItem";
			this.autoTrimTeamsToolStripMenuItem.Size = new System.Drawing.Size(290, 34);
			this.autoTrimTeamsToolStripMenuItem.Text = "Auto Trim Teams";
			this.autoTrimTeamsToolStripMenuItem.Click += new System.EventHandler(this.autoTrimTeamsToolStripMenuItem_Click);
			// 
			// autoTrimFreeAgentsToolStripMenuItem
			// 
			this.autoTrimFreeAgentsToolStripMenuItem.Name = "autoTrimFreeAgentsToolStripMenuItem";
			this.autoTrimFreeAgentsToolStripMenuItem.Size = new System.Drawing.Size(290, 34);
			this.autoTrimFreeAgentsToolStripMenuItem.Text = "Auto Trim Free Agents";
			this.autoTrimFreeAgentsToolStripMenuItem.Click += new System.EventHandler(this.autoTrimFreeAgentsToolStripMenuItem_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hTMLToolToolStripMenuItem});
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(72, 29);
			this.openToolStripMenuItem.Text = "Open";
			// 
			// hTMLToolToolStripMenuItem
			// 
			this.hTMLToolToolStripMenuItem.Name = "hTMLToolToolStripMenuItem";
			this.hTMLToolToolStripMenuItem.Size = new System.Drawing.Size(198, 34);
			this.hTMLToolToolStripMenuItem.Text = "HTML Tool";
			this.hTMLToolToolStripMenuItem.Click += new System.EventHandler(this.hTMLToolToolStripMenuItem_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(12, 36);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowHeadersWidth = 62;
			this.dataGridView.RowTemplate.Height = 28;
			this.dataGridView.Size = new System.Drawing.Size(1057, 845);
			this.dataGridView.TabIndex = 1;
			this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox1.BackColor = System.Drawing.Color.Black;
			this.richTextBox1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBox1.ForeColor = System.Drawing.Color.White;
			this.richTextBox1.Location = new System.Drawing.Point(1087, 36);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(556, 299);
			this.richTextBox1.TabIndex = 2;
			this.richTextBox1.Text = "";
			this.richTextBox1.DoubleClick += new System.EventHandler(this.richTextBox1_DoubleClick);
			// 
			// spinFreeAgentCount
			// 
			this.spinFreeAgentCount.Location = new System.Drawing.Point(65, 27);
			this.spinFreeAgentCount.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.spinFreeAgentCount.Name = "spinFreeAgentCount";
			this.spinFreeAgentCount.Size = new System.Drawing.Size(93, 26);
			this.spinFreeAgentCount.TabIndex = 3;
			this.spinFreeAgentCount.Value = new decimal(new int[] {
            241,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 20);
			this.label1.TabIndex = 4;
			this.label1.Text = "Max";
			// 
			// richTextBoxPositions
			// 
			this.richTextBoxPositions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBoxPositions.BackColor = System.Drawing.Color.Black;
			this.richTextBoxPositions.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxPositions.ForeColor = System.Drawing.Color.White;
			this.richTextBoxPositions.Location = new System.Drawing.Point(1087, 370);
			this.richTextBoxPositions.Name = "richTextBoxPositions";
			this.richTextBoxPositions.ReadOnly = true;
			this.richTextBoxPositions.Size = new System.Drawing.Size(556, 263);
			this.richTextBoxPositions.TabIndex = 5;
			this.richTextBoxPositions.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.spinAutoCut);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.spinFreeAgentCount);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(1087, 645);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(556, 71);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Free Agent control";
			// 
			// spinAutoCut
			// 
			this.spinAutoCut.Location = new System.Drawing.Point(370, 25);
			this.spinAutoCut.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.spinAutoCut.Name = "spinAutoCut";
			this.spinAutoCut.Size = new System.Drawing.Size(93, 26);
			this.spinAutoCut.TabIndex = 5;
			this.spinAutoCut.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(226, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(138, 20);
			this.label2.TabIndex = 6;
			this.label2.Text = "Auto cut if rating <";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnTrimNow);
			this.groupBox2.Controls.Add(this.comboManualTrimPositions);
			this.groupBox2.Controls.Add(this.spinManualTrim);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Location = new System.Drawing.Point(1087, 722);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(556, 120);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Manual Trim Positions";
			// 
			// btnTrimNow
			// 
			this.btnTrimNow.Location = new System.Drawing.Point(407, 17);
			this.btnTrimNow.Name = "btnTrimNow";
			this.btnTrimNow.Size = new System.Drawing.Size(101, 41);
			this.btnTrimNow.TabIndex = 10;
			this.btnTrimNow.Text = "Trim now";
			this.btnTrimNow.UseVisualStyleBackColor = true;
			this.btnTrimNow.Click += new System.EventHandler(this.btnTrimNow_Click);
			// 
			// comboManualTrimPositions
			// 
			this.comboManualTrimPositions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboManualTrimPositions.FormattingEnabled = true;
			this.comboManualTrimPositions.Location = new System.Drawing.Point(294, 23);
			this.comboManualTrimPositions.Name = "comboManualTrimPositions";
			this.comboManualTrimPositions.Size = new System.Drawing.Size(86, 28);
			this.comboManualTrimPositions.TabIndex = 5;
			// 
			// spinManualTrim
			// 
			this.spinManualTrim.Location = new System.Drawing.Point(195, 25);
			this.spinManualTrim.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.spinManualTrim.Name = "spinManualTrim";
			this.spinManualTrim.Size = new System.Drawing.Size(93, 26);
			this.spinManualTrim.TabIndex = 8;
			this.spinManualTrim.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 27);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(171, 20);
			this.label3.TabIndex = 9;
			this.label3.Text = "Trim All teams Down to";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(1525, 848);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(118, 37);
			this.button1.TabIndex = 8;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// TeamTrimmer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1689, 893);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.richTextBoxPositions);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "TeamTrimmer";
			this.Text = "TeamTrimmer";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.spinFreeAgentCount)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.spinAutoCut)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.spinManualTrim)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadDataToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveDataToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.ToolStripMenuItem formatRTFToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem autoTrimTeamsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem autoTrimFreeAgentsToolStripMenuItem;
		private System.Windows.Forms.NumericUpDown spinFreeAgentCount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox richTextBoxPositions;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown spinAutoCut;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolStripMenuItem saveDatacsvToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showDataCSVToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hTMLToolToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox comboManualTrimPositions;
		private System.Windows.Forms.NumericUpDown spinManualTrim;
		private System.Windows.Forms.Label label3;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.Button btnTrimNow;
		private System.Windows.Forms.Button button1;
	}
}