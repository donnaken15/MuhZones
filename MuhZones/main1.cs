using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace MuhZones
{
	public partial class main1 : Form
	{
		public const string template = "_default.pak.xen";
		public main1()
		{
			InitializeComponent();
			foreach (string a in Program.args)
			{
				if (File.Exists(a))
					LoadZones(a);
				else
				{
					if (a.ToLower() != "-l")
						Console.WriteLine("Invalid file name: "+a);
				}
			}
		}

		public List<container> c = new List<container>();
		void LoadZones(string fname)
		{
			Console.Write("Loading "+fname+"...");
			Console.WriteLine();
			Zones z = new Zones(fname);
			container cc = new container(z);
			c.Add(cc);
			cc.fname = fname;
			cc.Text = Path.GetFileName(fname);
			cc.FormClosed += ccclose;
			cc.Show();
			//c.MdiParent = this;
		}

		private void ccclose(object sender, FormClosedEventArgs e)
		{
			// am i doing it right
			// soy
			c.Remove((container)sender);
			((container)sender).z.Dispose();
			((container)sender).ii.Dispose();
			((container)sender).Dispose();
			GC.Collect();
		}

		private void gettemplate(object sender, EventArgs e)
		{
			if (saveDiag.ShowDialog() != DialogResult.OK) return; // OKNOTOK
			string pbt = Program.folder + template.Replace(".pab",".pak");
			string pkt = Program.folder + template.Replace(".pak",".pab");
			string pbo = saveDiag.FileName.Replace(".pab",".pak");
			string pko = saveDiag.FileName.Replace(".pak",".pab");
			File.Copy(pbt, pbo, true);
			File.Copy(pkt, pko, true);
			LoadZones(pbo);
		}
		void openz(object sender, EventArgs e)
		{
			if (openDiag.ShowDialog() != DialogResult.OK) return; // OKNOTOK
			string pbo = openDiag.FileName.Replace(".pab",".pak");
			string pko = openDiag.FileName.Replace(".pak",".pab");
			LoadZones(pbo);
		}
	}
}
