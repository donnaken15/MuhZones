/*
 * Created by SharpDevelop.
 * User: Wesley
 * Date: 4/20/2023
 * Time: 5:56 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

public partial class fonts : Form
{
	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams parms = base.CreateParams;
			parms.ClassStyle |= 0x200;  // CS_NOCLOSE
			return parms;
		}
	}
	protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
		if (keyData == (Keys.Control | Keys.F4)) {
			Console.Beep();
			return true;
		}
		return base.ProcessCmdKey(ref msg, keyData);
	}
	
	public List<Zones.Font> f;
	public Zones.Font currentfont = null;
	public fonts(List<Zones.Font> fnts)
	{
		InitializeComponent();
		f = fnts;
		foreach (Zones.Font ff in f)
		{
			Program.loadtext("Adding " + Program.GetDebugName(ff.Name) + "\r");
			fntlist.Items.Add(Program.GetDebugName(ff.Name));
		}
		Console.WriteLine("\nFont list done");
	}
	public Rectangle selectbox = nullbox;
	public static readonly Rectangle nullbox = new Rectangle(-1,-1,-1,-1);
	
	void redrawText()
	{
		if (!(texteximg.Width > 0 && texteximg.Height > 0))
			return;
		if (texteximg.Image != null)
			texteximg.Image.Dispose();
		Bitmap rendered_text = new Bitmap(texteximg.Width, texteximg.Height);
		Graphics td = Graphics.FromImage(rendered_text);
		try {
			Zones.Font ff = currentfont;
			if (ff != null)
			{
				float xx = 0, yy = ff.height;
				//float spacing = 1 + (1.0f/8) + ((float)(ff.spacing + ((float)ff.shifter/2)) / 8);
				float spacing = 1; // figure out ^
				for (int i = 0; i < textex.Text.Length; i++)
				{
					Zones.Font.Glyph gg = ff[textex.Text[i]];
					RectangleF gr = ff.glyphRect(textex.Text[i]);
					if (textex.Text[i] != ' ' || ff.glyphblock[' '] != 0)
					{
						td.DrawImage(ff.texture.Image,
							xx + gg.hShift, yy - gr.Height + gg.vShift, gr, GraphicsUnit.Pixel);
						xx += gr.Width * spacing;
					}
					else
						xx += ff.space_width * spacing;
				}
				td.DrawImage(rendered_text, 0, 0);
			}
		}
		catch (Exception ex) {
			Font errfont = new Font("Microsoft Sans Serif", 20f, FontStyle.Bold, GraphicsUnit.Pixel);
			td.DrawString(ex.ToString(), errfont, Brushes.Red, 0, 0);
		}
		texteximg.Image = rendered_text;
	}
	
	void selectedfnt(object sender, EventArgs e)
	{
		currentfont = f[fntlist.SelectedIndex];
		fontdisp.Image = currentfont.texture.Image;
		fntprops.SelectedObject = currentfont;
		redrawText();
	}
	
	void opensetletterdiag(object sender, EventArgs e)
	{
		setsymd checks = new setsymd();
		if (checks.ShowDialog() == DialogResult.OK)
		{
			
		}
	}
	
	void editedfnt(object s, PropertyValueChangedEventArgs e)
	{
		redrawText();
	}
	
	void textexchanged(object sender, EventArgs e)
	{
		redrawText();
	}
	
	void redrawText_(object sender, PaintEventArgs e)
	{
		//redrawText();
	}
	
	void updateTextEx(object sender, EventArgs e)
	{
		redrawText();
	}
	
	float AspectRatio(Size sz)
	{
		return ((float)sz.Width / (float)sz.Height);
	}
	
	void ged_click(object sender, MouseEventArgs e)
	{
		
	}
	
	void ged_mmove(object sender, MouseEventArgs e)
	{
		return;
		if (fontdisp.Image == null) return;
		// hate me for this
		// im small brained
		Size fdsz = fontdisp.Size;
		float fd_asp = AspectRatio(fdsz);
		float tex_asp = AspectRatio(fontdisp.Image.Size);
		SizeF diff = new SizeF(0,0);
		bool stretchdir = fd_asp > tex_asp;
		Size cutoff, scaled; // a blank side of the picturebox, and scale of texture to control
		Graphics g = fontdisp.CreateGraphics();
		if (stretchdir) // horiz
		{
			diff.Width = ((float)fdsz.Width / fontdisp.Image.Size.Width);
			/*scaled = new Size(
				(int)(((float)fdsz.Width / fontdisp.Image.Size.Width) * 100),
				100);*/
		}
		else // vert
		{
			diff.Height = ((float)fdsz.Height / fontdisp.Image.Size.Height);
			/*scaled = new Size(
				100,
				(int)(((float)fdsz.Height / fontdisp.Image.Size.Height) * 100));*/
		}
		//diff = (tex_asp - fd_asp);
		//cutoff = new Size(
			//(int)(((float)fdsz.Width * diff) / 2 - (fdsz.Width/2)),
			//(int)(((float)fdsz.Height  * diff) / 2 - (fdsz.Height/2)));
		g.DrawRectangle(new Pen(Color.Blue), 0, 0, diff.Width, 100);
		g.DrawString("cutoff: "+diff.Width+",",
			new Font("Arial",10f,GraphicsUnit.Pixel),
			Brushes.Red, 4, 4);
		GC.Collect(1);
	}
	
	void ged_mrel(object sender, MouseEventArgs e)
	{
		
	}
	
	void ihatemyself(object sender, EventArgs e)
	{
		
	}
}
