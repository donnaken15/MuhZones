/*
 * Created by SharpDevelop.
 * User: Wesley
 * Date: 4/20/2023
 * Time: 5:56 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
partial class fonts
{
	/// <summary>
	/// Designer variable used to keep track of non-visual components.
	/// </summary>
	private System.ComponentModel.IContainer components = null;
	
	/// <summary>
	/// Disposes resources used by the form.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing) {
			if (components != null) {
				components.Dispose();
			}
		}
		base.Dispose(disposing);
	}
	
	/// <summary>
	/// This method is required for Windows Forms designer support.
	/// Do not change the method contents inside the source code editor. The Forms designer might
	/// not be able to load this method if it was changed manually.
	/// </summary>
	private void InitializeComponent()
	{
		this.fntlist = new System.Windows.Forms.ListBox();
		this.splitter1 = new System.Windows.Forms.SplitContainer();
		this.splitter2 = new System.Windows.Forms.SplitContainer();
		this.splitter5 = new System.Windows.Forms.SplitContainer();
		this.fntprops = new System.Windows.Forms.PropertyGrid();
		this.splitter4 = new System.Windows.Forms.SplitContainer();
		this.glyphlist = new System.Windows.Forms.ListView();
		this.glyphslbl = new System.Windows.Forms.Label();
		this.remgbtn = new System.Windows.Forms.Button();
		this.addgbtn = new System.Windows.Forms.Button();
		this.dupefontbtn = new System.Windows.Forms.Button();
		this.importfntbtn = new System.Windows.Forms.Button();
		this.setlettersbtn = new System.Windows.Forms.Button();
		this.edittexbtn = new System.Windows.Forms.Button();
		this.exporttexbtn = new System.Windows.Forms.Button();
		this.splitter3 = new System.Windows.Forms.SplitContainer();
		this.fontdisp = new System.Windows.Forms.PictureBox();
		this.texteximg = new System.Windows.Forms.PictureBox();
		this.textex = new System.Windows.Forms.TextBox();
		this.textprevlbl = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)(this.splitter1)).BeginInit();
		this.splitter1.Panel1.SuspendLayout();
		this.splitter1.Panel2.SuspendLayout();
		this.splitter1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.splitter2)).BeginInit();
		this.splitter2.Panel1.SuspendLayout();
		this.splitter2.Panel2.SuspendLayout();
		this.splitter2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.splitter5)).BeginInit();
		this.splitter5.Panel1.SuspendLayout();
		this.splitter5.Panel2.SuspendLayout();
		this.splitter5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.splitter4)).BeginInit();
		this.splitter4.Panel1.SuspendLayout();
		this.splitter4.Panel2.SuspendLayout();
		this.splitter4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.splitter3)).BeginInit();
		this.splitter3.Panel1.SuspendLayout();
		this.splitter3.Panel2.SuspendLayout();
		this.splitter3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.fontdisp)).BeginInit();
		((System.ComponentModel.ISupportInitialize)(this.texteximg)).BeginInit();
		this.SuspendLayout();
		// 
		// fntlist
		// 
		this.fntlist.Dock = System.Windows.Forms.DockStyle.Fill;
		this.fntlist.FormattingEnabled = true;
		this.fntlist.Location = new System.Drawing.Point(0, 0);
		this.fntlist.Name = "fntlist";
		this.fntlist.Size = new System.Drawing.Size(156, 102);
		this.fntlist.TabIndex = 0;
		this.fntlist.SelectedIndexChanged += new System.EventHandler(this.selectedfnt);
		// 
		// splitter1
		// 
		this.splitter1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitter1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
		this.splitter1.Location = new System.Drawing.Point(0, 0);
		this.splitter1.Name = "splitter1";
		// 
		// splitter1.Panel1
		// 
		this.splitter1.Panel1.Controls.Add(this.splitter2);
		// 
		// splitter1.Panel2
		// 
		this.splitter1.Panel2.Controls.Add(this.splitter3);
		this.splitter1.Size = new System.Drawing.Size(579, 487);
		this.splitter1.SplitterDistance = 156;
		this.splitter1.TabIndex = 1;
		// 
		// splitter2
		// 
		this.splitter2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitter2.Location = new System.Drawing.Point(0, 0);
		this.splitter2.Name = "splitter2";
		this.splitter2.Orientation = System.Windows.Forms.Orientation.Horizontal;
		// 
		// splitter2.Panel1
		// 
		this.splitter2.Panel1.Controls.Add(this.splitter5);
		// 
		// splitter2.Panel2
		// 
		this.splitter2.Panel2.Controls.Add(this.splitter4);
		this.splitter2.Size = new System.Drawing.Size(156, 487);
		this.splitter2.SplitterDistance = 196;
		this.splitter2.TabIndex = 0;
		// 
		// splitter5
		// 
		this.splitter5.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitter5.Location = new System.Drawing.Point(0, 0);
		this.splitter5.Name = "splitter5";
		this.splitter5.Orientation = System.Windows.Forms.Orientation.Horizontal;
		// 
		// splitter5.Panel1
		// 
		this.splitter5.Panel1.Controls.Add(this.fntlist);
		// 
		// splitter5.Panel2
		// 
		this.splitter5.Panel2.Controls.Add(this.fntprops);
		this.splitter5.Size = new System.Drawing.Size(156, 196);
		this.splitter5.SplitterDistance = 102;
		this.splitter5.TabIndex = 1;
		// 
		// fntprops
		// 
		this.fntprops.Dock = System.Windows.Forms.DockStyle.Fill;
		this.fntprops.HelpVisible = false;
		this.fntprops.Location = new System.Drawing.Point(0, 0);
		this.fntprops.Name = "fntprops";
		this.fntprops.Size = new System.Drawing.Size(156, 90);
		this.fntprops.TabIndex = 1;
		this.fntprops.ToolbarVisible = false;
		this.fntprops.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.editedfnt);
		// 
		// splitter4
		// 
		this.splitter4.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitter4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
		this.splitter4.Location = new System.Drawing.Point(0, 0);
		this.splitter4.Name = "splitter4";
		this.splitter4.Orientation = System.Windows.Forms.Orientation.Horizontal;
		// 
		// splitter4.Panel1
		// 
		this.splitter4.Panel1.Controls.Add(this.glyphlist);
		this.splitter4.Panel1.Controls.Add(this.glyphslbl);
		// 
		// splitter4.Panel2
		// 
		this.splitter4.Panel2.Controls.Add(this.remgbtn);
		this.splitter4.Panel2.Controls.Add(this.addgbtn);
		this.splitter4.Panel2.Controls.Add(this.dupefontbtn);
		this.splitter4.Panel2.Controls.Add(this.importfntbtn);
		this.splitter4.Panel2.Controls.Add(this.setlettersbtn);
		this.splitter4.Panel2.Controls.Add(this.edittexbtn);
		this.splitter4.Panel2.Controls.Add(this.exporttexbtn);
		this.splitter4.Panel2.Enabled = false;
		this.splitter4.Size = new System.Drawing.Size(156, 287);
		this.splitter4.SplitterDistance = 125;
		this.splitter4.TabIndex = 0;
		// 
		// glyphlist
		// 
		this.glyphlist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
		this.glyphlist.Dock = System.Windows.Forms.DockStyle.Fill;
		this.glyphlist.ForeColor = System.Drawing.Color.White;
		this.glyphlist.Location = new System.Drawing.Point(0, 18);
		this.glyphlist.Name = "glyphlist";
		this.glyphlist.Size = new System.Drawing.Size(156, 107);
		this.glyphlist.TabIndex = 5;
		this.glyphlist.UseCompatibleStateImageBehavior = false;
		this.glyphlist.View = System.Windows.Forms.View.Tile;
		// 
		// glyphslbl
		// 
		this.glyphslbl.Dock = System.Windows.Forms.DockStyle.Top;
		this.glyphslbl.Location = new System.Drawing.Point(0, 0);
		this.glyphslbl.Name = "glyphslbl";
		this.glyphslbl.Size = new System.Drawing.Size(156, 18);
		this.glyphslbl.TabIndex = 4;
		this.glyphslbl.Text = "Glyphs:";
		// 
		// remgbtn
		// 
		this.remgbtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.remgbtn.Location = new System.Drawing.Point(72, 6);
		this.remgbtn.Name = "remgbtn";
		this.remgbtn.Size = new System.Drawing.Size(81, 23);
		this.remgbtn.TabIndex = 9;
		this.remgbtn.Text = "Remove";
		this.remgbtn.UseVisualStyleBackColor = true;
		// 
		// addgbtn
		// 
		this.addgbtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.addgbtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.addgbtn.Location = new System.Drawing.Point(3, 6);
		this.addgbtn.Name = "addgbtn";
		this.addgbtn.Size = new System.Drawing.Size(66, 23);
		this.addgbtn.TabIndex = 8;
		this.addgbtn.Text = "Add";
		this.addgbtn.UseVisualStyleBackColor = true;
		// 
		// dupefontbtn
		// 
		this.dupefontbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
						| System.Windows.Forms.AnchorStyles.Right)));
		this.dupefontbtn.Location = new System.Drawing.Point(3, 132);
		this.dupefontbtn.Name = "dupefontbtn";
		this.dupefontbtn.Size = new System.Drawing.Size(150, 23);
		this.dupefontbtn.TabIndex = 7;
		this.dupefontbtn.Text = "Duplicate";
		this.dupefontbtn.UseVisualStyleBackColor = true;
		// 
		// importfntbtn
		// 
		this.importfntbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
						| System.Windows.Forms.AnchorStyles.Right)));
		this.importfntbtn.Location = new System.Drawing.Point(3, 106);
		this.importfntbtn.Name = "importfntbtn";
		this.importfntbtn.Size = new System.Drawing.Size(150, 23);
		this.importfntbtn.TabIndex = 6;
		this.importfntbtn.Text = "Import Hiero Font";
		this.importfntbtn.UseVisualStyleBackColor = true;
		// 
		// setlettersbtn
		// 
		this.setlettersbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
						| System.Windows.Forms.AnchorStyles.Right)));
		this.setlettersbtn.Location = new System.Drawing.Point(3, 32);
		this.setlettersbtn.Name = "setlettersbtn";
		this.setlettersbtn.Size = new System.Drawing.Size(150, 23);
		this.setlettersbtn.TabIndex = 4;
		this.setlettersbtn.Text = "Assign Symbols";
		this.setlettersbtn.UseVisualStyleBackColor = true;
		this.setlettersbtn.Click += new System.EventHandler(this.opensetletterdiag);
		// 
		// edittexbtn
		// 
		this.edittexbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
						| System.Windows.Forms.AnchorStyles.Right)));
		this.edittexbtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.edittexbtn.Location = new System.Drawing.Point(3, 57);
		this.edittexbtn.Name = "edittexbtn";
		this.edittexbtn.Size = new System.Drawing.Size(150, 23);
		this.edittexbtn.TabIndex = 3;
		this.edittexbtn.Text = "Replace Texture";
		this.edittexbtn.UseVisualStyleBackColor = true;
		// 
		// exporttexbtn
		// 
		this.exporttexbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
						| System.Windows.Forms.AnchorStyles.Right)));
		this.exporttexbtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.exporttexbtn.Location = new System.Drawing.Point(3, 82);
		this.exporttexbtn.Name = "exporttexbtn";
		this.exporttexbtn.Size = new System.Drawing.Size(150, 21);
		this.exporttexbtn.TabIndex = 1;
		this.exporttexbtn.Text = "Save Texture";
		this.exporttexbtn.UseVisualStyleBackColor = true;
		// 
		// splitter3
		// 
		this.splitter3.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitter3.Location = new System.Drawing.Point(0, 0);
		this.splitter3.Name = "splitter3";
		this.splitter3.Orientation = System.Windows.Forms.Orientation.Horizontal;
		// 
		// splitter3.Panel1
		// 
		this.splitter3.Panel1.Controls.Add(this.fontdisp);
		// 
		// splitter3.Panel2
		// 
		this.splitter3.Panel2.Controls.Add(this.texteximg);
		this.splitter3.Panel2.Controls.Add(this.textex);
		this.splitter3.Panel2.Controls.Add(this.textprevlbl);
		this.splitter3.Size = new System.Drawing.Size(419, 487);
		this.splitter3.SplitterDistance = 311;
		this.splitter3.TabIndex = 0;
		// 
		// fontdisp
		// 
		this.fontdisp.BackColor = System.Drawing.Color.Black;
		this.fontdisp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.fontdisp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.fontdisp.Dock = System.Windows.Forms.DockStyle.Fill;
		this.fontdisp.Location = new System.Drawing.Point(0, 0);
		this.fontdisp.Name = "fontdisp";
		this.fontdisp.Size = new System.Drawing.Size(419, 311);
		this.fontdisp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.fontdisp.TabIndex = 0;
		this.fontdisp.TabStop = false;
		this.fontdisp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ged_click);
		this.fontdisp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ged_mmove);
		this.fontdisp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ged_mrel);
		this.fontdisp.Resize += new System.EventHandler(this.ihatemyself);
		// 
		// texteximg
		// 
		this.texteximg.BackColor = System.Drawing.Color.Black;
		this.texteximg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.texteximg.Dock = System.Windows.Forms.DockStyle.Fill;
		this.texteximg.Location = new System.Drawing.Point(0, 17);
		this.texteximg.Name = "texteximg";
		this.texteximg.Size = new System.Drawing.Size(419, 135);
		this.texteximg.TabIndex = 4;
		this.texteximg.TabStop = false;
		this.texteximg.SizeChanged += new System.EventHandler(this.updateTextEx);
		this.texteximg.Paint += new System.Windows.Forms.PaintEventHandler(this.redrawText_);
		// 
		// textex
		// 
		this.textex.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.textex.Location = new System.Drawing.Point(0, 152);
		this.textex.Name = "textex";
		this.textex.Size = new System.Drawing.Size(419, 20);
		this.textex.TabIndex = 3;
		this.textex.Text = "ABCDEFGHabcdefgh 0123456789 The quick brown fox jumped";
		this.textex.TextChanged += new System.EventHandler(this.textexchanged);
		// 
		// textprevlbl
		// 
		this.textprevlbl.Dock = System.Windows.Forms.DockStyle.Top;
		this.textprevlbl.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.textprevlbl.Location = new System.Drawing.Point(0, 0);
		this.textprevlbl.Name = "textprevlbl";
		this.textprevlbl.Size = new System.Drawing.Size(419, 17);
		this.textprevlbl.TabIndex = 0;
		this.textprevlbl.Text = "Text Preview:";
		// 
		// fonts
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(579, 487);
		this.Controls.Add(this.splitter1);
		this.Name = "fonts";
		this.ShowIcon = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Fonts";
		this.splitter1.Panel1.ResumeLayout(false);
		this.splitter1.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)(this.splitter1)).EndInit();
		this.splitter1.ResumeLayout(false);
		this.splitter2.Panel1.ResumeLayout(false);
		this.splitter2.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)(this.splitter2)).EndInit();
		this.splitter2.ResumeLayout(false);
		this.splitter5.Panel1.ResumeLayout(false);
		this.splitter5.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)(this.splitter5)).EndInit();
		this.splitter5.ResumeLayout(false);
		this.splitter4.Panel1.ResumeLayout(false);
		this.splitter4.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)(this.splitter4)).EndInit();
		this.splitter4.ResumeLayout(false);
		this.splitter3.Panel1.ResumeLayout(false);
		this.splitter3.Panel2.ResumeLayout(false);
		this.splitter3.Panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)(this.splitter3)).EndInit();
		this.splitter3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)(this.fontdisp)).EndInit();
		((System.ComponentModel.ISupportInitialize)(this.texteximg)).EndInit();
		this.ResumeLayout(false);
	}
	private System.Windows.Forms.Button addgbtn;
	private System.Windows.Forms.Button remgbtn;
	private System.Windows.Forms.Button exporttexbtn;
	private System.Windows.Forms.Button edittexbtn;
	private System.Windows.Forms.Button setlettersbtn;
	private System.Windows.Forms.Button importfntbtn;
	private System.Windows.Forms.Button dupefontbtn;
	private System.Windows.Forms.SplitContainer splitter4;
	private System.Windows.Forms.Label glyphslbl;
	private System.Windows.Forms.ListView glyphlist;
	private System.Windows.Forms.PropertyGrid fntprops;
	private System.Windows.Forms.SplitContainer splitter5;
	private System.Windows.Forms.TextBox textex;
	private System.Windows.Forms.PictureBox texteximg;
	private System.Windows.Forms.PictureBox fontdisp;
	private System.Windows.Forms.Label textprevlbl;
	private System.Windows.Forms.SplitContainer splitter3;
	private System.Windows.Forms.SplitContainer splitter2;
	private System.Windows.Forms.SplitContainer splitter1;
	private System.Windows.Forms.ListBox fntlist;
}