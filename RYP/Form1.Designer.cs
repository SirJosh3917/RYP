namespace RYP
{
	partial class RypWindow
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
			this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
			this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
			this.guiFileLocation = new MetroFramework.Controls.MetroTextBox();
			this.guiSaveButton = new MetroFramework.Controls.MetroButton();
			this.metroButton1 = new MetroFramework.Controls.MetroButton();
			this.guiMethod = new MetroFramework.Controls.MetroTextBox();
			this.guiPass = new MetroFramework.Controls.MetroTextBox();
			this.guiEmail = new MetroFramework.Controls.MetroTextBox();
			this.AccsFound = new System.Windows.Forms.ListBox();
			this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.passScan = new MetroFramework.Controls.MetroButton();
			this.metroPanel1.SuspendLayout();
			this.metroPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// metroPanel1
			// 
			this.metroPanel1.Controls.Add(this.metroPanel2);
			this.metroPanel1.Controls.Add(this.AccsFound);
			this.metroPanel1.Controls.Add(this.metroLabel2);
			this.metroPanel1.Controls.Add(this.metroLabel1);
			this.metroPanel1.Controls.Add(this.passScan);
			this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.metroPanel1.HorizontalScrollbarBarColor = true;
			this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
			this.metroPanel1.HorizontalScrollbarSize = 10;
			this.metroPanel1.Location = new System.Drawing.Point(0, 0);
			this.metroPanel1.Name = "metroPanel1";
			this.metroPanel1.Size = new System.Drawing.Size(609, 391);
			this.metroPanel1.TabIndex = 0;
			this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.metroPanel1.VerticalScrollbarBarColor = true;
			this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
			this.metroPanel1.VerticalScrollbarSize = 10;
			// 
			// metroPanel2
			// 
			this.metroPanel2.Controls.Add(this.guiFileLocation);
			this.metroPanel2.Controls.Add(this.guiSaveButton);
			this.metroPanel2.Controls.Add(this.metroButton1);
			this.metroPanel2.Controls.Add(this.guiMethod);
			this.metroPanel2.Controls.Add(this.guiPass);
			this.metroPanel2.Controls.Add(this.guiEmail);
			this.metroPanel2.HorizontalScrollbarBarColor = true;
			this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
			this.metroPanel2.HorizontalScrollbarSize = 10;
			this.metroPanel2.Location = new System.Drawing.Point(305, 83);
			this.metroPanel2.Name = "metroPanel2";
			this.metroPanel2.Size = new System.Drawing.Size(292, 277);
			this.metroPanel2.TabIndex = 10;
			this.metroPanel2.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.metroPanel2.VerticalScrollbarBarColor = true;
			this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
			this.metroPanel2.VerticalScrollbarSize = 10;
			// 
			// guiFileLocation
			// 
			this.guiFileLocation.Location = new System.Drawing.Point(3, 90);
			this.guiFileLocation.Name = "guiFileLocation";
			this.guiFileLocation.ReadOnly = true;
			this.guiFileLocation.Size = new System.Drawing.Size(286, 23);
			this.guiFileLocation.TabIndex = 7;
			this.guiFileLocation.Text = "File Location";
			this.guiFileLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.guiFileLocation.Theme = MetroFramework.MetroThemeStyle.Dark;
			// 
			// guiSaveButton
			// 
			this.guiSaveButton.Enabled = false;
			this.guiSaveButton.Location = new System.Drawing.Point(149, 119);
			this.guiSaveButton.Name = "guiSaveButton";
			this.guiSaveButton.Size = new System.Drawing.Size(140, 155);
			this.guiSaveButton.TabIndex = 6;
			this.guiSaveButton.Text = "Save";
			this.guiSaveButton.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.guiSaveButton.Click += new System.EventHandler(this.guiSaveButton_Click);
			// 
			// metroButton1
			// 
			this.metroButton1.Location = new System.Drawing.Point(3, 119);
			this.metroButton1.Name = "metroButton1";
			this.metroButton1.Size = new System.Drawing.Size(140, 155);
			this.metroButton1.TabIndex = 5;
			this.metroButton1.Text = "Delete Account";
			this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
			// 
			// guiMethod
			// 
			this.guiMethod.Location = new System.Drawing.Point(3, 61);
			this.guiMethod.Name = "guiMethod";
			this.guiMethod.ReadOnly = true;
			this.guiMethod.Size = new System.Drawing.Size(286, 23);
			this.guiMethod.TabIndex = 4;
			this.guiMethod.Text = "Method";
			this.guiMethod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.guiMethod.Theme = MetroFramework.MetroThemeStyle.Dark;
			// 
			// guiPass
			// 
			this.guiPass.Location = new System.Drawing.Point(3, 32);
			this.guiPass.Name = "guiPass";
			this.guiPass.Size = new System.Drawing.Size(286, 23);
			this.guiPass.TabIndex = 3;
			this.guiPass.Text = "Password";
			this.guiPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.guiPass.Theme = MetroFramework.MetroThemeStyle.Dark;
			// 
			// guiEmail
			// 
			this.guiEmail.Location = new System.Drawing.Point(3, 3);
			this.guiEmail.Name = "guiEmail";
			this.guiEmail.Size = new System.Drawing.Size(286, 23);
			this.guiEmail.TabIndex = 2;
			this.guiEmail.Text = "Email";
			this.guiEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.guiEmail.Theme = MetroFramework.MetroThemeStyle.Dark;
			// 
			// AccsFound
			// 
			this.AccsFound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
			this.AccsFound.ForeColor = System.Drawing.SystemColors.GrayText;
			this.AccsFound.FormattingEnabled = true;
			this.AccsFound.Location = new System.Drawing.Point(12, 83);
			this.AccsFound.Name = "AccsFound";
			this.AccsFound.Size = new System.Drawing.Size(287, 277);
			this.AccsFound.TabIndex = 4;
			this.AccsFound.SelectedIndexChanged += new System.EventHandler(this.AccsFound_SelectedIndexChanged);
			// 
			// metroLabel2
			// 
			this.metroLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.Location = new System.Drawing.Point(131, 363);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(48, 19);
			this.metroLabel2.TabIndex = 9;
			this.metroLabel2.Text = "Results";
			this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
			// 
			// metroLabel1
			// 
			this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.Location = new System.Drawing.Point(436, 363);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(31, 19);
			this.metroLabel1.TabIndex = 8;
			this.metroLabel1.Text = "Edit";
			this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
			// 
			// passScan
			// 
			this.passScan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.passScan.Location = new System.Drawing.Point(12, 12);
			this.passScan.Name = "passScan";
			this.passScan.Size = new System.Drawing.Size(585, 61);
			this.passScan.TabIndex = 2;
			this.passScan.Text = "Password Scan";
			this.passScan.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.passScan.Click += new System.EventHandler(this.passScan_Click);
			// 
			// RypWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(35)))));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(609, 391);
			this.Controls.Add(this.metroPanel1);
			this.MaximumSize = new System.Drawing.Size(617, 418);
			this.MinimumSize = new System.Drawing.Size(617, 418);
			this.Name = "RypWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RYP 1.0.0.0";
			this.metroPanel1.ResumeLayout(false);
			this.metroPanel1.PerformLayout();
			this.metroPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroPanel metroPanel1;
		private MetroFramework.Controls.MetroButton passScan;
		private System.Windows.Forms.ListBox AccsFound;
		private MetroFramework.Controls.MetroLabel metroLabel1;
		private MetroFramework.Controls.MetroLabel metroLabel2;
		private MetroFramework.Controls.MetroPanel metroPanel2;
		private MetroFramework.Controls.MetroButton guiSaveButton;
		private MetroFramework.Controls.MetroButton metroButton1;
		private MetroFramework.Controls.MetroTextBox guiMethod;
		private MetroFramework.Controls.MetroTextBox guiPass;
		private MetroFramework.Controls.MetroTextBox guiEmail;
		private MetroFramework.Controls.MetroTextBox guiFileLocation;

	}
}

