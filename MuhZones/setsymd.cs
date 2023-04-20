/*
 * Created by SharpDevelop.
 * User: Wesley
 * Date: 4/20/2023
 * Time: 6:42 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// Description of setsymd.
/// </summary>
public partial class setsymd : Form
{
	public bool[] checked_symbols;
	public setsymd()
	{
		checked_symbols = new bool[0x10000];
		InitializeComponent();
		symlist.SuspendLayout();
		//const int start = 32, end = 0x200;
		//ListViewItem[] lis = new ListViewItem[end-start];
		for (int i = 32; i < 0x200; i++)
		{
			//ListViewItem li = new ListViewItem(new string((char)i, 1));
			//li.Tag = i;
			//symlist.Items.Add(li);
			symlist.Items.Add(((char)i).ToString());
			//lis[i-start] = new ListViewItem(((char)i).ToString());
		}
		//symlist.Items.AddRange(lis);
		symlist.ResumeLayout(false);
	}
}
