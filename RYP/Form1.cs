/*
The MIT License (MIT)

Copyright (c) 2016 SirJosh3917

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RYPbin;

namespace RYP
{
	public partial class RypWindow : Form
	{
		public RypWindow()
		{
			InitializeComponent();
		}

		private Dictionary<int, Account> AccountsFound = new Dictionary<int, Account>();
		private Account UsingAcc = new Account("guest", "guest", SearchMethod.None, "");

		private void passScan_Click(object sender, EventArgs e)
		{
			Scan();
		}

		private void Scan()
		{
			Searcher search = new Searcher();

			var accs = search.Search();

			AccountsFound.Clear();
			AccsFound.Items.Clear();

			for (int i = 0; i < accs.Count; i++)
			{

				AccountsFound.Add(i, accs[i]);

			}

			foreach (var i in accs)
			{

				AccsFound.Items.Add(i.Email.ToString());

			}
		}

		private void AccsFound_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(AccsFound.SelectedIndex != null)
			{
				try
				{
					UsingAcc = AccountsFound[AccsFound.SelectedIndex];

					//Update Data

					guiEmail.Text = UsingAcc.Email;
					guiPass.Text = UsingAcc.Password;
					guiMethod.Text = UsingAcc.SearchMethod.ToString();
					guiFileLocation.Text = Environment.ExpandEnvironmentVariables(UsingAcc.Location);

					if(UsingAcc.SearchMethod == SearchMethod.EverybodyEdits)
					{
						guiSaveButton.Enabled = false;
					}
					else
					{
						guiSaveButton.Enabled = true;
					}
				}
				catch(Exception n)
				{
					MessageBox.Show(n.Message);
				}
			}
		}

		private void metroButton1_Click(object sender, EventArgs e)
		{
			if(!UsingAcc.Delete())
			{
				MessageBox.Show("An error occurred while trying to delete the account. Make sure " + UsingAcc.SearchMethod.ToString() + " is closed!");
			}
			else
			{
				Scan();
			}
		}

		private void guiSaveButton_Click(object sender, EventArgs e)
		{
			UsingAcc.Email = guiEmail.Text;
			UsingAcc.Password = guiPass.Text;
			if (!UsingAcc.Save())
			{
				MessageBox.Show("An error occurred while trying to save the account. Make sure " + UsingAcc.SearchMethod.ToString() + " is closed!");
			}
			else
			{
				Scan();
				MessageBox.Show("Account saved.");
			}
		}
	}
}
