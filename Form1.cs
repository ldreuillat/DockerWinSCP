using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockerWinSCP
{
    public partial class DockerWinSCP : Form
    {
        string containerId;
        MenuItem myMenuItem = new MenuItem("Explore FileSystem");
        ContextMenu mnu = new ContextMenu();

        public DockerWinSCP()
        {
            InitializeComponent();
            ImageList treeImageList = new ImageList();
            treeImageList.ImageSize = new Size(50, 50);
            treeImageList.Images.Add(System.Drawing.Image.FromFile(@"C:\Users\ldreuillat\Documents\Images\docker-image.png"));
            treeImages.ImageList = treeImageList;

            ImageList treeContainerList = new ImageList();
            treeContainerList.ImageSize = new Size(50, 50);
            treeContainerList.Images.Add(System.Drawing.Image.FromFile(@"C:\Users\ldreuillat\Documents\Images\docker-container.png"));
            treeContainerList.Images.Add(System.Drawing.Image.FromFile(@"C:\Users\ldreuillat\Documents\Images\container-id.png"));
            treeContainerList.Images.Add(System.Drawing.Image.FromFile(@"C:\Users\ldreuillat\Documents\Images\container-cmd.png"));
            treeContainerList.Images.Add(System.Drawing.Image.FromFile(@"C:\Users\ldreuillat\Documents\Images\container-state.png"));
            treeContainerList.Images.Add(System.Drawing.Image.FromFile(@"C:\Users\ldreuillat\Documents\Images\container-clock.png"));
            treeContainerList.Images.Add(System.Drawing.Image.FromFile(@"C:\Users\ldreuillat\Documents\Images\container-network.png"));
            treeContainers.ImageList = treeContainerList;
            treeContainers.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeContainers_NodeMouseClick);

            mnu.MenuItems.Add(myMenuItem);
            myMenuItem.Click += new EventHandler(myMenuItem_Click);
        }

        void myMenuItem_Click(object sender, EventArgs e)
        {            
            FileSystemExplorer fsexplorer = new FileSystemExplorer();
            fsexplorer.Text = "Container : " + containerId;
            fsexplorer.containerId = containerId;
            fsexplorer.ShowDialog(this);
            containerId = "";
        }

        private void DockerWinSCP_Load(object sender, EventArgs e)
        {
            Image[] deserializedImages = DockerRestClient.getImages();
            foreach (Image image in deserializedImages)
            {
                if (image.RepoTags is null)
                {
                    treeImages.Nodes.Add("No Repo tags");
                } else
                {
                    TreeNode node = treeImages.Nodes.Add(image.Id, image.RepoTags[0], 0, 0);
                    node.ToolTipText = "Image " + image.RepoTags[0] + " - " + image.Id;
                }
            }
        }

        private void treeImages_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //
            // Get the selected node.
            //
            TreeNode imageNode = treeImages.SelectedNode;
            //
            // Render message box.
            //
            Container[] containers = DockerRestClient.getContainers(imageNode.Text);
            treeContainers.Nodes.Clear();

            if (containers.Length > 0)
            {
                foreach (Container container in containers)
                {
                    TreeNode containerNode = treeContainers.Nodes.Add(container.Id, container.Names[0], 0, 0);
                    containerNode.Nodes.Add(container.Id, container.Id, 1, 1);
                    containerNode.Nodes.Add(container.Command, container.Command, 2, 2);
                    containerNode.Nodes.Add(container.State, container.State, 3, 3);
                    containerNode.Nodes.Add(container.Status, container.Status, 4, 4);
                    TreeNode networkNode = containerNode.Nodes.Add("Network", "Network", 5, 5);
                    networkNode.Nodes.Add(container.HostConfig.NetworkMode);
                    networkNode.Nodes.Add(container.NetworkSettings.Networks.bridge.Gateway);
                    networkNode.Nodes.Add(container.NetworkSettings.Networks.bridge.IPAddress);
                }
            }
        }

        private void treeContainers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //TreeNode containerNode = treeContainers.SelectedNode;

            //DockerRestClient.createExec(containerNode.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FileSystemExplorer fsexplorer = new FileSystemExplorer();
            //fsexplorer.ShowDialog();
        }

        private void treeContainers_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.Node.Level == 0)
                {
                    containerId = e.Node.Name;
                    mnu.Show(treeContainers, e.Location);
                }
            }
        }
    }
}
