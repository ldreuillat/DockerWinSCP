namespace DockerWinSCP
{
    partial class DockerWinSCP
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockerWinSCP));
            this.treeImages = new System.Windows.Forms.TreeView();
            this.ImagesLabel = new System.Windows.Forms.Label();
            this.treeContainers = new System.Windows.Forms.TreeView();
            this.ContainersLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeImages
            // 
            this.treeImages.Location = new System.Drawing.Point(12, 30);
            this.treeImages.Name = "treeImages";
            this.treeImages.ShowNodeToolTips = true;
            this.treeImages.Size = new System.Drawing.Size(285, 408);
            this.treeImages.TabIndex = 0;
            this.treeImages.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeImages_MouseDoubleClick);
            // 
            // ImagesLabel
            // 
            this.ImagesLabel.AutoSize = true;
            this.ImagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImagesLabel.Location = new System.Drawing.Point(12, 9);
            this.ImagesLabel.Name = "ImagesLabel";
            this.ImagesLabel.Size = new System.Drawing.Size(47, 13);
            this.ImagesLabel.TabIndex = 1;
            this.ImagesLabel.Text = "Images";
            // 
            // treeContainers
            // 
            this.treeContainers.Location = new System.Drawing.Point(335, 30);
            this.treeContainers.Name = "treeContainers";
            this.treeContainers.ShowNodeToolTips = true;
            this.treeContainers.Size = new System.Drawing.Size(678, 408);
            this.treeContainers.TabIndex = 2;
            this.treeContainers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeContainers_AfterSelect);
            // 
            // ContainersLabel
            // 
            this.ContainersLabel.AutoSize = true;
            this.ContainersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContainersLabel.Location = new System.Drawing.Point(332, 9);
            this.ContainersLabel.Name = "ContainersLabel";
            this.ContainersLabel.Size = new System.Drawing.Size(67, 13);
            this.ContainersLabel.TabIndex = 3;
            this.ContainersLabel.Text = "Containers";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(583, 458);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DockerWinSCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 515);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ContainersLabel);
            this.Controls.Add(this.treeContainers);
            this.Controls.Add(this.ImagesLabel);
            this.Controls.Add(this.treeImages);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DockerWinSCP";
            this.Text = "DockerWinSCP";
            this.Load += new System.EventHandler(this.DockerWinSCP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeImages;
        private System.Windows.Forms.Label ImagesLabel;
        private System.Windows.Forms.TreeView treeContainers;
        private System.Windows.Forms.Label ContainersLabel;
        private System.Windows.Forms.Button button1;
    }
}

