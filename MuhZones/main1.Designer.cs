namespace MuhZones
{
	partial class main1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main1));
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.toolNew = new System.Windows.Forms.ToolStripButton();
			this.toolOpen = new System.Windows.Forms.ToolStripButton();
			this.saveDiag = new System.Windows.Forms.SaveFileDialog();
			this.openDiag = new System.Windows.Forms.OpenFileDialog();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolNew,
			this.toolOpen});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(193, 25);
			this.toolStrip.TabIndex = 1;
			// 
			// toolNew
			// 
			this.toolNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolNew.Image = ((System.Drawing.Image)(resources.GetObject("toolNew.Image")));
			this.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolNew.Name = "toolNew";
			this.toolNew.Size = new System.Drawing.Size(23, 22);
			this.toolNew.ToolTipText = "New Theme (copy default template)";
			this.toolNew.Click += new System.EventHandler(this.gettemplate);
			// 
			// toolOpen
			// 
			this.toolOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolOpen.Image")));
			this.toolOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolOpen.Name = "toolOpen";
			this.toolOpen.Size = new System.Drawing.Size(23, 22);
			this.toolOpen.ToolTipText = "Open Theme";
			this.toolOpen.Click += new System.EventHandler(this.openz);
			// 
			// saveDiag
			// 
			this.saveDiag.AddExtension = false;
			this.saveDiag.Filter = "Zones (global PAB+PAK)|*.pak.xen;*.pab.xen";
			this.saveDiag.RestoreDirectory = true;
			this.saveDiag.Title = "Save Zones";
			// 
			// openDiag
			// 
			this.openDiag.Filter = "Zones (global PAB+PAK)|*.pak.xen;*.pab.xen";
			this.openDiag.RestoreDirectory = true;
			this.openDiag.Title = "Open Zones";
			// 
			// main1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(193, 25);
			this.Controls.Add(this.toolStrip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "main1";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MuhZones";
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton toolNew;
		private System.Windows.Forms.ToolStripButton toolOpen;
		private System.Windows.Forms.SaveFileDialog saveDiag;
		private System.Windows.Forms.OpenFileDialog openDiag;
	}
}

