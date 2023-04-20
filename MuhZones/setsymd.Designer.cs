/*
 * Created by SharpDevelop.
 * User: Wesley
 * Date: 4/20/2023
 * Time: 6:42 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
partial class setsymd
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
		this.okbtn = new System.Windows.Forms.Button();
		this.symlist = new System.Windows.Forms.ListView();
		this.cancelbtn = new System.Windows.Forms.Button();
		this.SuspendLayout();
		// 
		// okbtn
		// 
		this.okbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.okbtn.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.okbtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.okbtn.Location = new System.Drawing.Point(2, 266);
		this.okbtn.Name = "okbtn";
		this.okbtn.Size = new System.Drawing.Size(37, 23);
		this.okbtn.TabIndex = 0;
		this.okbtn.Text = "OK";
		this.okbtn.UseVisualStyleBackColor = true;
		// 
		// symlist
		// 
		this.symlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
						| System.Windows.Forms.AnchorStyles.Left) 
						| System.Windows.Forms.AnchorStyles.Right)));
		this.symlist.Cursor = System.Windows.Forms.Cursors.Default;
		this.symlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		this.symlist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
		this.symlist.Location = new System.Drawing.Point(2, 4);
		this.symlist.Name = "symlist";
		this.symlist.Size = new System.Drawing.Size(360, 256);
		this.symlist.TabIndex = 2;
		this.symlist.TileSize = new System.Drawing.Size(25, 18);
		this.symlist.UseCompatibleStateImageBehavior = false;
		this.symlist.View = System.Windows.Forms.View.Tile;
		// 
		// cancelbtn
		// 
		this.cancelbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.cancelbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.cancelbtn.Location = new System.Drawing.Point(287, 266);
		this.cancelbtn.Name = "cancelbtn";
		this.cancelbtn.Size = new System.Drawing.Size(75, 23);
		this.cancelbtn.TabIndex = 3;
		this.cancelbtn.Text = "Cancel";
		this.cancelbtn.UseVisualStyleBackColor = true;
		// 
		// setsymd
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.SystemColors.Control;
		this.ClientSize = new System.Drawing.Size(364, 293);
		this.Controls.Add(this.cancelbtn);
		this.Controls.Add(this.symlist);
		this.Controls.Add(this.okbtn);
		this.MaximizeBox = false;
		this.Name = "setsymd";
		this.ShowIcon = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Assign symbols to this glyph";
		this.ResumeLayout(false);
	}
	private System.Windows.Forms.Button cancelbtn;
	private System.Windows.Forms.ListView symlist;
	private System.Windows.Forms.Button okbtn;
}
