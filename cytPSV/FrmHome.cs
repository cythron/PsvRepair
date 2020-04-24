using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cytPSV.Pluralsight.Domain;
using Pluralsight.Domain;

namespace cytPSV
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        public static RichTextBox myConsole = new RichTextBox();
        public static bool isResizeLocked = true;
        public static bool deleteFileAfterProcessing;


        private void FrmHome_Load(object sender, EventArgs e)
        {
            deleteFileAfterProcessing = OptDeleteAfterProcessing.Checked;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            console.BackColor = Color.FromArgb(220, 220, 220);
            myConsole.Size = console.Size;
            myConsole.Font = console.Font;
            myConsole.Location = console.Location;
            myConsole.BackColor = Color.White;
            myConsole.BorderStyle = console.BorderStyle;
            myConsole.Cursor = Cursors.Default;
            myConsole.ForeColor = console.ForeColor;
            //myConsole.ReadOnly = true;
            myConsole.AcceptsTab = true;
            Controls.Add(myConsole);
            console.Dispose();

            Menu.BackColor = Color.FromArgb(240, 240, 240);
            //console.BackColor = Color.FromArgb(240, 240, 240);
            BackColor = Color.FromArgb(40, 40, 40);
            this.Text = " cytPSV";
            MainMenu.ForeColor = Color.FromKnownColor(KnownColor.InfoText);
            MainMenu.AllowDrop = true;
            this.Focus();

            cytPSV.Terminal.Term.Display("Version 1.1a\n");
        }

        private void OptDamagedPSV_Click(object sender, EventArgs e)
        {
            Video.OpenPsv();
        }
        
        private void OptExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void checkIfResizeLocked(object sender, EventArgs e)
        {
            if (isResizeLocked)
            {
                Terminal.Term.Display("Resize is Locked");
                Terminal.Term.Display("\nYou can toggle resizing from the options\n\n");
            }
        }

        private void enableLockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isResizeLocked = !isResizeLocked;
            enableLockToolStripMenuItem.Checked = !enableLockToolStripMenuItem.Checked;
            MaximizeBox = !MaximizeBox;
            MaximumSize = new Size(9999,9999);
        }

        private void OptSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveLog = new SaveFileDialog();
            if (saveLog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveLog.FileName, FileMode.OpenOrCreate);
                BinaryWriter writer = new BinaryWriter(fs);

                writer.Write(console.Text);
                writer.Close();
            }
        }

        private void OptDeleteAfterProcessing_Click(object sender, EventArgs e)
        {
            OptDeleteAfterProcessing.Checked = !OptDeleteAfterProcessing.Checked;
            deleteFileAfterProcessing = !deleteFileAfterProcessing;
        }

        private void clearConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myConsole.Clear();
        }
    }
}
