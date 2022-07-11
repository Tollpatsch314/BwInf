namespace PassWortGenerator
{
	partial class InputAndMain
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
			this.bntStart = new System.Windows.Forms.Button();
			this.cBoxSpecialChar = new System.Windows.Forms.CheckBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.themaWählenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lblTheme = new System.Windows.Forms.Label();
			this.cBoxNumber = new System.Windows.Forms.CheckBox();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// bntStart
			// 
			this.bntStart.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bntStart.Location = new System.Drawing.Point(48, 202);
			this.bntStart.Name = "bntStart";
			this.bntStart.Size = new System.Drawing.Size(300, 50);
			this.bntStart.TabIndex = 0;
			this.bntStart.Text = "Jetzt Passwort generieren!";
			this.bntStart.UseVisualStyleBackColor = true;
			this.bntStart.Click += new System.EventHandler(this.bntStart_Click);
			// 
			// cBoxSpecialChar
			// 
			this.cBoxSpecialChar.AutoSize = true;
			this.cBoxSpecialChar.Checked = true;
			this.cBoxSpecialChar.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cBoxSpecialChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cBoxSpecialChar.Location = new System.Drawing.Point(48, 144);
			this.cBoxSpecialChar.Name = "cBoxSpecialChar";
			this.cBoxSpecialChar.Size = new System.Drawing.Size(117, 20);
			this.cBoxSpecialChar.TabIndex = 5;
			this.cBoxSpecialChar.Text = "Sonderzeichen";
			this.cBoxSpecialChar.UseVisualStyleBackColor = true;
			this.cBoxSpecialChar.CheckedChanged += new System.EventHandler(this.cBoxSpecialChar_CheckedChanged);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themaWählenToolStripMenuItem,
            this.beendenToolStripMenuItem,
            this.toolStripMenuItem1});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(409, 24);
			this.menuStrip1.TabIndex = 6;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// themaWählenToolStripMenuItem
			// 
			this.themaWählenToolStripMenuItem.Name = "themaWählenToolStripMenuItem";
			this.themaWählenToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
			this.themaWählenToolStripMenuItem.Text = "Thema wählen";
			// 
			// beendenToolStripMenuItem
			// 
			this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
			this.beendenToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.beendenToolStripMenuItem.Text = "Beenden";
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
			this.versionToolStripMenuItem.Click += new System.EventHandler(this.versionToolStripMenuItem_Click);
			// 
			// hilfeToolStripMenuItem
			// 
			this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
			this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.hilfeToolStripMenuItem.Text = "Hilfe";
			this.hilfeToolStripMenuItem.Click += new System.EventHandler(this.hilfeToolStripMenuItem_Click);
			// 
			// lblTheme
			// 
			this.lblTheme.AutoSize = true;
			this.lblTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTheme.Location = new System.Drawing.Point(45, 58);
			this.lblTheme.Name = "lblTheme";
			this.lblTheme.Size = new System.Drawing.Size(87, 24);
			this.lblTheme.TabIndex = 7;
			this.lblTheme.Text = "Thema: ";
			// 
			// cBoxNumber
			// 
			this.cBoxNumber.AutoSize = true;
			this.cBoxNumber.Checked = true;
			this.cBoxNumber.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cBoxNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cBoxNumber.Location = new System.Drawing.Point(295, 144);
			this.cBoxNumber.Name = "cBoxNumber";
			this.cBoxNumber.Size = new System.Drawing.Size(53, 20);
			this.cBoxNumber.TabIndex = 8;
			this.cBoxNumber.Text = "Zahl";
			this.cBoxNumber.UseVisualStyleBackColor = true;
			this.cBoxNumber.CheckedChanged += new System.EventHandler(this.cBoxNumber_CheckedChanged);
			// 
			// InputAndMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(409, 281);
			this.Controls.Add(this.cBoxNumber);
			this.Controls.Add(this.lblTheme);
			this.Controls.Add(this.cBoxSpecialChar);
			this.Controls.Add(this.bntStart);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(425, 320);
			this.Name = "InputAndMain";
			this.Text = "PasswortGenerator";
			this.Load += new System.EventHandler(this.InputAndMain_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button bntStart;
		private System.Windows.Forms.CheckBox cBoxSpecialChar;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem themaWählenToolStripMenuItem;
		private System.Windows.Forms.Label lblTheme;
		private System.Windows.Forms.CheckBox cBoxNumber;
	}
}

