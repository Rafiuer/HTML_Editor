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

namespace HTML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string currentFile = null;
        private void fastColoredTextBox1_TextChanging(object sender, FastColoredTextBoxNS.TextChangingEventArgs e)
        {
            webBrowser1.DocumentText = fastColoredTextBox1.Text;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete current code?", "New", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                fastColoredTextBox1.Clear();
                currentFile = null;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete current code?", "Open", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "HTML File|*.html|Any File|*.*";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(op.FileName);
                    currentFile = sr.ReadToEnd();
                    fastColoredTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFile != null)
            {
                StreamWriter sw = new StreamWriter(currentFile);
                sw.Write(fastColoredTextBox1.Text);
                sw.Close();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog op = new SaveFileDialog();
            op.Filter = "HTML File|*.html|Any File|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sr = new StreamWriter(op.FileName);
                currentFile = op.FileName;
                sr.Write(fastColoredTextBox1.Text);
                sr.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete current code And exit ?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowFindDialog();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowReplaceDialog();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Copy();
        }

        private void pestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Redo();
        }
    }
}
