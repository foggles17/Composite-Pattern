namespace Composite_Pattern
{
    partial class FileBrowser
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
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.openButton = new System.Windows.Forms.Button();
            this.folderTreeView = new System.Windows.Forms.TreeView();
            this.saveButton = new System.Windows.Forms.Button();
            this.newFolderButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(13, 13);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.ReadOnly = true;
            this.filePathTextBox.Size = new System.Drawing.Size(459, 20);
            this.filePathTextBox.TabIndex = 4;
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(94, 261);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(216, 20);
            this.fileNameTextBox.TabIndex = 7;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(397, 259);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 8;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // folderTreeView
            // 
            this.folderTreeView.Location = new System.Drawing.Point(13, 39);
            this.folderTreeView.Name = "folderTreeView";
            this.folderTreeView.Size = new System.Drawing.Size(459, 214);
            this.folderTreeView.TabIndex = 9;
            this.folderTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.folderTreeView_AfterSelect);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(397, 259);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // newFolderButton
            // 
            this.newFolderButton.Location = new System.Drawing.Point(13, 259);
            this.newFolderButton.Name = "newFolderButton";
            this.newFolderButton.Size = new System.Drawing.Size(75, 23);
            this.newFolderButton.TabIndex = 11;
            this.newFolderButton.Text = "New Folder";
            this.newFolderButton.UseVisualStyleBackColor = true;
            this.newFolderButton.Click += new System.EventHandler(this.newFolderButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(316, 259);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 12;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // FileBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 294);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.newFolderButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.folderTreeView);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.filePathTextBox);
            this.MaximumSize = new System.Drawing.Size(500, 333);
            this.MinimumSize = new System.Drawing.Size(500, 333);
            this.Name = "FileBrowser";
            this.Text = "FileBrowser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.TreeView folderTreeView;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button newFolderButton;
        private System.Windows.Forms.Button deleteButton;
    }
}