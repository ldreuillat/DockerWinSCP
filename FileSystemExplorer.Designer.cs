using System;

namespace DockerWinSCP
{
    partial class FileSystemExplorer
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
            this.localTreeView = new System.Windows.Forms.TreeView();
            this.containerTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // localTreeView
            // 
            this.localTreeView.Location = new System.Drawing.Point(12, 12);
            this.localTreeView.Name = "localTreeView";
            this.localTreeView.Size = new System.Drawing.Size(443, 395);
            this.localTreeView.TabIndex = 0;
            this.localTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.localTreeView_AfterSelect);
            this.localTreeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.localTreeView_MouseDoubleClick);
            this.localTreeView.DragEnter += localTreeView_DragEnter;
            this.localTreeView.DragDrop += localTreeView_DragDrop;
            this.localTreeView.ItemDrag += localTreeView_ItemDrag;
            // 
            // containerTreeView
            // 
            this.containerTreeView.Location = new System.Drawing.Point(541, 12);
            this.containerTreeView.Name = "containerTreeView";
            this.containerTreeView.Size = new System.Drawing.Size(443, 395);
            this.containerTreeView.TabIndex = 1;
            // 
            // FileSystemExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 450);
            this.Controls.Add(this.containerTreeView);
            this.Controls.Add(this.localTreeView);
            this.Name = "FileSystemExplorer";
            this.Text = "FileSystemExplorer";
            this.Load += new System.EventHandler(this.FileSystemExplorer_Load);
            this.ResumeLayout(false);

        }

        private void FileSystemExplorer_Load(object sender, EventArgs e)
        {
        }

        #endregion

        private System.Windows.Forms.TreeView localTreeView;
        private System.Windows.Forms.TreeView containerTreeView;
    }
}