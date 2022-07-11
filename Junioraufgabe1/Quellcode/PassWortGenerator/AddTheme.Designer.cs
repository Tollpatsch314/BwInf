namespace PassWortGenerator
{
	partial class AddTheme
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tBoxNumberSyllables = new System.Windows.Forms.TextBox();
			this.lblText1 = new System.Windows.Forms.Label();
			this.btnSetNumberSyllables = new System.Windows.Forms.Button();
			this.tBoxContent = new System.Windows.Forms.TextBox();
			this.btnHelp = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.lblText2 = new System.Windows.Forms.Label();
			this.tBoxName = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beendenToolStripMenuItem,
            this.toolStripMenuItem1});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(752, 24);
			this.menuStrip1.TabIndex = 8;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// beendenToolStripMenuItem
			// 
			this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
			this.beendenToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
			this.beendenToolStripMenuItem.Text = "Programm Beenden";
			this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripMenuItem,
            this.hilfeToolStripMenuItem});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
			this.toolStripMenuItem1.Text = "?";
			// 
			// versionToolStripMenuItem
			// 
			this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
			this.versionToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.versionToolStripMenuItem.Text = "Version/Autor";
			// 
			// hilfeToolStripMenuItem
			// 
			this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
			this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.hilfeToolStripMenuItem.Text = "Hilfe";
			// 
			// tBoxNumberSyllables
			// 
			this.tBoxNumberSyllables.Location = new System.Drawing.Point(114, 45);
			this.tBoxNumberSyllables.Name = "tBoxNumberSyllables";
			this.tBoxNumberSyllables.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tBoxNumberSyllables.Size = new System.Drawing.Size(60, 20);
			this.tBoxNumberSyllables.TabIndex = 9;
			this.tBoxNumberSyllables.Text = "3";
			// 
			// lblText1
			// 
			this.lblText1.AutoSize = true;
			this.lblText1.Location = new System.Drawing.Point(34, 48);
			this.lblText1.Name = "lblText1";
			this.lblText1.Size = new System.Drawing.Size(74, 13);
			this.lblText1.TabIndex = 10;
			this.lblText1.Text = "Anzahl Silben:";
			// 
			// btnSetNumberSyllables
			// 
			this.btnSetNumberSyllables.Location = new System.Drawing.Point(180, 43);
			this.btnSetNumberSyllables.Name = "btnSetNumberSyllables";
			this.btnSetNumberSyllables.Size = new System.Drawing.Size(75, 23);
			this.btnSetNumberSyllables.TabIndex = 11;
			this.btnSetNumberSyllables.Text = "Festlegen";
			this.btnSetNumberSyllables.UseVisualStyleBackColor = true;
			this.btnSetNumberSyllables.Click += new System.EventHandler(this.btnSetNumberSyllables_Click);
			// 
			// tBoxContent
			// 
			this.tBoxContent.Location = new System.Drawing.Point(37, 73);
			this.tBoxContent.Multiline = true;
			this.tBoxContent.Name = "tBoxContent";
			this.tBoxContent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.tBoxContent.Size = new System.Drawing.Size(626, 407);
			this.tBoxContent.TabIndex = 12;
			// 
			// btnHelp
			// 
			this.btnHelp.Location = new System.Drawing.Point(588, 44);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(75, 23);
			this.btnHelp.TabIndex = 13;
			this.btnHelp.Text = "Hilfe";
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(648, 552);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(92, 37);
			this.button1.TabIndex = 14;
			this.button1.Text = "Speichern";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(464, 44);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 17;
			this.button2.Text = "Festlegen";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// lblText2
			// 
			this.lblText2.AutoSize = true;
			this.lblText2.Location = new System.Drawing.Point(281, 49);
			this.lblText2.Name = "lblText2";
			this.lblText2.Size = new System.Drawing.Size(38, 13);
			this.lblText2.TabIndex = 16;
			this.lblText2.Text = "Name:";
			// 
			// tBoxName
			// 
			this.tBoxName.Location = new System.Drawing.Point(325, 45);
			this.tBoxName.Name = "tBoxName";
			this.tBoxName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tBoxName.Size = new System.Drawing.Size(133, 20);
			this.tBoxName.TabIndex = 15;
			// 
			// AddTheme
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(752, 601);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.lblText2);
			this.Controls.Add(this.tBoxName);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.tBoxContent);
			this.Controls.Add(this.btnSetNumberSyllables);
			this.Controls.Add(this.lblText1);
			this.Controls.Add(this.tBoxNumberSyllables);
			this.Controls.Add(this.menuStrip1);
			this.MinimumSize = new System.Drawing.Size(425, 320);
			this.Name = "AddTheme";
			this.Text = "PasswortGenerator";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddTheme_FormClosing);
			this.Load += new System.EventHandler(this.AddTheme_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}


		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
		private System.Windows.Forms.TextBox tBoxNumberSyllables;
		private System.Windows.Forms.Label lblText1;
		private System.Windows.Forms.Button btnSetNumberSyllables;
		private System.Windows.Forms.TextBox tBoxContent;
		private System.Windows.Forms.Button btnHelp;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label lblText2;
		private System.Windows.Forms.TextBox tBoxName;
	}
}