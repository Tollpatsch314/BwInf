namespace PassWortGenerator
{
	partial class Output
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblNameOfPW = new System.Windows.Forms.Label();
			this.btnCopy = new System.Windows.Forms.Button();
			this.tBoxPW = new System.Windows.Forms.RichTextBox();
			this.Regenerate = new System.Windows.Forms.Button();
			this.Close = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lblTheme = new System.Windows.Forms.Label();
			this.lblText1 = new System.Windows.Forms.Label();
			this.lblText2 = new System.Windows.Forms.Label();
			this.lblSpecialChar = new System.Windows.Forms.Label();
			this.lblNumbers = new System.Windows.Forms.Label();
			this.lblText3 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblNameOfPW
			// 
			this.lblNameOfPW.AutoSize = true;
			this.lblNameOfPW.Location = new System.Drawing.Point(27, 115);
			this.lblNameOfPW.Name = "lblNameOfPW";
			this.lblNameOfPW.Size = new System.Drawing.Size(97, 13);
			this.lblNameOfPW.TabIndex = 0;
			this.lblNameOfPW.Text = "Ihr Passwort lautet:";
			// 
			// btnCopy
			// 
			this.btnCopy.Location = new System.Drawing.Point(131, 138);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(182, 23);
			this.btnCopy.TabIndex = 2;
			this.btnCopy.Text = "Passwort kopieren";
			this.btnCopy.UseVisualStyleBackColor = true;
			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
			// 
			// tBoxPW
			// 
			this.tBoxPW.AutoWordSelection = true;
			this.tBoxPW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tBoxPW.Location = new System.Drawing.Point(131, 112);
			this.tBoxPW.Multiline = false;
			this.tBoxPW.Name = "tBoxPW";
			this.tBoxPW.ReadOnly = true;
			this.tBoxPW.Size = new System.Drawing.Size(182, 20);
			this.tBoxPW.TabIndex = 1;
			this.tBoxPW.Text = "Das Passwort";
			this.tBoxPW.WordWrap = false;
			// 
			// Regenerate
			// 
			this.Regenerate.Location = new System.Drawing.Point(12, 219);
			this.Regenerate.Name = "Regenerate";
			this.Regenerate.Size = new System.Drawing.Size(150, 50);
			this.Regenerate.TabIndex = 4;
			this.Regenerate.Text = "mit selben Einstellungen erneut generieren";
			this.Regenerate.UseVisualStyleBackColor = true;
			this.Regenerate.Click += new System.EventHandler(this.Regenerate_Click);
			// 
			// Close
			// 
			this.Close.Location = new System.Drawing.Point(247, 219);
			this.Close.Name = "Close";
			this.Close.Size = new System.Drawing.Size(150, 50);
			this.Close.TabIndex = 5;
			this.Close.Text = "Schließen";
			this.Close.UseVisualStyleBackColor = true;
			this.Close.Click += new System.EventHandler(this.Close_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beendenToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(409, 24);
			this.menuStrip1.TabIndex = 7;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// beendenToolStripMenuItem
			// 
			this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
			this.beendenToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
			this.beendenToolStripMenuItem.Text = "Programm Beenden";
			this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
			// 
			// lblTheme
			// 
			this.lblTheme.AutoSize = true;
			this.lblTheme.Location = new System.Drawing.Point(177, 33);
			this.lblTheme.Margin = new System.Windows.Forms.Padding(5);
			this.lblTheme.Name = "lblTheme";
			this.lblTheme.Size = new System.Drawing.Size(40, 13);
			this.lblTheme.TabIndex = 8;
			this.lblTheme.Text = "Thema";
			// 
			// lblText1
			// 
			this.lblText1.AutoSize = true;
			this.lblText1.Location = new System.Drawing.Point(25, 33);
			this.lblText1.Margin = new System.Windows.Forms.Padding(5);
			this.lblText1.Name = "lblText1";
			this.lblText1.Size = new System.Drawing.Size(46, 13);
			this.lblText1.TabIndex = 9;
			this.lblText1.Text = "Thema: ";
			// 
			// lblText2
			// 
			this.lblText2.AutoSize = true;
			this.lblText2.Location = new System.Drawing.Point(25, 56);
			this.lblText2.Margin = new System.Windows.Forms.Padding(5);
			this.lblText2.Name = "lblText2";
			this.lblText2.Size = new System.Drawing.Size(84, 13);
			this.lblText2.TabIndex = 10;
			this.lblText2.Text = "Sonderzeichen: ";
			// 
			// lblSpecialChar
			// 
			this.lblSpecialChar.AutoSize = true;
			this.lblSpecialChar.Location = new System.Drawing.Point(177, 56);
			this.lblSpecialChar.Margin = new System.Windows.Forms.Padding(5);
			this.lblSpecialChar.Name = "lblSpecialChar";
			this.lblSpecialChar.Size = new System.Drawing.Size(18, 13);
			this.lblSpecialChar.TabIndex = 11;
			this.lblSpecialChar.Text = "Ja";
			// 
			// lblNumbers
			// 
			this.lblNumbers.AutoSize = true;
			this.lblNumbers.Location = new System.Drawing.Point(177, 79);
			this.lblNumbers.Margin = new System.Windows.Forms.Padding(5);
			this.lblNumbers.Name = "lblNumbers";
			this.lblNumbers.Size = new System.Drawing.Size(18, 13);
			this.lblNumbers.TabIndex = 13;
			this.lblNumbers.Text = "Ja";
			// 
			// lblText3
			// 
			this.lblText3.AutoSize = true;
			this.lblText3.Location = new System.Drawing.Point(27, 79);
			this.lblText3.Margin = new System.Windows.Forms.Padding(5);
			this.lblText3.Name = "lblText3";
			this.lblText3.Size = new System.Drawing.Size(46, 13);
			this.lblText3.TabIndex = 12;
			this.lblText3.Text = "Zahlen: ";
			// 
			// Output
			// 
			this.ClientSize = new System.Drawing.Size(409, 281);
			this.Controls.Add(this.lblNumbers);
			this.Controls.Add(this.lblText3);
			this.Controls.Add(this.lblSpecialChar);
			this.Controls.Add(this.lblText2);
			this.Controls.Add(this.lblText1);
			this.Controls.Add(this.lblTheme);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.Close);
			this.Controls.Add(this.Regenerate);
			this.Controls.Add(this.btnCopy);
			this.Controls.Add(this.tBoxPW);
			this.Controls.Add(this.lblNameOfPW);
			this.MinimumSize = new System.Drawing.Size(425, 320);
			this.Name = "Output";
			this.Text = "Dies ist Ihr Passwort:";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Output_FormClosing);
			this.Load += new System.EventHandler(this.PassWortGeneratorAusgabe_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblNameOfPW;
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.RichTextBox tBoxPW;
		private System.Windows.Forms.Button Regenerate;
		private System.Windows.Forms.Button Close;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
		private System.Windows.Forms.Label lblTheme;
		private System.Windows.Forms.Label lblText1;
		private System.Windows.Forms.Label lblText2;
		private System.Windows.Forms.Label lblSpecialChar;
		private System.Windows.Forms.Label lblNumbers;
		private System.Windows.Forms.Label lblText3;
	}
}

