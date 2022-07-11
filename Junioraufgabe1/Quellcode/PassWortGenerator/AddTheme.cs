using System;
using System.IO;
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
	public partial class AddTheme : Form
	{
		private InputAndMain Main;
		private int NumberSyllables = 3;
		string Source;

		public AddTheme(InputAndMain Main, string Source)
		{
			InitializeComponent();
			this.Main = Main;
			this.Main.Visible = false;
			this.Main.ShowInTaskbar = false;
			this.Source = Source;
			this.Show();
		}

		private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
		{

			DialogResult dialogResult = MessageBox.Show("Wollen Sie wirklich das Programm beenden?", "Beenden?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
				Main.Close();

		}

		private void AddTheme_Load(object sender, EventArgs e)
		{
			this.StartPosition = FormStartPosition.CenterScreen;
		}

		private void AddTheme_FormClosing(object sender, FormClosingEventArgs e)
		{
			Main.Visible = true;
			Main.ShowInTaskbar = true;
		}


		private void btnSetNumberSyllables_Click(object sender, EventArgs e)
		{
			if (tBoxNumberSyllables.Text != "0" && tBoxNumberSyllables.Text != "1" && tBoxNumberSyllables.Text != "")
			{
				try
				{
					NumberSyllables = Convert.ToInt32(tBoxNumberSyllables.Text);
					tBoxNumberSyllables.Enabled = false;
					btnSetNumberSyllables.Enabled = false;
				}
				catch
				{
					tBoxNumberSyllables.Text = "3";
					NumberSyllables = 3;
					MessageBox.Show("Die Anzahl der Silben darf kein ein Zeichen wie: \""+tBoxNumberSyllables.Text+"\" sein.");
					return;
				}
			}
			else
			{

				tBoxNumberSyllables.Text = "3";
				NumberSyllables = 3;
				MessageBox.Show("Die Anzahl der Silben darf nicht kleiner als 2 sein.");
				return;
			}

		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Hilfe siehe Dokumentation.");
		}

		private void button2_Click(object sender, EventArgs e)
		{
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (tBoxName.Text != "")
			{

				DialogResult dialogResult = MessageBox.Show("Speicheren als: \"" + tBoxName.Text + "\"?", "Speichern?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dialogResult == DialogResult.Yes)
				{
					{
						int posOfLastBackslash = 0;
						for (int j = 0; j < Source.Length; j++)
						{
							if (Source[j] == '\\')
							{
								posOfLastBackslash = j;
							}
						}

						Source = Source.Remove(posOfLastBackslash + 1, Source.Length - posOfLastBackslash - 1);
					}

					StreamWriter sw = new StreamWriter(Source + tBoxName + ".PassWortGenerator.silb");
					//Pfadangabe funktioniert nicht, den grund konnte ich nicht herausfinden
					sw.WriteLine("__START__" + NumberSyllables, ToString() + ":" + tBoxContent.Lines.Length+"__");

					for (int i = 0; i < tBoxContent.Lines.Length; i++)
						sw.WriteLine(tBoxContent.Lines[i]);

					sw.WriteLine("__END__");
					sw.Close();
				}

			}
		}
	}
}
