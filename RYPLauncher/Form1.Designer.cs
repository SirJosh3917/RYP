/*
The MIT License (MIT)

Copyright (c) 2016 SirJosh3917

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

namespace RYPLauncher
{
	partial class Form1
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
			this.launcher = new MetroFramework.Controls.MetroPanel();
			this.progSpin = new MetroFramework.Controls.MetroProgressSpinner();
			this.rypVer = new MetroFramework.Controls.MetroLabel();
			this.progText = new MetroFramework.Controls.MetroLabel();
			this.launcher.SuspendLayout();
			this.SuspendLayout();
			// 
			// launcher
			// 
			this.launcher.Controls.Add(this.progText);
			this.launcher.Controls.Add(this.rypVer);
			this.launcher.Controls.Add(this.progSpin);
			this.launcher.Dock = System.Windows.Forms.DockStyle.Fill;
			this.launcher.HorizontalScrollbarBarColor = true;
			this.launcher.HorizontalScrollbarHighlightOnWheel = false;
			this.launcher.HorizontalScrollbarSize = 10;
			this.launcher.Location = new System.Drawing.Point(0, 0);
			this.launcher.Name = "launcher";
			this.launcher.Size = new System.Drawing.Size(344, 142);
			this.launcher.TabIndex = 0;
			this.launcher.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.launcher.VerticalScrollbarBarColor = true;
			this.launcher.VerticalScrollbarHighlightOnWheel = false;
			this.launcher.VerticalScrollbarSize = 10;
			// 
			// progSpin
			// 
			this.progSpin.Location = new System.Drawing.Point(139, 12);
			this.progSpin.Maximum = 100;
			this.progSpin.Name = "progSpin";
			this.progSpin.Size = new System.Drawing.Size(64, 64);
			this.progSpin.Speed = 5F;
			this.progSpin.TabIndex = 2;
			this.progSpin.Theme = MetroFramework.MetroThemeStyle.Dark;
			// 
			// rypVer
			// 
			this.rypVer.AutoSize = true;
			this.rypVer.Location = new System.Drawing.Point(112, 79);
			this.rypVer.Name = "rypVer";
			this.rypVer.Size = new System.Drawing.Size(120, 19);
			this.rypVer.TabIndex = 3;
			this.rypVer.Text = "RYP Version: ?.?.?.?";
			this.rypVer.Theme = MetroFramework.MetroThemeStyle.Dark;
			// 
			// progText
			// 
			this.progText.AutoSize = true;
			this.progText.Location = new System.Drawing.Point(110, 110);
			this.progText.Name = "progText";
			this.progText.Size = new System.Drawing.Size(124, 19);
			this.progText.TabIndex = 4;
			this.progText.Text = "Downloading Files...";
			this.progText.Theme = MetroFramework.MetroThemeStyle.Dark;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 142);
			this.Controls.Add(this.launcher);
			this.MaximumSize = new System.Drawing.Size(352, 169);
			this.MinimumSize = new System.Drawing.Size(352, 169);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RYPLauncher";
			this.launcher.ResumeLayout(false);
			this.launcher.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroPanel launcher;
		private MetroFramework.Controls.MetroLabel progText;
		private MetroFramework.Controls.MetroLabel rypVer;
		private MetroFramework.Controls.MetroProgressSpinner progSpin;
	}
}

