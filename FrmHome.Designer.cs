namespace cytPSV
{
    partial class FrmHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHome));
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.MainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptDamagedPSV = new System.Windows.Forms.ToolStripMenuItem();
            this.OptSave = new System.Windows.Forms.ToolStripMenuItem();
            this.enableLockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptDeleteAfterProcessing = new System.Windows.Forms.ToolStripMenuItem();
            this.clearConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptExit = new System.Windows.Forms.ToolStripMenuItem();
            this.console = new System.Windows.Forms.RichTextBox();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Menu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Menu.GripMargin = new System.Windows.Forms.Padding(2);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenu});
            this.Menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.Menu.Size = new System.Drawing.Size(781, 47);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "menu";
            // 
            // MainMenu
            // 
            this.MainMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.OptSave,
            this.enableLockToolStripMenuItem,
            this.OptDeleteAfterProcessing,
            this.clearConsoleToolStripMenuItem,
            this.OptExit});
            this.MainMenu.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(73, 24);
            this.MainMenu.Text = "&Options";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptDamagedPSV});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(282, 24);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // OptDamagedPSV
            // 
            this.OptDamagedPSV.Name = "OptDamagedPSV";
            this.OptDamagedPSV.ShortcutKeyDisplayString = "    Ctrl + O";
            this.OptDamagedPSV.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OptDamagedPSV.Size = new System.Drawing.Size(338, 24);
            this.OptDamagedPSV.Text = "&Encrypted or Damaged PSV";
            this.OptDamagedPSV.Click += new System.EventHandler(this.OptDamagedPSV_Click);
            // 
            // OptSave
            // 
            this.OptSave.Name = "OptSave";
            this.OptSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.OptSave.Size = new System.Drawing.Size(282, 24);
            this.OptSave.Text = "&Save Log";
            this.OptSave.Click += new System.EventHandler(this.OptSave_Click);
            // 
            // enableLockToolStripMenuItem
            // 
            this.enableLockToolStripMenuItem.Name = "enableLockToolStripMenuItem";
            this.enableLockToolStripMenuItem.ShortcutKeyDisplayString = "       Alt + R";
            this.enableLockToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.enableLockToolStripMenuItem.Size = new System.Drawing.Size(282, 24);
            this.enableLockToolStripMenuItem.Text = "Enable &Resizing";
            this.enableLockToolStripMenuItem.Click += new System.EventHandler(this.enableLockToolStripMenuItem_Click);
            // 
            // OptDeleteAfterProcessing
            // 
            this.OptDeleteAfterProcessing.Name = "OptDeleteAfterProcessing";
            this.OptDeleteAfterProcessing.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.OptDeleteAfterProcessing.Size = new System.Drawing.Size(282, 24);
            this.OptDeleteAfterProcessing.Text = "Delete After Processing";
            this.OptDeleteAfterProcessing.Click += new System.EventHandler(this.OptDeleteAfterProcessing_Click);
            // 
            // clearConsoleToolStripMenuItem
            // 
            this.clearConsoleToolStripMenuItem.Name = "clearConsoleToolStripMenuItem";
            this.clearConsoleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.clearConsoleToolStripMenuItem.Size = new System.Drawing.Size(282, 24);
            this.clearConsoleToolStripMenuItem.Text = "C&lear Console";
            this.clearConsoleToolStripMenuItem.Click += new System.EventHandler(this.clearConsoleToolStripMenuItem_Click);
            // 
            // OptExit
            // 
            this.OptExit.Name = "OptExit";
            this.OptExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.OptExit.Size = new System.Drawing.Size(282, 24);
            this.OptExit.Text = "E&xit";
            this.OptExit.Click += new System.EventHandler(this.OptExit_Click);
            // 
            // console
            // 
            this.console.BackColor = System.Drawing.SystemColors.HighlightText;
            this.console.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.console.Cursor = System.Windows.Forms.Cursors.Default;
            this.console.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console.Location = new System.Drawing.Point(2, 31);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(778, 411);
            this.console.TabIndex = 1;
            this.console.Text = "Terminal.Term.Display($\"Processing: {currentPsvName}\\n\\n\");";
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(781, 443);
            this.Controls.Add(this.console);
            this.Controls.Add(this.Menu);
            this.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Menu;
            this.Name = "FrmHome";
            this.Opacity = 0.99D;
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "cytPSV";
            this.Load += new System.EventHandler(this.FrmHome_Load);
            this.Resize += new System.EventHandler(this.checkIfResizeLocked);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem MainMenu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptDamagedPSV;
        private System.Windows.Forms.ToolStripMenuItem OptDeleteAfterProcessing;
        private System.Windows.Forms.ToolStripMenuItem OptSave;
        private System.Windows.Forms.ToolStripMenuItem OptExit;
        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.ToolStripMenuItem enableLockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearConsoleToolStripMenuItem;
    }
}

