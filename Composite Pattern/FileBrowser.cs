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
    public partial class FileBrowser : Form
    {
        private TextEditor subject;
        private Composite root;
        private Component currentPath;
        private bool startNewFile;
        public FileBrowser(TextEditor subject, Composite root, bool open, bool newFile)
        {
            startNewFile = newFile;
            InitializeComponent();
            this.subject = subject;
            this.root = root;
            this.currentPath = root;
            filePathTextBox.Text = currentPath.getPath();
            fileNameTextBox.Text = subject.currentFile.Name;
            if (open)
            {
                openButton.Visible = true;
                saveButton.Visible = false;
                fileNameTextBox.Visible = false;
                newFolderButton.Visible = false;
            }
            else
            {
                openButton.Visible = false;
                saveButton.Visible = true;
                fileNameTextBox.Visible = true;
                newFolderButton.Visible = true;
            }
            this.folderTreeView.Nodes.AddRange(new IdentifiedTreeNode[] { root.createTree() });
            updateTreeNodes();
            if (subject.currentFile != subject.untitled)
            {
                List<Composite> lineage = subject.currentFile.getLineage();
                foreach (Composite i in lineage)
                {
                    int goalID = i.id;
                    ((IdentifiedTreeNode)folderTreeView.Nodes[0]).getNodeWithID(goalID).Expand();
                }
            }
            updateFilePathBox();
        }
        private void updateTreeNodes()
        {
            List<int> expanded = ((IdentifiedTreeNode)folderTreeView.Nodes[0]).getExpandedNodes();
            this.folderTreeView.Nodes.Clear();
            this.folderTreeView.Nodes.AddRange(new IdentifiedTreeNode[] { root.createTree() });
            foreach(int i in expanded)
            {
                if(((IdentifiedTreeNode)folderTreeView.Nodes[0]).getNodeWithID(i) != null)
                    ((IdentifiedTreeNode)folderTreeView.Nodes[0]).getNodeWithID(i).Expand();
            }
        }
        private void updateFilePathBox()
        {
            filePathTextBox.Text = currentPath.getPath();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string fileName = fileNameTextBox.Text;
            if(fileName == "")
            {
                MessageBox.Show("File names must be longer than 0 (zero) characters.");
            }
            else
            {
                if (currentPath is Composite)
                {
                    Component file = ((Composite)currentPath).getChild(fileName);
                    if (file == null)
                    {
                        Leaf newLeaf = new Leaf(fileName, subject.getText());
                        ((Composite)currentPath).add(newLeaf);
                        if (!startNewFile)
                            subject.currentFile = newLeaf;
                        else
                            subject.currentFile = subject.untitled;
                        subject.update();
                        Close();
                    }
                    if (file is Composite)
                    {
                        MessageBox.Show("Two items in the same directory can't have the same name.");
                    }
                    else if (file is Leaf)
                    {
                        DialogResult result = MessageBox.Show("There is already a file with that name. Overwrite it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            ((Leaf)file).Text = subject.getText();
                            Close();
                        }
                    }
                }
                else if(currentPath is Leaf)
                {
                    if (fileName != currentPath.Name && currentPath.Parent.getChild(fileName) != null)
                    {
                        MessageBox.Show("Two items in the same directory can't have the same name.");
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to overwrite this file?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            ((Leaf)currentPath).Text = subject.getText();
                            if (!startNewFile)
                                subject.currentFile = ((Leaf)currentPath);
                            else
                                subject.currentFile = subject.untitled;
                            subject.update();
                            Close();
                        }
                    }
                }
            }
        }

        private void folderTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            System.Windows.Forms.TreeNode select = folderTreeView.SelectedNode;
            int goalID = ((IdentifiedTreeNode)select).getID();
            currentPath = root.getComponentWithID(goalID);
            if (currentPath is Leaf)
            {
                fileNameTextBox.Text = currentPath.Name;
            }
            updateFilePathBox();
        }

        private void newFolderButton_Click(object sender, EventArgs e)
        {
            string fileName = fileNameTextBox.Text;
            if (fileName == "")
            {
                MessageBox.Show("File names must be longer than 0 (zero) characters.");
            }
            else if (currentPath is Composite)
            {
                Component file = ((Composite)currentPath).getChild(fileName);
                if (file == null)
                {
                    Composite newComposite = new Composite(fileName);
                    ((Composite)currentPath).add(newComposite);
                    updateTreeNodes();
                    int goalID = currentPath.id;
                    ((IdentifiedTreeNode)folderTreeView.Nodes[0]).getNodeWithID(goalID).Expand();
                }
                if (file is Composite)
                {
                    MessageBox.Show("Two items in the same directory can't have the same name.");
                }
                else if (file is Leaf)
                {
                    MessageBox.Show("Two items in the same directory can't have the same name.");
                }
            }
            else if (currentPath is Leaf)
            {
                MessageBox.Show("You can't put a folder inside a text file.");
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (currentPath is Composite)
            {
                MessageBox.Show("You can't edit a folder.");
            }
            else if (currentPath is Leaf)
            {
                subject.currentFile = (Leaf)currentPath;
                subject.update();
                Close();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (currentPath != root)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete \"" + currentPath.getPath() + "\"?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Component temp = currentPath;
                    currentPath = currentPath.Parent;
                    ((Composite)currentPath).remove(temp);
                    updateTreeNodes();
                    updateFilePathBox();
                }
            }
            else
            {
                MessageBox.Show("You can't delete the root.");
            }
        }
    }
}
