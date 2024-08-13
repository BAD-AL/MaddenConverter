namespace MaddenDataScraper_2024
{
	partial class FaceForm
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
			this.pictureBoxFace = new System.Windows.Forms.PictureBox();
			this.listPhotos = new System.Windows.Forms.ListBox();
			this.txtFilter = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panelChunk = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFace)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxFace
			// 
			this.pictureBoxFace.Location = new System.Drawing.Point(29, 33);
			this.pictureBoxFace.Name = "pictureBoxFace";
			this.pictureBoxFace.Size = new System.Drawing.Size(194, 183);
			this.pictureBoxFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxFace.TabIndex = 0;
			this.pictureBoxFace.TabStop = false;
			// 
			// listPhotos
			// 
			this.listPhotos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listPhotos.FormattingEnabled = true;
			this.listPhotos.ItemHeight = 20;
			this.listPhotos.Location = new System.Drawing.Point(29, 286);
			this.listPhotos.Name = "listPhotos";
			this.listPhotos.Size = new System.Drawing.Size(194, 124);
			this.listPhotos.TabIndex = 2;
			// 
			// txtFilter
			// 
			this.txtFilter.Location = new System.Drawing.Point(29, 233);
			this.txtFilter.Name = "txtFilter";
			this.txtFilter.Size = new System.Drawing.Size(194, 26);
			this.txtFilter.TabIndex = 3;
			this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(243, 160);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(137, 99);
			this.label1.TabIndex = 4;
			this.label1.Text = "Average Color";
			this.label1.DoubleClick += new System.EventHandler(this.label1_DoubleClick);
			// 
			// panelChunk
			// 
			this.panelChunk.Location = new System.Drawing.Point(247, 33);
			this.panelChunk.Name = "panelChunk";
			this.panelChunk.Size = new System.Drawing.Size(143, 108);
			this.panelChunk.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(458, 160);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(137, 99);
			this.label2.TabIndex = 6;
			this.label2.Text = "Average Color";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(243, 259);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 20);
			this.label3.TabIndex = 7;
			this.label3.Text = "Average";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(458, 273);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(110, 20);
			this.label4.TabIndex = 8;
			this.label4.Text = "Closest Match";
			// 
			// FaceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panelChunk);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtFilter);
			this.Controls.Add(this.listPhotos);
			this.Controls.Add(this.pictureBoxFace);
			this.Name = "FaceForm";
			this.Text = "FaceForm";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFace)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxFace;
		private System.Windows.Forms.ListBox listPhotos;
		private System.Windows.Forms.TextBox txtFilter;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panelChunk;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}