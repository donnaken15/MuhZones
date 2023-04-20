partial class imglist
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
		this.splitter1 = new System.Windows.Forms.SplitContainer();
		this.splitter2 = new System.Windows.Forms.SplitContainer();
		this.exportbtn = new System.Windows.Forms.Button();
		this.imgreplace = new System.Windows.Forms.Button();
		this.imgdel = new System.Windows.Forms.Button();
		this.imgadd = new System.Windows.Forms.Button();
		this.imagelist = new System.Windows.Forms.ListView();
		this.texname = new System.Windows.Forms.ColumnHeader();
		this.imgprops = new System.Windows.Forms.PropertyGrid();
		this.imageview = new System.Windows.Forms.PictureBox();
		this.openimg = new System.Windows.Forms.OpenFileDialog();
		this.saveimg = new System.Windows.Forms.SaveFileDialog();
		((System.ComponentModel.ISupportInitialize)(this.splitter1)).BeginInit();
		this.splitter1.Panel1.SuspendLayout();
		this.splitter1.Panel2.SuspendLayout();
		this.splitter1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.splitter2)).BeginInit();
		this.splitter2.Panel1.SuspendLayout();
		this.splitter2.Panel2.SuspendLayout();
		this.splitter2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.imageview)).BeginInit();
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
		this.splitter1.Panel1.Controls.Add(this.splitter2);
		// 
		// splitter1.Panel2
		// 
		this.splitter1.Panel2.Controls.Add(this.imageview);
		this.splitter1.Size = new System.Drawing.Size(615, 481);
		this.splitter1.SplitterDistance = 209;
		this.splitter1.TabIndex = 0;
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
		this.splitter2.Panel1.Controls.Add(this.exportbtn);
		this.splitter2.Panel1.Controls.Add(this.imgreplace);
		this.splitter2.Panel1.Controls.Add(this.imgdel);
		this.splitter2.Panel1.Controls.Add(this.imgadd);
		this.splitter2.Panel1.Controls.Add(this.imagelist);
		// 
		// splitter2.Panel2
		// 
		this.splitter2.Panel2.Controls.Add(this.imgprops);
		this.splitter2.Size = new System.Drawing.Size(209, 481);
		this.splitter2.SplitterDistance = 316;
		this.splitter2.TabIndex = 2;
		// 
		// exportbtn
		// 
		this.exportbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.exportbtn.Enabled = false;
		this.exportbtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.exportbtn.Location = new System.Drawing.Point(101, 294);
		this.exportbtn.Name = "exportbtn";
		this.exportbtn.Size = new System.Drawing.Size(44, 19);
		this.exportbtn.TabIndex = 6;
		this.exportbtn.Text = "Save";
		this.exportbtn.UseVisualStyleBackColor = true;
		this.exportbtn.Click += new System.EventHandler(this.expimg);
		// 
		// imgreplace
		// 
		this.imgreplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.imgreplace.Enabled = false;
		this.imgreplace.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.imgreplace.Location = new System.Drawing.Point(42, 294);
		this.imgreplace.Name = "imgreplace";
		this.imgreplace.Size = new System.Drawing.Size(57, 19);
		this.imgreplace.TabIndex = 4;
		this.imgreplace.Text = "Replace";
		this.imgreplace.UseVisualStyleBackColor = true;
		this.imgreplace.Click += new System.EventHandler(this.editimg);
		// 
		// imgdel
		// 
		this.imgdel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.imgdel.Enabled = false;
		this.imgdel.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.imgdel.Location = new System.Drawing.Point(23, 294);
		this.imgdel.Name = "imgdel";
		this.imgdel.Size = new System.Drawing.Size(17, 19);
		this.imgdel.TabIndex = 3;
		this.imgdel.Text = "-";
		this.imgdel.UseVisualStyleBackColor = true;
		this.imgdel.Click += new System.EventHandler(this.delimg);
		// 
		// imgadd
		// 
		this.imgadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.imgadd.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.imgadd.Location = new System.Drawing.Point(4, 294);
		this.imgadd.Name = "imgadd";
		this.imgadd.Size = new System.Drawing.Size(17, 19);
		this.imgadd.TabIndex = 2;
		this.imgadd.Text = "+";
		this.imgadd.UseVisualStyleBackColor = true;
		this.imgadd.Click += new System.EventHandler(this.addimg);
		// 
		// imagelist
		// 
		this.imagelist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
								| System.Windows.Forms.AnchorStyles.Left) 
								| System.Windows.Forms.AnchorStyles.Right)));
		this.imagelist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
								this.texname});
		this.imagelist.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		this.imagelist.GridLines = true;
		this.imagelist.HideSelection = false;
		this.imagelist.Location = new System.Drawing.Point(0, 0);
		this.imagelist.MultiSelect = false;
		this.imagelist.Name = "imagelist";
		this.imagelist.Size = new System.Drawing.Size(209, 292);
		this.imagelist.TabIndex = 1;
		this.imagelist.UseCompatibleStateImageBehavior = false;
		this.imagelist.View = System.Windows.Forms.View.Details;
		this.imagelist.SelectedIndexChanged += new System.EventHandler(this.selectedimg);
		// 
		// texname
		// 
		this.texname.Text = "Name";
		this.texname.Width = 181;
		// 
		// imgprops
		// 
		this.imgprops.Dock = System.Windows.Forms.DockStyle.Fill;
		this.imgprops.HelpVisible = false;
		this.imgprops.Location = new System.Drawing.Point(0, 0);
		this.imgprops.Name = "imgprops";
		this.imgprops.Size = new System.Drawing.Size(209, 161);
		this.imgprops.TabIndex = 0;
		this.imgprops.ToolbarVisible = false;
		this.imgprops.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.updateprops);
		// 
		// imageview
		// 
		this.imageview.Dock = System.Windows.Forms.DockStyle.Fill;
		this.imageview.Location = new System.Drawing.Point(0, 0);
		this.imageview.Name = "imageview";
		this.imageview.Size = new System.Drawing.Size(402, 481);
		this.imageview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
		this.imageview.TabIndex = 0;
		this.imageview.TabStop = false;
		this.imageview.Paint += new System.Windows.Forms.PaintEventHandler(this.refreshimgview);
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
		// imglist
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(615, 481);
		this.Controls.Add(this.splitter1);
		this.Name = "imglist";
		this.ShowIcon = false;
		this.Text = "Images";
		this.splitter1.Panel1.ResumeLayout(false);
		this.splitter1.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)(this.splitter1)).EndInit();
		this.splitter1.ResumeLayout(false);
		this.splitter2.Panel1.ResumeLayout(false);
		this.splitter2.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)(this.splitter2)).EndInit();
		this.splitter2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)(this.imageview)).EndInit();
		this.ResumeLayout(false);
	}

	#endregion

	private System.Windows.Forms.SplitContainer splitter1;
	private System.Windows.Forms.SplitContainer splitter2;
	private System.Windows.Forms.Button imgdel;
	private System.Windows.Forms.Button imgadd;
	private System.Windows.Forms.ListView imagelist;
	private System.Windows.Forms.PropertyGrid imgprops;
	private System.Windows.Forms.Button imgreplace;
	private System.Windows.Forms.PictureBox imageview;
	private System.Windows.Forms.ColumnHeader texname;
	private System.Windows.Forms.Button exportbtn;
	private System.Windows.Forms.OpenFileDialog openimg;
	private System.Windows.Forms.SaveFileDialog saveimg;
}
