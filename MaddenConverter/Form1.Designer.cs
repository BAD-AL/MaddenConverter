namespace MaddenConverter
{
    partial class MainForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.mGoButton = new System.Windows.Forms.Button();
			this.mAddPlayers = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.outputOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.autoUpdateDepthChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoUpdatePBPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoUpdatePhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoUpdateSpecialTeamsDepthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 45);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(130, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = " Madden Ratings";
			// 
			// textBox1
			// 
			this.textBox1.AcceptsReturn = true;
			this.textBox1.AllowDrop = true;
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(18, 70);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBox1.MaxLength = 32767000;
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(937, 199);
			this.textBox1.TabIndex = 1;
			this.textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
			this.textBox1.DragOver += new System.Windows.Forms.DragEventHandler(this.textBox1_DragOver);
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox2.Location = new System.Drawing.Point(18, 322);
			this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBox2.MaxLength = 3276700;
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox2.Size = new System.Drawing.Size(937, 306);
			this.textBox2.TabIndex = 2;
			this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 291);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(126, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "NFL2K5 Ratings";
			// 
			// mGoButton
			// 
			this.mGoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.mGoButton.Location = new System.Drawing.Point(845, 276);
			this.mGoButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.mGoButton.Name = "mGoButton";
			this.mGoButton.Size = new System.Drawing.Size(112, 35);
			this.mGoButton.TabIndex = 4;
			this.mGoButton.Text = "&Go";
			this.mGoButton.UseVisualStyleBackColor = true;
			this.mGoButton.Click += new System.EventHandler(this.mGoButton_Click);
			// 
			// mAddPlayers
			// 
			this.mAddPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.mAddPlayers.Location = new System.Drawing.Point(569, 276);
			this.mAddPlayers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.mAddPlayers.Name = "mAddPlayers";
			this.mAddPlayers.Size = new System.Drawing.Size(112, 35);
			this.mAddPlayers.TabIndex = 5;
			this.mAddPlayers.Text = "&Add Players";
			this.mAddPlayers.UseVisualStyleBackColor = true;
			this.mAddPlayers.Visible = false;
			this.mAddPlayers.Click += new System.EventHandler(this.mAddPlayers_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(337, 276);
			this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(187, 35);
			this.button1.TabIndex = 6;
			this.button1.Text = "LaunchRegexForm";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Visible = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outputOptionsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(975, 33);
			this.menuStrip1.TabIndex = 7;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// outputOptionsToolStripMenuItem
			// 
			this.outputOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoUpdateDepthChartToolStripMenuItem,
            this.autoUpdatePBPToolStripMenuItem,
            this.autoUpdateSpecialTeamsDepthToolStripMenuItem,
            this.autoUpdatePhotoToolStripMenuItem});
			this.outputOptionsToolStripMenuItem.Name = "outputOptionsToolStripMenuItem";
			this.outputOptionsToolStripMenuItem.Size = new System.Drawing.Size(160, 29);
			this.outputOptionsToolStripMenuItem.Text = "2K5Tool Options";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// autoUpdateDepthChartToolStripMenuItem
			// 
			this.autoUpdateDepthChartToolStripMenuItem.Checked = true;
			this.autoUpdateDepthChartToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoUpdateDepthChartToolStripMenuItem.Name = "autoUpdateDepthChartToolStripMenuItem";
			this.autoUpdateDepthChartToolStripMenuItem.Size = new System.Drawing.Size(302, 34);
			this.autoUpdateDepthChartToolStripMenuItem.Text = "AutoUpdateDepthChart";
			this.autoUpdateDepthChartToolStripMenuItem.Click += new System.EventHandler(this.menuItemClick);
			// 
			// autoUpdatePBPToolStripMenuItem
			// 
			this.autoUpdatePBPToolStripMenuItem.Checked = true;
			this.autoUpdatePBPToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoUpdatePBPToolStripMenuItem.Name = "autoUpdatePBPToolStripMenuItem";
			this.autoUpdatePBPToolStripMenuItem.Size = new System.Drawing.Size(302, 34);
			this.autoUpdatePBPToolStripMenuItem.Text = "AutoUpdatePBP";
			this.autoUpdatePBPToolStripMenuItem.Click += new System.EventHandler(this.menuItemClick);
			// 
			// autoUpdatePhotoToolStripMenuItem
			// 
			this.autoUpdatePhotoToolStripMenuItem.Name = "autoUpdatePhotoToolStripMenuItem";
			this.autoUpdatePhotoToolStripMenuItem.Size = new System.Drawing.Size(302, 34);
			this.autoUpdatePhotoToolStripMenuItem.Text = "AutoUpdatePhoto";
			this.autoUpdatePhotoToolStripMenuItem.Click += new System.EventHandler(this.menuItemClick);
			// 
			// autoUpdateSpecialTeamsDepthToolStripMenuItem
			// 
			this.autoUpdateSpecialTeamsDepthToolStripMenuItem.Name = "autoUpdateSpecialTeamsDepthToolStripMenuItem";
			this.autoUpdateSpecialTeamsDepthToolStripMenuItem.Size = new System.Drawing.Size(369, 34);
			this.autoUpdateSpecialTeamsDepthToolStripMenuItem.Text = "AutoUpdateSpecialTeamsDepth ";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(975, 649);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.mAddPlayers);
			this.Controls.Add(this.mGoButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "MainForm";
			this.Text = "Madden Converter";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button mGoButton;
        private System.Windows.Forms.Button mAddPlayers;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem outputOptionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem autoUpdateDepthChartToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem autoUpdatePBPToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem autoUpdatePhotoToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem autoUpdateSpecialTeamsDepthToolStripMenuItem;
	}
}

