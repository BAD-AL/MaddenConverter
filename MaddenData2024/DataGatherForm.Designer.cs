namespace MaddenDataScraper_2024
{
	partial class DataGatherForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataGatherForm));
			this.txtJsonData = new WinFormsUtilities.SearchTextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.teamTrimmerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listTeamPageUrlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listTeamDataUrlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.translateDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutBaseUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveMaddenDataAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.comboTeams = new System.Windows.Forms.ComboBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.txtMaddenData = new WinFormsUtilities.SearchTextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnCreatePhotoDownloadCurlScript = new System.Windows.Forms.Button();
			this.comboTeamsPhoto = new System.Windows.Forms.ComboBox();
			this.btnDownloadPhotos = new System.Windows.Forms.Button();
			this.richTextBoxPhotoData = new System.Windows.Forms.RichTextBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.panel2K5Data = new System.Windows.Forms.Panel();
			this.lab2K5DataError = new System.Windows.Forms.Label();
			this.btnConvertTo2K5Data = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.richTextBox2K5Data = new WinFormsUtilities.SearchTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.richTextBoxMaddenConverter = new WinFormsUtilities.SearchTextBox();
			this.txtSkinFileLocation = new System.Windows.Forms.TextBox();
			this.labelSkinMapFile = new System.Windows.Forms.Label();
			this.listEquipmentFiles = new System.Windows.Forms.ListBox();
			this.labelEquipmentData = new System.Windows.Forms.Label();
			this.btnGo = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.labStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.txtBaseUrl = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnTranslateAllData = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.panel2K5Data.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtJsonData
			// 
			this.txtJsonData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtJsonData.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtJsonData.Location = new System.Drawing.Point(3, 3);
			this.txtJsonData.Name = "txtJsonData";
			this.txtJsonData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.txtJsonData.SearchString = null;
			this.txtJsonData.Size = new System.Drawing.Size(1105, 529);
			this.txtJsonData.StatusControl = null;
			this.txtJsonData.TabIndex = 0;
			this.txtJsonData.Text = "";
			// 
			// menuStrip1
			// 
			this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1131, 33);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.teamTrimmerToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// teamTrimmerToolStripMenuItem
			// 
			this.teamTrimmerToolStripMenuItem.Name = "teamTrimmerToolStripMenuItem";
			this.teamTrimmerToolStripMenuItem.Size = new System.Drawing.Size(201, 34);
			this.teamTrimmerToolStripMenuItem.Text = "Trim Teams";
			this.teamTrimmerToolStripMenuItem.Click += new System.EventHandler(this.teamTrimmerToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(201, 34);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// dataToolStripMenuItem
			// 
			this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listTeamPageUrlsToolStripMenuItem,
            this.listTeamDataUrlsToolStripMenuItem,
            this.translateDataToolStripMenuItem,
            this.aboutBaseUrlToolStripMenuItem});
			this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
			this.dataToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
			this.dataToolStripMenuItem.Text = "Data";
			// 
			// listTeamPageUrlsToolStripMenuItem
			// 
			this.listTeamPageUrlsToolStripMenuItem.Name = "listTeamPageUrlsToolStripMenuItem";
			this.listTeamPageUrlsToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
			this.listTeamPageUrlsToolStripMenuItem.Text = "List Team Page urls";
			this.listTeamPageUrlsToolStripMenuItem.Click += new System.EventHandler(this.listTeamPageUrlsToolStripMenuItem_Click);
			// 
			// listTeamDataUrlsToolStripMenuItem
			// 
			this.listTeamDataUrlsToolStripMenuItem.Name = "listTeamDataUrlsToolStripMenuItem";
			this.listTeamDataUrlsToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
			this.listTeamDataUrlsToolStripMenuItem.Text = "List Team Data Urls";
			this.listTeamDataUrlsToolStripMenuItem.Click += new System.EventHandler(this.listTeamDataUrlsToolStripMenuItem_Click);
			// 
			// translateDataToolStripMenuItem
			// 
			this.translateDataToolStripMenuItem.Name = "translateDataToolStripMenuItem";
			this.translateDataToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
			this.translateDataToolStripMenuItem.Text = "Translate Data";
			this.translateDataToolStripMenuItem.Visible = false;
			this.translateDataToolStripMenuItem.Click += new System.EventHandler(this.btnTranslateAllData_Click);
			// 
			// aboutBaseUrlToolStripMenuItem
			// 
			this.aboutBaseUrlToolStripMenuItem.Name = "aboutBaseUrlToolStripMenuItem";
			this.aboutBaseUrlToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
			this.aboutBaseUrlToolStripMenuItem.Text = "About Base Url";
			this.aboutBaseUrlToolStripMenuItem.Click += new System.EventHandler(this.aboutBaseUrlToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMaddenDataAsToolStripMenuItem});
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
			this.saveToolStripMenuItem.Text = "Save";
			// 
			// saveMaddenDataAsToolStripMenuItem
			// 
			this.saveMaddenDataAsToolStripMenuItem.Name = "saveMaddenDataAsToolStripMenuItem";
			this.saveMaddenDataAsToolStripMenuItem.Size = new System.Drawing.Size(286, 34);
			this.saveMaddenDataAsToolStripMenuItem.Text = "Save Madden Data as";
			this.saveMaddenDataAsToolStripMenuItem.Click += new System.EventHandler(this.saveMaddenDataAsToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToUseToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// howToUseToolStripMenuItem
			// 
			this.howToUseToolStripMenuItem.Name = "howToUseToolStripMenuItem";
			this.howToUseToolStripMenuItem.Size = new System.Drawing.Size(208, 34);
			this.howToUseToolStripMenuItem.Text = "How To Use";
			this.howToUseToolStripMenuItem.Click += new System.EventHandler(this.howToUseToolStripMenuItem_Click);
			// 
			// comboTeams
			// 
			this.comboTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboTeams.FormattingEnabled = true;
			this.comboTeams.Location = new System.Drawing.Point(12, 50);
			this.comboTeams.Name = "comboTeams";
			this.comboTeams.Size = new System.Drawing.Size(238, 28);
			this.comboTeams.TabIndex = 2;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Location = new System.Drawing.Point(12, 172);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1119, 568);
			this.tabControl1.TabIndex = 3;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtJsonData);
			this.tabPage1.Location = new System.Drawing.Point(4, 29);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1111, 535);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "JSON Data";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.txtMaddenData);
			this.tabPage2.Location = new System.Drawing.Point(4, 29);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1111, 535);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Madden Data";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// txtMaddenData
			// 
			this.txtMaddenData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtMaddenData.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMaddenData.Location = new System.Drawing.Point(3, 3);
			this.txtMaddenData.Name = "txtMaddenData";
			this.txtMaddenData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.txtMaddenData.SearchString = null;
			this.txtMaddenData.Size = new System.Drawing.Size(1105, 529);
			this.txtMaddenData.StatusControl = null;
			this.txtMaddenData.TabIndex = 1;
			this.txtMaddenData.Text = "";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.panel1);
			this.tabPage3.Location = new System.Drawing.Point(4, 29);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(1111, 535);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Photos";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnCreatePhotoDownloadCurlScript);
			this.panel1.Controls.Add(this.comboTeamsPhoto);
			this.panel1.Controls.Add(this.btnDownloadPhotos);
			this.panel1.Controls.Add(this.richTextBoxPhotoData);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1111, 535);
			this.panel1.TabIndex = 0;
			// 
			// btnCreatePhotoDownloadCurlScript
			// 
			this.btnCreatePhotoDownloadCurlScript.Location = new System.Drawing.Point(598, 146);
			this.btnCreatePhotoDownloadCurlScript.Name = "btnCreatePhotoDownloadCurlScript";
			this.btnCreatePhotoDownloadCurlScript.Size = new System.Drawing.Size(177, 55);
			this.btnCreatePhotoDownloadCurlScript.TabIndex = 9;
			this.btnCreatePhotoDownloadCurlScript.Text = "Create curl script";
			this.btnCreatePhotoDownloadCurlScript.UseVisualStyleBackColor = true;
			this.btnCreatePhotoDownloadCurlScript.Click += new System.EventHandler(this.btnCreatePhotoDownloadCurlScript_Click);
			// 
			// comboTeamsPhoto
			// 
			this.comboTeamsPhoto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboTeamsPhoto.FormattingEnabled = true;
			this.comboTeamsPhoto.Location = new System.Drawing.Point(598, 19);
			this.comboTeamsPhoto.Name = "comboTeamsPhoto";
			this.comboTeamsPhoto.Size = new System.Drawing.Size(177, 28);
			this.comboTeamsPhoto.TabIndex = 8;
			// 
			// btnDownloadPhotos
			// 
			this.btnDownloadPhotos.Location = new System.Drawing.Point(598, 70);
			this.btnDownloadPhotos.Name = "btnDownloadPhotos";
			this.btnDownloadPhotos.Size = new System.Drawing.Size(177, 55);
			this.btnDownloadPhotos.TabIndex = 7;
			this.btnDownloadPhotos.Text = "Download Photos";
			this.btnDownloadPhotos.UseVisualStyleBackColor = true;
			this.btnDownloadPhotos.Click += new System.EventHandler(this.btnDownloadPhotos_Click);
			// 
			// richTextBoxPhotoData
			// 
			this.richTextBoxPhotoData.BackColor = System.Drawing.Color.Black;
			this.richTextBoxPhotoData.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxPhotoData.ForeColor = System.Drawing.Color.White;
			this.richTextBoxPhotoData.Location = new System.Drawing.Point(3, 3);
			this.richTextBoxPhotoData.Name = "richTextBoxPhotoData";
			this.richTextBoxPhotoData.ReadOnly = true;
			this.richTextBoxPhotoData.Size = new System.Drawing.Size(589, 289);
			this.richTextBoxPhotoData.TabIndex = 6;
			this.richTextBoxPhotoData.Text = "";
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.panel2K5Data);
			this.tabPage4.Location = new System.Drawing.Point(4, 29);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(1111, 535);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "2K5 Data";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// panel2K5Data
			// 
			this.panel2K5Data.Controls.Add(this.lab2K5DataError);
			this.panel2K5Data.Controls.Add(this.btnConvertTo2K5Data);
			this.panel2K5Data.Controls.Add(this.groupBox2);
			this.panel2K5Data.Controls.Add(this.groupBox1);
			this.panel2K5Data.Controls.Add(this.txtSkinFileLocation);
			this.panel2K5Data.Controls.Add(this.labelSkinMapFile);
			this.panel2K5Data.Controls.Add(this.listEquipmentFiles);
			this.panel2K5Data.Controls.Add(this.labelEquipmentData);
			this.panel2K5Data.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2K5Data.Location = new System.Drawing.Point(0, 0);
			this.panel2K5Data.Name = "panel2K5Data";
			this.panel2K5Data.Size = new System.Drawing.Size(1111, 535);
			this.panel2K5Data.TabIndex = 0;
			// 
			// lab2K5DataError
			// 
			this.lab2K5DataError.BackColor = System.Drawing.Color.LightCoral;
			this.lab2K5DataError.ForeColor = System.Drawing.Color.Black;
			this.lab2K5DataError.Location = new System.Drawing.Point(12, 422);
			this.lab2K5DataError.Name = "lab2K5DataError";
			this.lab2K5DataError.Size = new System.Drawing.Size(317, 89);
			this.lab2K5DataError.TabIndex = 7;
			this.lab2K5DataError.Text = "lab2K5DataError";
			this.lab2K5DataError.Visible = false;
			// 
			// btnConvertTo2K5Data
			// 
			this.btnConvertTo2K5Data.Location = new System.Drawing.Point(214, 328);
			this.btnConvertTo2K5Data.Name = "btnConvertTo2K5Data";
			this.btnConvertTo2K5Data.Size = new System.Drawing.Size(106, 82);
			this.btnConvertTo2K5Data.TabIndex = 6;
			this.btnConvertTo2K5Data.Text = "Convert";
			this.btnConvertTo2K5Data.UseVisualStyleBackColor = true;
			this.btnConvertTo2K5Data.Click += new System.EventHandler(this.btnConvertTo2K5Data_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.richTextBox2K5Data);
			this.groupBox2.Location = new System.Drawing.Point(361, 275);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(742, 239);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "NFL 2K5 Data";
			// 
			// richTextBox2K5Data
			// 
			this.richTextBox2K5Data.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox2K5Data.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBox2K5Data.Location = new System.Drawing.Point(3, 22);
			this.richTextBox2K5Data.Name = "richTextBox2K5Data";
			this.richTextBox2K5Data.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.richTextBox2K5Data.SearchString = null;
			this.richTextBox2K5Data.Size = new System.Drawing.Size(736, 214);
			this.richTextBox2K5Data.StatusControl = null;
			this.richTextBox2K5Data.TabIndex = 0;
			this.richTextBox2K5Data.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.richTextBoxMaddenConverter);
			this.groupBox1.Location = new System.Drawing.Point(361, 15);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(742, 245);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Madden Data";
			// 
			// richTextBoxMaddenConverter
			// 
			this.richTextBoxMaddenConverter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBoxMaddenConverter.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxMaddenConverter.Location = new System.Drawing.Point(3, 22);
			this.richTextBoxMaddenConverter.Name = "richTextBoxMaddenConverter";
			this.richTextBoxMaddenConverter.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.richTextBoxMaddenConverter.SearchString = null;
			this.richTextBoxMaddenConverter.Size = new System.Drawing.Size(736, 220);
			this.richTextBoxMaddenConverter.StatusControl = null;
			this.richTextBoxMaddenConverter.TabIndex = 0;
			this.richTextBoxMaddenConverter.Text = "";
			// 
			// txtSkinFileLocation
			// 
			this.txtSkinFileLocation.AllowDrop = true;
			this.txtSkinFileLocation.Location = new System.Drawing.Point(16, 275);
			this.txtSkinFileLocation.Name = "txtSkinFileLocation";
			this.txtSkinFileLocation.Size = new System.Drawing.Size(304, 26);
			this.txtSkinFileLocation.TabIndex = 3;
			this.txtSkinFileLocation.TextChanged += new System.EventHandler(this.txtSkinFileLocation_TextChanged);
			this.txtSkinFileLocation.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtSkinFileLocation_DragDrop);
			this.txtSkinFileLocation.DragOver += new System.Windows.Forms.DragEventHandler(this.txtSkinFileLocation_DragOver);
			// 
			// labelSkinMapFile
			// 
			this.labelSkinMapFile.AutoSize = true;
			this.labelSkinMapFile.Location = new System.Drawing.Point(12, 240);
			this.labelSkinMapFile.Name = "labelSkinMapFile";
			this.labelSkinMapFile.Size = new System.Drawing.Size(104, 20);
			this.labelSkinMapFile.TabIndex = 2;
			this.labelSkinMapFile.Tag = "Skin Map File";
			this.labelSkinMapFile.Text = "Skin Map File";
			// 
			// listEquipmentFiles
			// 
			this.listEquipmentFiles.FormattingEnabled = true;
			this.listEquipmentFiles.ItemHeight = 20;
			this.listEquipmentFiles.Location = new System.Drawing.Point(16, 38);
			this.listEquipmentFiles.Name = "listEquipmentFiles";
			this.listEquipmentFiles.Size = new System.Drawing.Size(304, 184);
			this.listEquipmentFiles.TabIndex = 1;
			// 
			// labelEquipmentData
			// 
			this.labelEquipmentData.AutoSize = true;
			this.labelEquipmentData.Location = new System.Drawing.Point(12, 15);
			this.labelEquipmentData.Name = "labelEquipmentData";
			this.labelEquipmentData.Size = new System.Drawing.Size(125, 20);
			this.labelEquipmentData.TabIndex = 0;
			this.labelEquipmentData.Tag = "Equipment Data";
			this.labelEquipmentData.Text = "Equipment Data";
			// 
			// btnGo
			// 
			this.btnGo.Location = new System.Drawing.Point(12, 84);
			this.btnGo.Name = "btnGo";
			this.btnGo.Size = new System.Drawing.Size(238, 38);
			this.btnGo.TabIndex = 4;
			this.btnGo.Text = "Gather Team Data";
			this.btnGo.UseVisualStyleBackColor = true;
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 743);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1131, 32);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// labStatus
			// 
			this.labStatus.Name = "labStatus";
			this.labStatus.Size = new System.Drawing.Size(179, 25);
			this.labStatus.Text = "toolStripStatusLabel1";
			// 
			// txtBaseUrl
			// 
			this.txtBaseUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBaseUrl.Location = new System.Drawing.Point(346, 96);
			this.txtBaseUrl.Name = "txtBaseUrl";
			this.txtBaseUrl.Size = new System.Drawing.Size(773, 26);
			this.txtBaseUrl.TabIndex = 6;
			this.txtBaseUrl.TextChanged += new System.EventHandler(this.txtBaseUrl_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(342, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 20);
			this.label1.TabIndex = 7;
			this.label1.Text = "Base URL:";
			// 
			// btnTranslateAllData
			// 
			this.btnTranslateAllData.Location = new System.Drawing.Point(12, 128);
			this.btnTranslateAllData.Name = "btnTranslateAllData";
			this.btnTranslateAllData.Size = new System.Drawing.Size(238, 38);
			this.btnTranslateAllData.TabIndex = 8;
			this.btnTranslateAllData.Text = "Translate All Team Data";
			this.btnTranslateAllData.UseVisualStyleBackColor = true;
			this.btnTranslateAllData.Click += new System.EventHandler(this.btnTranslateAllData_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.Blue;
			this.label2.Location = new System.Drawing.Point(342, 137);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(123, 20);
			this.label2.TabIndex = 9;
			this.label2.Text = "Open index.html";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// DataGatherForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1131, 775);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnTranslateAllData);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtBaseUrl);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.btnGo);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.comboTeams);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "DataGatherForm";
			this.Text = "Madden Data 2024";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.panel2K5Data.ResumeLayout(false);
			this.panel2K5Data.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private WinFormsUtilities.SearchTextBox txtJsonData;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem listTeamPageUrlsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem listTeamDataUrlsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ComboBox comboTeams;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ToolStripMenuItem translateDataToolStripMenuItem;
		private WinFormsUtilities.SearchTextBox txtMaddenData;
		private System.Windows.Forms.Button btnGo;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel labStatus;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveMaddenDataAsToolStripMenuItem;
		private System.Windows.Forms.TextBox txtBaseUrl;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripMenuItem aboutBaseUrlToolStripMenuItem;
		private System.Windows.Forms.Button btnTranslateAllData;
		private System.Windows.Forms.ToolStripMenuItem teamTrimmerToolStripMenuItem;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RichTextBox richTextBoxPhotoData;
		private System.Windows.Forms.ComboBox comboTeamsPhoto;
		private System.Windows.Forms.Button btnDownloadPhotos;
		private System.Windows.Forms.Button btnCreatePhotoDownloadCurlScript;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem howToUseToolStripMenuItem;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Panel panel2K5Data;
		private System.Windows.Forms.ListBox listEquipmentFiles;
		private System.Windows.Forms.Label labelEquipmentData;
		private System.Windows.Forms.TextBox txtSkinFileLocation;
		private System.Windows.Forms.Label labelSkinMapFile;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private WinFormsUtilities.SearchTextBox richTextBox2K5Data;
		private WinFormsUtilities.SearchTextBox richTextBoxMaddenConverter;
		private System.Windows.Forms.Button btnConvertTo2K5Data;
		private System.Windows.Forms.Label lab2K5DataError;
	}
}

