partial class hiway
{
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.splitter1 = new System.Windows.Forms.SplitContainer();
		this.matprevTabs = new System.Windows.Forms.TabControl();
		this.tabPage2 = new System.Windows.Forms.TabPage();
		this.splitter2 = new System.Windows.Forms.SplitContainer();
		this.bgcolbtn = new System.Windows.Forms.Button();
		this.matprev = new System.Windows.Forms.PictureBox();
		this.matprops = new System.Windows.Forms.PropertyGrid();
		this.tabPage1 = new System.Windows.Forms.TabPage();
		this.splitter3 = new System.Windows.Forms.SplitContainer();
		this.texview = new System.Windows.Forms.PictureBox();
		this.texprops = new System.Windows.Forms.PropertyGrid();
		this.listtabs = new System.Windows.Forms.TabControl();
		this.mattab = new System.Windows.Forms.TabPage();
		this.matlist = new System.Windows.Forms.ListBox();
		this.matdel = new System.Windows.Forms.Button();
		this.matadd = new System.Windows.Forms.Button();
		this.textab = new System.Windows.Forms.TabPage();
		this.texsave = new System.Windows.Forms.Button();
		this.texedit = new System.Windows.Forms.Button();
		this.texlist = new System.Windows.Forms.ListBox();
		this.texdel = new System.Windows.Forms.Button();
		this.texadd = new System.Windows.Forms.Button();
		this.matAnimClock = new System.Windows.Forms.Timer(this.components);
		this.openimg = new System.Windows.Forms.OpenFileDialog();
		this.saveimg = new System.Windows.Forms.SaveFileDialog();
		this.coldiag = new System.Windows.Forms.ColorDialog();
		((System.ComponentModel.ISupportInitialize)(this.splitter1)).BeginInit();
		this.splitter1.Panel1.SuspendLayout();
		this.splitter1.Panel2.SuspendLayout();
		this.splitter1.SuspendLayout();
		this.matprevTabs.SuspendLayout();
		this.tabPage2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.splitter2)).BeginInit();
		this.splitter2.Panel1.SuspendLayout();
		this.splitter2.Panel2.SuspendLayout();
		this.splitter2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.matprev)).BeginInit();
		this.tabPage1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.splitter3)).BeginInit();
		this.splitter3.Panel1.SuspendLayout();
		this.splitter3.Panel2.SuspendLayout();
		this.splitter3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.texview)).BeginInit();
		this.listtabs.SuspendLayout();
		this.mattab.SuspendLayout();
		this.textab.SuspendLayout();
		this.SuspendLayout();
		// 
		// splitter1
		// 
		this.splitter1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitter1.Location = new System.Drawing.Point(0, 0);
		this.splitter1.Name = "splitter1";
		// 
		// splitter1.Panel1
		// 
		this.splitter1.Panel1.Controls.Add(this.matprevTabs);
		// 
		// splitter1.Panel2
		// 
		this.splitter1.Panel2.Controls.Add(this.listtabs);
		this.splitter1.Size = new System.Drawing.Size(597, 467);
		this.splitter1.SplitterDistance = 301;
		this.splitter1.TabIndex = 0;
		// 
		// matprevTabs
		// 
		this.matprevTabs.Controls.Add(this.tabPage2);
		this.matprevTabs.Controls.Add(this.tabPage1);
		this.matprevTabs.Dock = System.Windows.Forms.DockStyle.Fill;
		this.matprevTabs.Location = new System.Drawing.Point(0, 0);
		this.matprevTabs.Name = "matprevTabs";
		this.matprevTabs.SelectedIndex = 0;
		this.matprevTabs.Size = new System.Drawing.Size(301, 467);
		this.matprevTabs.TabIndex = 0;
		this.matprevTabs.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.locktabselect0);
		// 
		// tabPage2
		// 
		this.tabPage2.Controls.Add(this.splitter2);
		this.tabPage2.Location = new System.Drawing.Point(4, 22);
		this.tabPage2.Name = "tabPage2";
		this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage2.Size = new System.Drawing.Size(293, 441);
		this.tabPage2.TabIndex = 1;
		this.tabPage2.Text = "Preview";
		this.tabPage2.UseVisualStyleBackColor = true;
		// 
		// splitter2
		// 
		this.splitter2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitter2.Location = new System.Drawing.Point(3, 3);
		this.splitter2.Name = "splitter2";
		this.splitter2.Orientation = System.Windows.Forms.Orientation.Horizontal;
		// 
		// splitter2.Panel1
		// 
		this.splitter2.Panel1.Controls.Add(this.bgcolbtn);
		this.splitter2.Panel1.Controls.Add(this.matprev);
		// 
		// splitter2.Panel2
		// 
		this.splitter2.Panel2.Controls.Add(this.matprops);
		this.splitter2.Size = new System.Drawing.Size(287, 435);
		this.splitter2.SplitterDistance = 258;
		this.splitter2.TabIndex = 0;
		// 
		// bgcolbtn
		// 
		this.bgcolbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.bgcolbtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.bgcolbtn.Location = new System.Drawing.Point(0, 239);
		this.bgcolbtn.Name = "bgcolbtn";
		this.bgcolbtn.Size = new System.Drawing.Size(53, 19);
		this.bgcolbtn.TabIndex = 1;
		this.bgcolbtn.Text = "BG Color";
		this.bgcolbtn.UseVisualStyleBackColor = true;
		this.bgcolbtn.Click += new System.EventHandler(this.clickbgcol);
		// 
		// matprev
		// 
		this.matprev.BackColor = System.Drawing.Color.DimGray;
		this.matprev.Dock = System.Windows.Forms.DockStyle.Fill;
		this.matprev.Location = new System.Drawing.Point(0, 0);
		this.matprev.Name = "matprev";
		this.matprev.Size = new System.Drawing.Size(287, 258);
		this.matprev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
		this.matprev.TabIndex = 0;
		this.matprev.TabStop = false;
		this.matprev.Paint += new System.Windows.Forms.PaintEventHandler(this.paintmat);
		// 
		// matprops
		// 
		this.matprops.Dock = System.Windows.Forms.DockStyle.Fill;
		this.matprops.HelpVisible = false;
		this.matprops.Location = new System.Drawing.Point(0, 0);
		this.matprops.Name = "matprops";
		this.matprops.Size = new System.Drawing.Size(287, 173);
		this.matprops.TabIndex = 0;
		this.matprops.ToolbarVisible = false;
		// 
		// tabPage1
		// 
		this.tabPage1.Controls.Add(this.splitter3);
		this.tabPage1.Location = new System.Drawing.Point(4, 22);
		this.tabPage1.Name = "tabPage1";
		this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage1.Size = new System.Drawing.Size(293, 441);
		this.tabPage1.TabIndex = 0;
		this.tabPage1.Text = "Raw Texture";
		this.tabPage1.UseVisualStyleBackColor = true;
		// 
		// splitter3
		// 
		this.splitter3.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitter3.Location = new System.Drawing.Point(3, 3);
		this.splitter3.Name = "splitter3";
		this.splitter3.Orientation = System.Windows.Forms.Orientation.Horizontal;
		// 
		// splitter3.Panel1
		// 
		this.splitter3.Panel1.Controls.Add(this.texview);
		// 
		// splitter3.Panel2
		// 
		this.splitter3.Panel2.Controls.Add(this.texprops);
		this.splitter3.Size = new System.Drawing.Size(287, 435);
		this.splitter3.SplitterDistance = 258;
		this.splitter3.TabIndex = 0;
		// 
		// texview
		// 
		this.texview.Dock = System.Windows.Forms.DockStyle.Fill;
		this.texview.Location = new System.Drawing.Point(0, 0);
		this.texview.Name = "texview";
		this.texview.Size = new System.Drawing.Size(287, 258);
		this.texview.TabIndex = 0;
		this.texview.TabStop = false;
		this.texview.Paint += new System.Windows.Forms.PaintEventHandler(this.refreshimgview);
		// 
		// texprops
		// 
		this.texprops.Dock = System.Windows.Forms.DockStyle.Fill;
		this.texprops.HelpVisible = false;
		this.texprops.Location = new System.Drawing.Point(0, 0);
		this.texprops.Name = "texprops";
		this.texprops.Size = new System.Drawing.Size(287, 173);
		this.texprops.TabIndex = 0;
		this.texprops.ToolbarVisible = false;
		this.texprops.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.updatetexprops);
		// 
		// listtabs
		// 
		this.listtabs.Controls.Add(this.mattab);
		this.listtabs.Controls.Add(this.textab);
		this.listtabs.Dock = System.Windows.Forms.DockStyle.Fill;
		this.listtabs.Location = new System.Drawing.Point(0, 0);
		this.listtabs.Name = "listtabs";
		this.listtabs.SelectedIndex = 0;
		this.listtabs.Size = new System.Drawing.Size(292, 467);
		this.listtabs.TabIndex = 4;
		this.listtabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.changelisttab);
		// 
		// mattab
		// 
		this.mattab.Controls.Add(this.matlist);
		this.mattab.Controls.Add(this.matdel);
		this.mattab.Controls.Add(this.matadd);
		this.mattab.Location = new System.Drawing.Point(4, 22);
		this.mattab.Name = "mattab";
		this.mattab.Padding = new System.Windows.Forms.Padding(3);
		this.mattab.Size = new System.Drawing.Size(284, 441);
		this.mattab.TabIndex = 0;
		this.mattab.Text = "Materials";
		this.mattab.UseVisualStyleBackColor = true;
		// 
		// matlist
		// 
		this.matlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
						| System.Windows.Forms.AnchorStyles.Left) 
						| System.Windows.Forms.AnchorStyles.Right)));
		this.matlist.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		this.matlist.FormattingEnabled = true;
		this.matlist.IntegralHeight = false;
		this.matlist.ItemHeight = 12;
		this.matlist.Location = new System.Drawing.Point(0, 0);
		this.matlist.Name = "matlist";
		this.matlist.Size = new System.Drawing.Size(284, 416);
		this.matlist.TabIndex = 1;
		this.matlist.SelectedIndexChanged += new System.EventHandler(this.selectmat);
		// 
		// matdel
		// 
		this.matdel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.matdel.Enabled = false;
		this.matdel.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.matdel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		this.matdel.Location = new System.Drawing.Point(23, 418);
		this.matdel.Name = "matdel";
		this.matdel.Size = new System.Drawing.Size(21, 23);
		this.matdel.TabIndex = 3;
		this.matdel.Text = "-";
		this.matdel.UseVisualStyleBackColor = true;
		// 
		// matadd
		// 
		this.matadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.matadd.Enabled = false;
		this.matadd.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.matadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		this.matadd.Location = new System.Drawing.Point(0, 418);
		this.matadd.Name = "matadd";
		this.matadd.Size = new System.Drawing.Size(21, 23);
		this.matadd.TabIndex = 2;
		this.matadd.Text = "+";
		this.matadd.UseVisualStyleBackColor = true;
		// 
		// textab
		// 
		this.textab.Controls.Add(this.texsave);
		this.textab.Controls.Add(this.texedit);
		this.textab.Controls.Add(this.texlist);
		this.textab.Controls.Add(this.texdel);
		this.textab.Controls.Add(this.texadd);
		this.textab.Location = new System.Drawing.Point(4, 22);
		this.textab.Name = "textab";
		this.textab.Padding = new System.Windows.Forms.Padding(3);
		this.textab.Size = new System.Drawing.Size(284, 441);
		this.textab.TabIndex = 1;
		this.textab.Text = "Textures";
		this.textab.UseVisualStyleBackColor = true;
		// 
		// texsave
		// 
		this.texsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.texsave.Enabled = false;
		this.texsave.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.texsave.Location = new System.Drawing.Point(105, 418);
		this.texsave.Name = "texsave";
		this.texsave.Size = new System.Drawing.Size(44, 23);
		this.texsave.TabIndex = 10;
		this.texsave.Text = "Save";
		this.texsave.UseVisualStyleBackColor = true;
		// 
		// texedit
		// 
		this.texedit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.texedit.Enabled = false;
		this.texedit.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.texedit.Location = new System.Drawing.Point(46, 418);
		this.texedit.Name = "texedit";
		this.texedit.Size = new System.Drawing.Size(57, 23);
		this.texedit.TabIndex = 9;
		this.texedit.Text = "Replace";
		this.texedit.UseVisualStyleBackColor = true;
		// 
		// texlist
		// 
		this.texlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
						| System.Windows.Forms.AnchorStyles.Left) 
						| System.Windows.Forms.AnchorStyles.Right)));
		this.texlist.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		this.texlist.FormattingEnabled = true;
		this.texlist.IntegralHeight = false;
		this.texlist.ItemHeight = 12;
		this.texlist.Location = new System.Drawing.Point(0, 0);
		this.texlist.Name = "texlist";
		this.texlist.Size = new System.Drawing.Size(284, 416);
		this.texlist.TabIndex = 4;
		this.texlist.SelectedIndexChanged += new System.EventHandler(this.selimg);
		// 
		// texdel
		// 
		this.texdel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.texdel.Enabled = false;
		this.texdel.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.texdel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		this.texdel.Location = new System.Drawing.Point(23, 418);
		this.texdel.Name = "texdel";
		this.texdel.Size = new System.Drawing.Size(21, 23);
		this.texdel.TabIndex = 6;
		this.texdel.Text = "-";
		this.texdel.UseVisualStyleBackColor = true;
		// 
		// texadd
		// 
		this.texadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.texadd.Enabled = false;
		this.texadd.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.texadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		this.texadd.Location = new System.Drawing.Point(0, 418);
		this.texadd.Name = "texadd";
		this.texadd.Size = new System.Drawing.Size(21, 23);
		this.texadd.TabIndex = 5;
		this.texadd.Text = "+";
		this.texadd.UseVisualStyleBackColor = true;
		// 
		// matAnimClock
		// 
		this.matAnimClock.Interval = 33;
		this.matAnimClock.Tick += new System.EventHandler(this.tick0);
		// 
		// openimg
		// 
		this.openimg.Filter = "Common texture formats|*.png;*.jpg;*.dds;*.jpeg;*.bmp|Pictures|*.png;*.jpg;*.jpeg" +
		";*.bmp;|DirectDraw Surface|*.dds|All files|*.*";
		this.openimg.RestoreDirectory = true;
		this.openimg.Title = "Open Image/DDS";
		// 
		// saveimg
		// 
		this.saveimg.Filter = "Common texture formats|*.png;*.jpg;*.dds;*.jpeg;*.bmp|Pictures|*.png;*.jpg;*.jpeg" +
		";*.bmp;|DirectDraw Surface|*.dds|All files|*.*";
		this.saveimg.RestoreDirectory = true;
		this.saveimg.Title = "Save Image";
		// 
		// coldiag
		// 
		this.coldiag.AnyColor = true;
		this.coldiag.Color = System.Drawing.Color.DimGray;
		this.coldiag.FullOpen = true;
		// 
		// hiway
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(597, 467);
		this.Controls.Add(this.splitter1);
		this.Name = "hiway";
		this.ShowIcon = false;
		this.Text = "Highway Sprites";
		this.splitter1.Panel1.ResumeLayout(false);
		this.splitter1.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)(this.splitter1)).EndInit();
		this.splitter1.ResumeLayout(false);
		this.matprevTabs.ResumeLayout(false);
		this.tabPage2.ResumeLayout(false);
		this.splitter2.Panel1.ResumeLayout(false);
		this.splitter2.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)(this.splitter2)).EndInit();
		this.splitter2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)(this.matprev)).EndInit();
		this.tabPage1.ResumeLayout(false);
		this.splitter3.Panel1.ResumeLayout(false);
		this.splitter3.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)(this.splitter3)).EndInit();
		this.splitter3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)(this.texview)).EndInit();
		this.listtabs.ResumeLayout(false);
		this.mattab.ResumeLayout(false);
		this.textab.ResumeLayout(false);
		this.ResumeLayout(false);
	}
	private System.Windows.Forms.ColorDialog coldiag;
	private System.Windows.Forms.Button bgcolbtn;
	private System.Windows.Forms.SaveFileDialog saveimg;
	private System.Windows.Forms.OpenFileDialog openimg;
	private System.Windows.Forms.Button texedit;
	private System.Windows.Forms.Button texsave;
	private System.Windows.Forms.Timer matAnimClock;
	private System.Windows.Forms.PropertyGrid texprops;
	private System.Windows.Forms.PictureBox texview;
	private System.Windows.Forms.SplitContainer splitter3;

	#endregion

	private System.Windows.Forms.SplitContainer splitter1;
	private System.Windows.Forms.SplitContainer splitter2;
	private System.Windows.Forms.TabControl matprevTabs;
	private System.Windows.Forms.TabPage tabPage2;
	private System.Windows.Forms.TabPage tabPage1;
	private System.Windows.Forms.Button matdel;
	private System.Windows.Forms.Button matadd;
	private System.Windows.Forms.ListBox matlist;
	private System.Windows.Forms.PropertyGrid matprops;
	private System.Windows.Forms.PictureBox matprev;
	private System.Windows.Forms.TabControl listtabs;
	private System.Windows.Forms.TabPage mattab;
	private System.Windows.Forms.TabPage textab;
	private System.Windows.Forms.ListBox texlist;
	private System.Windows.Forms.Button texdel;
	private System.Windows.Forms.Button texadd;
}
