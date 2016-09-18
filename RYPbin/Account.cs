/*
The MIT License (MIT)

Copyright (c) 2016 SirJosh3917

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

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
			OldAccPass = "",
			CupcakePassword = "";

		private SearchMethod AccSearchMethod;

		public Account(
			string email,
			string password,
			SearchMethod searchMethod,
			string fileLocation,
			string cupcakePassword = ""
			)
		{
			Email = email;
			Password = password;
			AccSearchMethod = searchMethod;
			AccLoc = fileLocation;

			OldAccEmail = email;
			OldAccPass = password;

			if(searchMethod == SearchMethod.CupCake)
			{
				CupcakePassword = cupcakePassword;
			}
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
				if ((int)SearchMethod > 2)
					read.Load(Location);
				XmlNodeList nodes = null;

				switch (SearchMethod)
				{
					case SearchMethod.CupCake:
						if (Location.ToLower().EndsWith("settings.xml"))
						{
							if (read != null)
							{
								nodes = read.DocumentElement.SelectNodes(@"/Settings/Accounts/Account");

								foreach (XmlNode i in nodes)
								{
									if (i.Name == "Account") //Make sure we're seeing some Acocunt nodes
									{
										string E = i.SelectSingleNode("Email").InnerText;
										string P = i.SelectSingleNode("Password").InnerText;

										if (E == OldAccEmail &&
											P == CupcakePassword)
										{
											var securePassword = new System.Security.SecureString();

											foreach (char c in Password)
											{
												securePassword.AppendChar(c);
											}

											//Set the email/password

											i.SelectSingleNode("Email").InnerText = Email;

											if (Password == "") //If we're deleting an account
												i.SelectSingleNode("Password").InnerText = "";
											else
												i.SelectSingleNode("Password").InnerText = SecureIt.EncryptString(securePassword);

											CupcakePassword = SecureIt.EncryptString(securePassword);
										}
									}
								}
								read.Save(Location);
							}
						}
						break;
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
				throw m;
				string err = m.Message;
				return false;
			}
		}
	}
}