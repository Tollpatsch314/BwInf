using System;
using System.IO;	// That's for the reading of the *.PassWorGenerator.silb - file 
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
	public partial class Output : Form
	{

		private InputAndMain Main;
		private bool SpecialChar, Number;
		private string ThemeFile;
		private int PieceSyllables;



		/// <summary>
		/// Überprüft ob der gegebene Char eine Ziffer ist 
		/// </summary>
		private bool IsDigit(char c)
		{
			if (c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9')
				return true;
			else
				return false;
		}


		public Output(InputAndMain Main, bool SpecialChar, bool Number, string Theme, string ThemeFile)
		{
			this.ThemeFile = ThemeFile;
			this.Main = Main;
			this.SpecialChar = SpecialChar;
			this.Number = Number;
			InitializeComponent();
			Main.ShowInTaskbar = false;
			Main.Visible = false;
			lblTheme.Text = Theme;
			lblSpecialChar.Text = this.SpecialChar == true ? "Ja" : "Nein";
			lblNumbers.Text = this.Number == true ? "Ja" : "Nein";
			this.Show();
		}

		private void PassWortGeneratorAusgabe_Load(object sender, EventArgs e)
		{
			this.Location = Main.Location;
			generatePassWord();
		}

		private void Output_FormClosing(object sender, FormClosingEventArgs e)
		{
			Main.ShowInTaskbar = true;
			Main.Visible = true;
		}

		private void generatePassWord()
		{
			StreamReader reader = new StreamReader(ThemeFile);
			Random r = new Random();
			tBoxPW.Text = "";
			string head = reader.ReadLine();
			head = head.Remove(0, 9);
			string partPieceSyllables = "";
			for (int i = 0; i < head.Length; i++)
			{
				if (head[i] != ':')
				{
					partPieceSyllables += head[i];
				}
				else
				{
					try
					{
						PieceSyllables = Convert.ToInt32(partPieceSyllables);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message.ToString());
					}
					break;
				}
			}

			head = head.Remove(0, partPieceSyllables.Length + 1);
			partPieceSyllables = "";
			int Lines = 0;
			for (int i = 0; i < head.Length; i++)
			{
				if (head[i] != '_')
				{
					partPieceSyllables += head[i];
				}
				else
				{
					try
					{
						Lines = Convert.ToInt32(partPieceSyllables);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message.ToString());
					}
					break;
				}
			}

			string[] Syllables = new string[Lines];
			//string[] parts

			for (int i = 0; i < Lines; i++)
			{
				string s = reader.ReadLine();
				if(s != "__END__")
				Syllables[i] = s;
			}


			for (int i = 0; i < PieceSyllables; i++)    // all syllables are passed through
			{
				for (int j = 0; j < Syllables.Length; j++)  // all entries are passed through
				{
					int l = 0;
					for (int k = 0; k < Syllables[j].Length; k++)
					{
						if (IsDigit(Syllables[j][k]) || Syllables[j][k] == '_')
							l++;
						else break;
					}

					Syllables[j] = Syllables[j].Remove(0, l+1);
				}

				int rand = r.Next(0, Syllables.Length);

				for (int j = 0; j < Syllables[rand].Length; j++)
				{
					if (Syllables[rand][j] != '\"')
						tBoxPW.Text += Syllables[rand][j];  // The TextBox get the Syllable assigned
					else break;
				}
				for (int j = 0; j < Syllables.Length; j++)
				{
					int l = 0;
					for (int k = 0; k < Syllables[j].Length; k++)
					{
						if (Syllables[j][k] != '\"')
							l++;
						else break;
					}
					Syllables[j] = Syllables[j].Remove(0, l + 1);

				}
			}

			if (SpecialChar)
			{
				char[] SpecialChars = { '!', '_', '#', '§', '%', '=', '=', '^', '°', '$', '<', '>', '@', '€', '~', '&', '|', '²', '³' };

				if(r.Next(0, 2) == 1)
				{
					string s = tBoxPW.Text;
					tBoxPW.Text = SpecialChars[r.Next(0, SpecialChars.Length)] + s;
				}
				else
				{
					tBoxPW.Text += SpecialChars[r.Next(0, SpecialChars.Length)];
				}
			}

			if(Number)
			tBoxPW.Text += r.Next(0, 100);
		}

		private void Close_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(tBoxPW.Text);
		}

		private void Regenerate_Click(object sender, EventArgs e)
		{
			generatePassWord();
		}

		private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Wollen Sie wirklich das Programm beenden?", "Beenden?",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
				Main.Close();
		}
	}
}
