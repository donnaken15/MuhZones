using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

using Nanook.QueenBee.Parser;

public partial class hiway : Form
{
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
	Zones.GFX gfx;
	Zones.Scene scn;
	public hiway(Zones.GFX g, Zones.Scene s)
	{
		InitializeComponent();
		gfx = g;
		scn = s;
		foreach (Zones.Scene.Mat mm in scn)
		{
			matlist.Items.Add(Program.GetDebugName(mm.material));
		}
		foreach (Zones.RawImg ii in gfx)
		{
			Program.loadtext("Adding " + Program.GetDebugName(ii.Name) + "\r");
			texlist.Items.Add(Program.GetDebugName(ii.Name));
		}
		Console.WriteLine("\nTex list done");
	}

	private void selectmat(object sender, EventArgs e)
	{
		matprops.SelectedObject = Zones.Scene.Mat.Fancy(scn[matlist.SelectedIndex]);
		drawmat();
	}
	void drawfail()
	{
		matprev.Image = matprev.ErrorImage;
	}
	// https://stackoverflow.com/a/12210258
	// stupidly dumb
	void add(Bitmap dst, Bitmap src)
	{
		unsafe {
			BitmapData bmpDataA = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadOnly, dst.PixelFormat);
			BitmapData bmpDataB = src.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadOnly, dst.PixelFormat);
			byte* pBmpA = (byte*)bmpDataA.Scan0.ToPointer();
			byte* pBmpB = (byte*)bmpDataB.Scan0.ToPointer();
			int bytesPerPix = bmpDataA.Stride / dst.Width;
			for (int y = 0; y < dst.Height; y++)
			{
				for (int x = 0; x < dst.Width; x++, pBmpA += bytesPerPix, pBmpB += bytesPerPix)
				{
					*(pBmpA) = (byte)Math.Min(*pBmpA + *pBmpB, 255); // R
					*(pBmpA + 1) = (byte)Math.Min(*(pBmpA + 1) + *(pBmpB + 1), 255); // G
					*(pBmpA + 2) = (byte)Math.Min(*(pBmpA + 2) + *(pBmpB + 2), 255); // B
				}
			}
			dst.UnlockBits(bmpDataA);
			src.UnlockBits(bmpDataB);
		}
	}
	void mul(Bitmap dst, Bitmap src)
	{
		unsafe {
			BitmapData bmpDataA = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadOnly, dst.PixelFormat);
			BitmapData bmpDataB = src.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadOnly, dst.PixelFormat);
			byte* pBmpA = (byte*)bmpDataA.Scan0.ToPointer();
			byte* pBmpB = (byte*)bmpDataB.Scan0.ToPointer();
			int bytesPerPix = bmpDataA.Stride / dst.Width;
			for (int y = 0; y < dst.Height; y++)
			{
				for (int x = 0; x < dst.Width; x++, pBmpA += bytesPerPix, pBmpB += bytesPerPix)
				{
					*pBmpA = (byte)(*(pBmpA) * ((float)*(pBmpB) / 255));
					*(pBmpA + 1) = (byte)(*(pBmpA + 1) * ((float)*(pBmpB + 1) / 255));
					*(pBmpA + 2) = (byte)(*(pBmpA + 2) * ((float)*(pBmpB + 2) / 255));
				}
			}
			dst.UnlockBits(bmpDataA);
			src.UnlockBits(bmpDataB);
		}
	}
	/*void add(Bitmap dst, Bitmap src)
	{
		for (int y = 0; y < src.Height; y++)
		{
			for (int x = 0; x < src.Width; x++)
			{
				Color cA = dst.GetPixel(x,y);
				Color cB = src.GetPixel(x,y);
				Color cC = Color.FromArgb(cA.A,
					Math.Min(cA.R + cB.R, 255),
					Math.Min(cA.G + cB.G, 255),
					Math.Min(cA.B + cB.B, 255));
				dst.SetPixel(x, y, cC);
			}
		}
	}
	void mul(Bitmap dst, Bitmap src)
	{
		for (int y = 0; y < src.Height; y++)
		{
			for (int x = 0; x < src.Width; x++)
			{
				Color cA = dst.GetPixel(x,y);
				Color cB = src.GetPixel(x,y);
				Color cC = Color.FromArgb(cA.A,
					(int)((float)cA.R * ((float)cB.R / 255)),
					(int)((float)cA.G * ((float)cB.G / 255)),
					(int)((float)cA.B * ((float)cB.B / 255)));
				dst.SetPixel(x, y, cC);
			}
		}
	}*/
	void mul(Bitmap src, Color c)
	{
		for (int y = 0; y < src.Height; y++)
		{
			for (int x = 0; x < src.Width; x++)
			{
				Color cA = src.GetPixel(x,y);
				Color cC = Color.FromArgb(cA.A,
					(int)((float)cA.R * ((float)c.R / 255)),
					(int)((float)cA.G * ((float)c.G / 255)),
					(int)((float)cA.B * ((float)c.B / 255)));
				src.SetPixel(x, y, cC);
			}
		}
	}
	public Bitmap CreateNonIndexedImage(Image src)
	{
		Bitmap newBmp = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
		
		using (Graphics gfx = Graphics.FromImage(newBmp)) {
			gfx.DrawImage(src, 0, 0);
		}
		
		return newBmp;
	}
	void drawmat()
	{
		if (matlist.SelectedIndices.Count < 1) return;
		Zones.Scene.Mat m = scn[matlist.SelectedIndex];
		if (m.texCount < 1) { drawfail(); return; }
		QbKey t = m.Key(m.texOffset);
		int ii = gfx.IndexOf(t.Crc);
		if (ii == -1) { drawfail(); return; }
		try {
			Bitmap iii = CreateNonIndexedImage(gfx[ii].Image);
			Bitmap render;
			//throw new Exception("Draw fail test");
			// just to accurately draw them like they would be in GH3
			// even if the sizes are inconsistent
			//float tW = ((float)gfx[ii].widthScale * ((float)gfx[ii].widthScale / (float)gfx[ii].Image.Width));
			//float tH = ((float)gfx[ii].heightScale * ((float)gfx[ii].heightScale / (float)gfx[ii].Image.Height));
			//Bitmap render = new Bitmap(
				//gfx[ii].widthScale - (gfx[ii].widthScale - gfx[ii].widthClip),
				//gfx[ii].heightScale - (gfx[ii].heightScale - gfx[ii].heightClip));
			//RectangleF clip,
			//Bitmap iii = (Bitmap)gfx[ii].Image;
			//Bitmap render;
			if (m.eshader == Zones.Scene.Mat.Shader.AnimatedTexture_UI)
			{
				if ((int)((float)iii.Width / m.props(0)[0]) < 1 ||
					(int)((float)iii.Height / m.props(1)[0]) < 1)
				{
					matprev.Image = matprev.ErrorImage;
					return;
				}
				render = new Bitmap(
					(int)((float)iii.Width / m.props(0)[0]),
					(int)((float)iii.Height / m.props(1)[0]));
			}
			else
			{
				render = new Bitmap(iii.Width, iii.Height);
				matAnimClock.Stop();
				matAnimClock.Enabled = false;
			}
			Graphics g = Graphics.FromImage(render);
			g.Clear(matprev.BackColor);
			if (m.eshader == Zones.Scene.Mat.Shader.AnimatedTexture_UI)
			{
				matAnimClock.Interval = (int)(1.0f/m.props(2)[0]*1000);
				matAnimClock.Start();
				uint ucount = (uint)m.props(0)[0],
					vcount = (uint)m.props(1)[0];
				int ucell_single = iii.Width / (int)ucount,
					vcell_single = iii.Height / (int)vcount;
				matDisplayInterval = matDisplayInterval % (ucount * vcount);
				uint uframe = matDisplayInterval % ucount,
					vframe = matDisplayInterval / ucount;
				int l = ucell_single * (int)uframe;
				int u = vcell_single * (int)vframe;
				int w = l + ucell_single;
				int h = u + vcell_single;
				Bitmap tmp = new Bitmap(ucell_single, vcell_single);
				Graphics gg = Graphics.FromImage(tmp);
				gg.DrawImage(iii,0,0,
					new Rectangle(
						l, u, w, h
					),GraphicsUnit.Pixel);
				iii = tmp;
			}
			// kill me
			if (m.eshader ==
					Zones.Scene.Mat.Shader.ImmediateMode_UI ||
				m.eshader ==
					Zones.Scene.Mat.Shader.AnimatedTexture_UI ||
				m.eshader ==
					Zones.Scene.Mat.Shader.ImmediateMode_AlphaFade_UI)
				if (m.getColor(m.prop2Count, m.prop2Offset) != Color.White)
					mul(iii, m.getColor(m.prop2Count, m.prop2Offset));
			//if (m.eshader != Zones.Scene.Mat.Shader.AnimatedTexture_UI)
			{
				switch (m.Blend)
				{
					case Zones.Scene.Blend.Add:
						add(render, iii);
						break;
					case Zones.Scene.Blend.Multiply:
						mul(render, iii);
						break;
					default:
						g.DrawImageUnscaled(iii,0,0);
						break;
				}
			}
			matprev.Image = render;
		}
		catch (Exception ex) {
			matprev.CreateGraphics().
				DrawString("ERROR! :(\n"+ex,
				new Font("Microsoft Sans Serif", 11, FontStyle.Regular, GraphicsUnit.Pixel),
				new Pen(Color.Red).Brush, 0.0f, 0.0f);
		}
	}
	void clickbgcol(object sender, EventArgs e)
	{
		if (coldiag.ShowDialog() == DialogResult.OK)
		{
			matprev.BackColor = coldiag.Color;
			drawmat();
		}
	}
	
	uint matDisplayInterval = 0;
	void tick0(object sender, EventArgs e)
	{
		matDisplayInterval++;
		drawmat();
	}
	
	void paintmat(object sender, PaintEventArgs e)
	{
		if (matprev.Image == null) return;
		matprev.SizeMode =
			(matprev.Width < matprev.Image.Width ||
			matprev.Height < matprev.Image.Height) ?
			PictureBoxSizeMode.Zoom :
			PictureBoxSizeMode.CenterImage;
	}
	
	bool locktab = true;
	void changelisttab(object sender, TabControlEventArgs e)
	{
		locktab = false;
		matprevTabs.SelectedIndex = e.TabPageIndex;
		locktab = true;
	}
	void locktabselect0(object sender, TabControlCancelEventArgs e)
	{
		if (locktab)
			e.Cancel = true;
	}
	
	void refreshimgview(object sender, PaintEventArgs e)
	{
		if (texview.Image == null) return;
		texview.SizeMode =
			(texview.Width < texview.Image.Width ||
			texview.Height < texview.Image.Height) ?
			PictureBoxSizeMode.Zoom :
			PictureBoxSizeMode.CenterImage;
	}
	
	void selimg(object sender, EventArgs e)
	{
		if (texlist.SelectedIndices.Count > 0)
		{
			int index = texlist.SelectedIndices[0];
			texview.Image = gfx[index].Image;
			texprops.SelectedObject = gfx[index];
		}
		texdel.Enabled =
			texedit.Enabled =
			texsave.Enabled =
			texlist.SelectedIndices.Count > 0;
		matDisplayInterval = 0;
	}
	
	void updatetexprops(object s, PropertyValueChangedEventArgs e)
	{
		if (texlist.SelectedIndices.Count > 0)
		{
			int index = texlist.SelectedIndices[0];
			if (e.ChangedItem.Label == "Name")
				texlist.Items[index] = (string)e.ChangedItem.Value;
		}
	}
	
	void savetex(object sender, EventArgs e)
	{
		
	}
	
	void edittex(object sender, EventArgs e)
	{
		if (openimg.ShowDialog() == DialogResult.OK)
		{
			if (texlist.SelectedIndices.Count > 0)
			{
				int index = texlist.SelectedIndices[0];
				QbKey key = gfx[index].Name;
				gfx[index] = Zones.RawImg.MakeFromRaw(openimg.FileName);
				gfx[index].Name = key;
				texview.Image = gfx[index].Image;
				texprops.SelectedObject = gfx[index];
			}
		}
	}
}
