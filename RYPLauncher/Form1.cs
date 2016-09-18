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
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;

namespace RYPLauncher
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			new Thread(delegate()
			{
				WebClient getFiles = new WebClient();
				getFiles.Proxy = null;

				string DownloadInfo = getFiles.DownloadString(@"https://raw.githubusercontent.com/SirJosh3917/RYP/master/WebDownload/downloaditems.txt");

				List<string> Execute = new List<string>();

				//Download each file

				string[] lines = DownloadInfo.Split(new string[] { Environment.NewLine, "\n", "\"r" }, StringSplitOptions.None);

				foreach (string i in lines)
				{
					// Check if it's a file we can download
					if (i.StartsWith("$"))
					{
						// Download File

						string FileName = i;

						if (FileName.Contains(@"/"))
						{
							FileName = FileName.Split('/')[FileName.Split('/').Length - 1];
						}

						if(!System.IO.Directory.Exists(@"DOWNLOADS"))
						{
							System.IO.Directory.CreateDirectory(@"DOWNLOADS");
						}

						if (System.IO.File.Exists(@"DOWNLOADS\" + FileName))
						{
						redo:
							try
							{
								System.IO.File.Delete(@"DOWNLOADS\" + FileName);
							}
							catch
							{
								goto redo;
							}
						}

						getFiles.DownloadFile(@"https://raw.githubusercontent.com/SirJosh3917/RYP/master/" + i.Substring(1), @"DOWNLOADS\" + FileName);
					}
					else if (i.StartsWith(@"#"))// Check if it's a version info
					{
						// Yup, display the version
						rypVer.Invoke((MethodInvoker)(() => rypVer.Text = i.Substring(1)));
					}
					else if (i.StartsWith(@"@"))// Check if it's an instruction to execute a file
					{
						// Yup, add a thing to start it
						Execute.Add(i.Substring(1));
					}
				}

				foreach(string i in Execute)
				{
					ProcessStartInfo startFileInfo = new ProcessStartInfo();
					startFileInfo.FileName = @"DOWNLOADS\" + i;

					Process startFile = new Process();
					startFile.StartInfo = startFileInfo;

					try
					{
						startFile.Start();
					}
					catch
					{

					}
				}

				progSpin.Invoke((MethodInvoker)(() => progSpin.Spinning = false));

				Thread.Sleep(3000);

				Application.Exit(new System.ComponentModel.CancelEventArgs());
			}).Start();
		}

		public static string DownloadText(string url)
		{
			var request = (HttpWebRequest)WebRequest.Create(url);
			var response = (HttpWebResponse)request.GetResponse();

			using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
			{
				return reader.ReadToEnd();
			}
		}
	}
}
