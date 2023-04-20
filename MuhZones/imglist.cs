using Nanook.QueenBee.Parser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

public partial class imglist : Form
{
	public List<Zones.RawImg> i;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams p = base.CreateParams;
			p.ClassStyle |= 0x200;
			return p;
		}
	}
	protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
		if (keyData == (Keys.Control | Keys.F4)) {
			Console.Beep();
			return true;
		}
		return base.ProcessCmdKey(ref msg, keyData);
	}
	public imglist(List<Zones.RawImg> img)
	{
		InitializeComponent();
		i = img;
		foreach (Zones.RawImg ii in i)
		{
			Program.loadtext("Adding " + Program.GetDebugName(ii.Name) + "\r");
			ListViewItem iii = new ListViewItem(Program.GetDebugName(ii.Name));
			iii.Tag = ii;
			imagelist.Items.Add(iii);
		}
		Console.WriteLine("\nImage list done");
	}

	private void selectedimg(object sender, EventArgs e)
	{
		if (imagelist.SelectedIndices.Count > 0)
		{
			int index = imagelist.SelectedIndices[0];
			imageview.Image = i[index].Image;
			imgprops.SelectedObject = i[index];
		}
		imgdel.Enabled =
			imgreplace.Enabled =
			exportbtn.Enabled =
			imagelist.SelectedIndices.Count > 0;
		//if (imagelist.SelectedIndices)
		//imageview.Image = i[imagelist.SelectedIndices[0]].Image;
		//MessageBox.Show(imagelist.SelectedIndices.Count.ToString());
		//MessageBox.Show(imagelist.SelectedIndices[0].ToString());
		//imageview.Image = i[4].Image;
	}

	private void updateprops(object s, PropertyValueChangedEventArgs e)
	{
		if (imagelist.SelectedIndices.Count > 0)
		{
			int index = imagelist.SelectedIndices[0];
			if (e.ChangedItem.Label == "Name")
				imagelist.Items[index].Text = (string)e.ChangedItem.Value;
		}
	}

	private void addimg(object sender, EventArgs e)
	{

	}

	private void delimg(object sender, EventArgs e)
	{

	}

	private void editimg(object sender, EventArgs e)
	{
		if (openimg.ShowDialog() == DialogResult.OK)
		{
			if (imagelist.SelectedIndices.Count > 0)
			{
				int index = imagelist.SelectedIndices[0];
				QbKey key = i[index].Name;
				i[index] = Zones.RawImg.MakeFromRaw(openimg.FileName);
				i[index].Name = key;
				imageview.Image = i[index].Image;
				imgprops.SelectedObject = i[index];
			}
		}
	}

	private void refreshimgview(object sender, PaintEventArgs e)
	{
		// touch from inner window or whatever it's called
		if (imageview.Image == null) return;
		imageview.SizeMode =
			(imageview.Width < imageview.Image.Width ||
			imageview.Height < imageview.Image.Height) ?
			PictureBoxSizeMode.Zoom :
			PictureBoxSizeMode.CenterImage;
	}

	private void expimg(object sender, EventArgs e)
	{
		if (imagelist.SelectedIndices.Count > 0)
		{
			int index = imagelist.SelectedIndices[0];
			saveimg.DefaultExt = i[index].ext;
			if (saveimg.ShowDialog() == DialogResult.OK)
			{
				i[index].Export(saveimg.FileName);
			}
		}
	}
}
