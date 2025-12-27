partial class container
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(container));
		this.tools = new System.Windows.Forms.ToolStrip();
		this.savebtn = new System.Windows.Forms.ToolStripButton();
		this.saveasbtn = new System.Windows.Forms.ToolStripButton();
		this.stat = new System.Windows.Forms.StatusStrip();
		this.autoGC = new System.Windows.Forms.Timer(this.components);
		this.tools.SuspendLayout();
		this.SuspendLayout();
		// 
		// tools
		// 
		this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
						this.savebtn,
						this.saveasbtn});
		this.tools.Location = new System.Drawing.Point(0, 0);
		this.tools.Name = "tools";
		this.tools.Size = new System.Drawing.Size(833, 25);
		this.tools.TabIndex = 1;
		this.tools.Text = "toolStrip1";
		this.tools.Visible = false;
		// 
		// savebtn
		// 
		this.savebtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.savebtn.Image = ((System.Drawing.Image)(resources.GetObject("savebtn.Image")));
		this.savebtn.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.savebtn.Name = "savebtn";
		this.savebtn.Size = new System.Drawing.Size(23, 22);
		this.savebtn.ToolTipText = "Save";
		this.savebtn.Click += new System.EventHandler(this.saveNormal);
		// 
		// saveasbtn
		// 
		this.saveasbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.saveasbtn.Image = ((System.Drawing.Image)(resources.GetObject("saveasbtn.Image")));
		this.saveasbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.saveasbtn.Name = "saveasbtn";
		this.saveasbtn.Size = new System.Drawing.Size(23, 22);
		this.saveasbtn.ToolTipText = "Save as...";
		this.saveasbtn.Click += new System.EventHandler(this.saveAs);
		// 
		// stat
		// 
		this.stat.Location = new System.Drawing.Point(0, 648);
		this.stat.Name = "stat";
		this.stat.Size = new System.Drawing.Size(833, 22);
		this.stat.TabIndex = 2;
		this.stat.Text = "statusStrip1";
		// 
		// autoGC
		// 
		this.autoGC.Enabled = true;
		this.autoGC.Interval = 5000;
		this.autoGC.Tick += new System.EventHandler(this.autoGC_tick);
		// 
		// container
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(833, 670);
		this.Controls.Add(this.stat);
		this.Controls.Add(this.tools);
		this.IsMdiContainer = true;
		this.Name = "container";
		this.ShowIcon = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.tools.ResumeLayout(false);
		this.tools.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();
	}
	private System.Windows.Forms.Timer autoGC;

    #endregion

	private System.Windows.Forms.ToolStrip tools;
	private System.Windows.Forms.ToolStripButton savebtn;
	private System.Windows.Forms.StatusStrip stat;
	private System.Windows.Forms.ToolStripButton saveasbtn;
}