using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DockerWinSCP
{
    /**
     * Form used to display local and container File System and to allow copy between each other
     **/
    public partial class FileSystemExplorer : Form
    {
        public string containerId;

        public FileSystemExplorer()
        {
            InitializeComponent();
            ImageList treeImageList = new ImageList();
            treeImageList.ImageSize = new Size(24, 24);
            treeImageList.Images.Add(System.Drawing.Image.FromFile(@"C:\Users\ldreuillat\Documents\Images\fs-folder.png"));
            treeImageList.Images.Add(System.Drawing.Image.FromFile(@"C:\Users\ldreuillat\Documents\Images\fs-file.png"));
            localTreeView.ImageList = treeImageList;

            localTreeView.BeginUpdate();
            TreeNode node = new TreeNode();
            node.Text = @"C:\";
            node.Name = @"C:\";
            localTreeView.Nodes.Add(node);
            localTreeView.AllowDrop = true;

            containerTreeView.BeginUpdate();
            TreeNode rootNode = new TreeNode();
            rootNode.Text = @"/";
            rootNode.Name = @"/";
            containerTreeView.Nodes.Add(rootNode);
            containerTreeView.ImageList = treeImageList;
            containerTreeView.MouseDoubleClick += new MouseEventHandler(containerTreeView_MouseDoubleClick);
        }

        void LoadFoldersInTreeView(TreeView treeName, TreeNode node)
        {
            if (Directory.Exists(node.Name))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(node.Name);
                GetFolders(dirInfo, node);
                treeName.ExpandAll();
            }
        }

        void LoadFoldersInContainerView(TreeView treeName, TreeNode node)
        {
            string content = DockerRestClient.getDirectoryListing(containerId, node.Name);
            TreeNode treeNode = node.Nodes.Add("/var", "var", 0, 0);
            treeName.ExpandAll();
            /*if (Directory.Exists(node.Name))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(node.Name);
                GetFolders(dirInfo, node);
                treeName.ExpandAll();
            }*/
        }

        void GetFolders(DirectoryInfo d, TreeNode node)
        {
            try
            {
                DirectoryInfo[] dInfo = d.GetDirectories();

                if (dInfo.Length > 0)
                {
                    TreeNode treeNode = new TreeNode();

                    foreach (DirectoryInfo driSub in dInfo)
                    {
                        // Create directory node only if not already available
                        TreeNode[] availableNodes = node.Nodes.Find(driSub.FullName, false);
                        if (availableNodes.Length == 0)
                        {
                            treeNode = node.Nodes.Add(driSub.FullName, driSub.Name, 0, 0);
                            treeNode.Expand();
                        }
                    }
                }

                FileInfo[] fInfo = d.GetFiles();
                if (fInfo.Length > 0)
                {
                    TreeNode treeNode = new TreeNode();

                    foreach (FileInfo fileSub in fInfo)
                    {
                        // Create directory node only if not already available
                        TreeNode[] availableNodes = node.Nodes.Find(fileSub.FullName, false);
                        if (availableNodes.Length == 0)
                        {
                            treeNode = node.Nodes.Add(fileSub.FullName, fileSub.Name, 1, 1);
                        }
                    }
                }
            }
            catch { }
        }

        private void localTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode directoryNode = localTreeView.SelectedNode;

            LoadFoldersInTreeView(localTreeView, directoryNode);
        }

        private void containerTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode directoryNode = containerTreeView.SelectedNode;

            LoadFoldersInContainerView(containerTreeView, directoryNode);
        }

        private void localTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void localTreeView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void localTreeView_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode SourceNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");

            Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));

            TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);

            DestinationNode.Nodes.Add(SourceNode.Name, SourceNode.Text);
        }

        private void localTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Copy);
        }

        private void containerTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}

