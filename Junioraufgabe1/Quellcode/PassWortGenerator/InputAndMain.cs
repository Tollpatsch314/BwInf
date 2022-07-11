using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassWortGenerator
{
	public partial class InputAndMain : Form
	{
		public InputAndMain()
		{
			InitializeComponent();
		}

		/// <summary>
		/// If SpecialChar is true then the password contains special characters.
		/// </summary>
		private bool SpecialChar = true;
		/// <summary>
		/// If Number is true then the password contains special characters.
		/// </summary>
		private bool Number = true;
		private ToolStripMenuItem selectedTheme;
		private string[] ThemesAndSource;   // That are the relative Sources of the file, who are syllables
		private int ThemeFile;  // This is the Index for the string array "ThemesAndSource"
		private string Source;


		private void cBoxSpecialChar_CheckedChanged(object sender, EventArgs e)
		{
			SpecialChar = cBoxSpecialChar.Checked;
		}

		private void cBoxNumber_CheckedChanged(object sender, EventArgs e)
		{
			Number = cBoxNumber.Checked;
		}

		private void bntStart_Click(object sender, EventArgs e)
		{

			Output output = new Output(this, SpecialChar, Number, selectedTheme.Name, ThemesAndSource[ThemeFile]);
		}


		private void themaHinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddTheme newTheme = new AddTheme(this, Source);
		}

		private void InputAndMain_Load(object sender, EventArgs e)
		{
			ThemesAndSource = System.IO.Directory.GetFiles("..\\..\\..\\", "*.PassWortGenerator.silb", System.IO.SearchOption.AllDirectories);

			ToolStripItem[] items;
			items = new System.Windows.Forms.ToolStripItem[ThemesAndSource.Length];

			// This filter the actual theme from the path, the actual them will show over "lblTheme".
			for (int i = 0; i < ThemesAndSource.Length; i++)
			{
				string s = ThemesAndSource[i];
				ToolStripItem Item;
				Item = new System.Windows.Forms.ToolStripMenuItem();
				int posOfLastBackslash = 0;
				int posOfPenultimatePoint = 0;
				int posOfLastPoint = 0;
				string name = "";

				for (int j = 0; j < s.Length; j++)
				{
					if (s[j] == '\\')
					{
						posOfLastBackslash = j;
					}
					if (s[j] == '.')
					{
						posOfPenultimatePoint = posOfLastPoint;
						posOfLastPoint = j;
					}
				}

				name = s;
				name = name.Remove(posOfPenultimatePoint, name.Length - posOfPenultimatePoint);
				name = name.Remove(0, posOfLastBackslash + 1);
				Item.Name = name;
				Item.Text = name;
				Item.Click += ItemSelection_Click;
				items[i] = Item;

				// That is the default-theme: pets
				if (name == "Tiere")
				{
					selectedTheme = Item as ToolStripMenuItem;
					selectedTheme.CheckState = System.Windows.Forms.CheckState.Checked;
					selectedTheme.Checked = true;
					lblTheme.Text = "Thema: " + selectedTheme.Text;
					ThemeFile = i;
					Source = ThemesAndSource[ThemeFile];
				}
			}

			themaWählenToolStripMenuItem.DropDownItems.AddRange(items);

		}

		private void ItemSelection_Click(object sender, EventArgs e)
		{
			selectedTheme.CheckState = System.Windows.Forms.CheckState.Unchecked;
			selectedTheme.Checked = false;
			ToolStripMenuItem Item = sender as ToolStripMenuItem;
			selectedTheme = Item;
			Item.CheckState = System.Windows.Forms.CheckState.Checked;
			Item.Checked = true;
			lblTheme.Text = "Thema: " + Item.Text;
		}

		private void versionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Version 1.0.0.0\nEntwickler: Karl Richard Jahn");
		}

		private void hilfeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Hilfe siehe Anhängende Dokumentation.");
		}

		private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}

