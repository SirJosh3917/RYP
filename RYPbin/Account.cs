using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RYPbin
{
	public class Account
	{
		private string
			AccEmail = "",
			AccPassword = "",
			AccLoc = "",
			OldAccEmail = "",
			OldAccPass = "";

		private SearchMethod AccSearchMethod;

		public Account(
			string email,
			string password,
			SearchMethod searchMethod,
			string fileLocation
			)
		{
			Email = email;
			Password = password;
			AccSearchMethod = searchMethod;
			AccLoc = fileLocation;

			OldAccEmail = email;
			OldAccPass = password;
		}

		public string Email
		{
			get
			{
				return AccEmail;
			}
			set
			{
				OldAccEmail = AccEmail;
				AccEmail = value;
			}
		}

		public string Password
		{
			get
			{
				return AccPassword;
			}
			set
			{
				OldAccPass = AccPassword;
				AccPassword = value;
			}
		}

		public SearchMethod SearchMethod
		{
			get
			{
				return AccSearchMethod;
			}
			set
			{
				AccSearchMethod = value;
			}
		}

		public string Location
		{
			get
			{
				return AccLoc;
			}
			set
			{
				AccLoc = value;
			}
		}

		public Account Clone()
		{
			return new Account(Email, Password, SearchMethod, AccLoc);
		}

		public bool Delete()
		{
			try
			{
				//With .sol, we won't bother doing any formatting and just delete it.
				if(SearchMethod == SearchMethod.EverybodyEdits)
				{
					System.IO.File.Delete(@Location);
					return true;
				}

				//Instead of actually deleting, we'll just set the account info to nothing and save. This will keep most of the user's data.
				AccEmail = "";
				AccPassword = "";
				return Save();
			}
			catch //I would specify the types I'm catching, but I just need to know if it worked.
			{
				return false;
			}
		}

		public bool Save()
		{
			try
			{
				XmlDocument read = new XmlDocument();
				if (SearchMethod == SearchMethod.EEditor ||
					SearchMethod == SearchMethod.MRBot ||
					SearchMethod == SearchMethod.IceBot)
					read.Load(Location);
				XmlNodeList nodes = null;

				switch (SearchMethod)
				{
					case SearchMethod.IceBot:
						nodes = read.DocumentElement.SelectNodes(@"/configuration/userSettings/_x003F_1_x003F_._x003F_11_x003F_._x003F_13_x003F_/setting");

						foreach (XmlNode i in nodes)
						{
							string value = i.SelectSingleNode("value").InnerText;

							string k = i.Attributes["name"].Value;

							if (k == "Email")
							{
								i.SelectSingleNode("value").InnerText = Email;
							}

							if (k == "Password")
							{
								i.SelectSingleNode("value").InnerText = Password;
							}
						}

						read.Save(Location);
						break;
					case SearchMethod.EEditor:
					case SearchMethod.MRBot:

						string AssemblyName = "";

						if (SearchMethod == SearchMethod.EEditor)
							AssemblyName = "EEditor.Properties.Settings";

						if (SearchMethod == SearchMethod.MRBot)
							AssemblyName = "EEbot.Properties.Settings";

						nodes = read.DocumentElement.SelectNodes(@"/configuration/userSettings/" + AssemblyName + "/setting");

						foreach (XmlNode i in nodes)
						{
							string value = i.SelectSingleNode("value").InnerText;

							string k = i.Attributes["name"].Value;

							if (k == "email")
							{
								i.SelectSingleNode("value").InnerText = Email;
							}

							if (k == "password")
							{
								i.SelectSingleNode("value").InnerText = Password;
							}
						}

						read.Save(Location);
						break;
					case SearchMethod.NinjaBot:
						string[] Emails = System.IO.File.ReadAllLines(Environment.ExpandEnvironmentVariables(@"%localappdata%\Ninjabot\accemails.txt"));
						string[] Passwords = System.IO.File.ReadAllLines(Environment.ExpandEnvironmentVariables(@"%localappdata%\Ninjabot\accpasses.txt"));

						for (int i = 0; i < Emails.Length; i++)
						{
							if (Emails[i] == OldAccEmail)
							{
								Emails[i] = AccEmail;
								Passwords[i] = AccPassword;
							}
						}

						System.IO.File.WriteAllLines(Environment.ExpandEnvironmentVariables(@"%localappdata%\Ninjabot\accemails.txt"), Emails);
						System.IO.File.WriteAllLines(Environment.ExpandEnvironmentVariables(@"%localappdata%\Ninjabot\accpasses.txt"), Passwords);
						break;
					case SearchMethod.NinjaBot2:
						string[] NB2 = System.IO.File.ReadAllLines(Environment.ExpandEnvironmentVariables(@"%localappdata%\Ninjabot2.0\remember.dat"));

						NB2[1] = AccEmail;
						NB2[2] = AccPassword;

						System.IO.File.WriteAllLines(Environment.ExpandEnvironmentVariables(@"%localappdata%\Ninjabot2.0\remember.dat"), NB2);
						break;
				}

				return true;
			}
			catch(Exception m) //I would specify the types I'm catching, but I just need to know if it worked.
			{
				string err = m.Message;
				return false;
			}
		}
	}
}