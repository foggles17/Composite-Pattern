using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Composite_Pattern
{
    public partial class TextEditor : Form
    {
        private Composite root;
        public Leaf currentFile;
        public Leaf untitled = new Leaf("Untitled");
        private FileBrowser browser;
        public TextEditor()
        {
            InitializeComponent();
            root = new Composite("root");
            currentFile = untitled;
            editTextBox.Text = currentFile.Text;
        }
        public void update()
        {
            Text = currentFile.Name;
            editTextBox.Text = currentFile.Text;
        }
        public string getText()
        {
            return editTextBox.Text;
        }
        private void openMenuItem_Click(object sender, EventArgs e)
        {
            browser = new FileBrowser(this, root, true, false);
            browser.Show();
            browser.TopMost = true;
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            if(currentFile.Equals(untitled))
            {
                saveAs(false);
            }
            else
            {
                currentFile.Text = editTextBox.Text;
            }
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            saveAs(false);
        }

        private void saveAs(bool newFile)
        {
            browser = new FileBrowser(this, root, false, newFile);
            browser.Show();
            browser.TopMost = true;
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Close without saving?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Close();
            }
            else if (result == DialogResult.No)
            {
                saveAs(false);
            }
        }

        private void newMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to save your current file before opening a new one?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                saveAs(true);
            }
            else if (result == DialogResult.No)
            {
                currentFile = untitled;
                update();
            }
        }

        private void outputCompositeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editTextBox.AppendText("\n" + root.stringify());
        }
    }
}
