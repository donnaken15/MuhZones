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
	
	void redrawText()
	{
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
}
