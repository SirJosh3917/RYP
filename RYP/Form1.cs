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
