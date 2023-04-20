using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

public partial class container /*HAH*/ : Form
{
	public Zones z;
	public imglist ii;
	public hiway hh;
	public string fname = null;

	public container(Zones zones)
	{
		InitializeComponent();
		CenterToParent();
		z = zones;
		ii = new imglist(z.images);
		ii.MdiParent = this;
		ii.Show();
		hh = new hiway(z.gfx, z.scn);
		hh.MdiParent = this;
		hh.Show();
	}
	void saveNormal(object sender, EventArgs e)
	{
		//z.Save();
	}
	void saveAs(object sender, EventArgs e)
	{
		//z.Save(saveDiag.FileName);
	}
}
