
namespace Browser
{
    partial class BrowserMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserMain));
            this.toolbarBackground = new System.Windows.Forms.Panel();
            this.buttonSettings = new System.Windows.Forms.PictureBox();
            this.buttonBookmark = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddressBar = new System.Windows.Forms.TextBox();
            this.urlBoxRight = new System.Windows.Forms.PictureBox();
            this.urlBoxLeft = new System.Windows.Forms.PictureBox();
            this.buttonForward = new System.Windows.Forms.PictureBox();
            this.buttonBack = new System.Windows.Forms.PictureBox();
            this.openInANewTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BookmarksView = new System.Windows.Forms.TreeView();
            this.toolbarBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonBookmark)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.urlBoxRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.urlBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonForward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonBack)).BeginInit();
            this.SuspendLayout();
            // 
            // toolbarBackground
            // 
            this.toolbarBackground.Controls.Add(this.buttonSettings);
            this.toolbarBackground.Controls.Add(this.buttonBookmark);
            this.toolbarBackground.Controls.Add(this.panel1);
            this.toolbarBackground.Controls.Add(this.buttonForward);
            this.toolbarBackground.Controls.Add(this.buttonBack);
            this.toolbarBackground.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarBackground.Location = new System.Drawing.Point(0, 0);
            this.toolbarBackground.Name = "toolbarBackground";
            this.toolbarBackground.Size = new System.Drawing.Size(326, 38);
            this.toolbarBackground.TabIndex = 3;
            // 
            // buttonSettings
            // 
            this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSettings.BackColor = System.Drawing.Color.Transparent;
            this.buttonSettings.Image = global::Browser.Properties.Resources.ToolsActive;
            this.buttonSettings.Location = new System.Drawing.Point(289, 6);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(4, 4, 3, 3);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(28, 28);
            this.buttonSettings.TabIndex = 10;
            this.buttonSettings.TabStop = false;
            this.buttonSettings.MouseEnter += new System.EventHandler(this.buttonSettings_MouseEnter);
            this.buttonSettings.MouseLeave += new System.EventHandler(this.buttonSettings_MouseLeave);
            // 
            // buttonBookmark
            // 
            this.buttonBookmark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBookmark.BackColor = System.Drawing.Color.Transparent;
            this.buttonBookmark.Image = global::Browser.Properties.Resources.BookmarksActive;
            this.buttonBookmark.Location = new System.Drawing.Point(254, 6);
            this.buttonBookmark.Margin = new System.Windows.Forms.Padding(4, 4, 3, 3);
            this.buttonBookmark.Name = "buttonBookmark";
            this.buttonBookmark.Size = new System.Drawing.Size(28, 28);
            this.buttonBookmark.TabIndex = 9;
            this.buttonBookmark.TabStop = false;
            this.buttonBookmark.Click += new System.EventHandler(this.buttonBookmark_Click);
            this.buttonBookmark.MouseEnter += new System.EventHandler(this.buttonBookmark_MouseEnter);
            this.buttonBookmark.MouseLeave += new System.EventHandler(this.buttonBookmark_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.panel1.Controls.Add(this.AddressBar);
            this.panel1.Controls.Add(this.urlBoxRight);
            this.panel1.Controls.Add(this.urlBoxLeft);
            this.panel1.ForeColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(72, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 27);
            this.panel1.TabIndex = 8;
            // 
            // AddressBar
            // 
            this.AddressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.AddressBar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AddressBar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressBar.Location = new System.Drawing.Point(17, 5);
            this.AddressBar.Margin = new System.Windows.Forms.Padding(9);
            this.AddressBar.Name = "AddressBar";
            this.AddressBar.Size = new System.Drawing.Size(131, 18);
            this.AddressBar.TabIndex = 5;
            this.AddressBar.Text = "about:blank";
            this.AddressBar.WordWrap = false;
            this.AddressBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressBar_KeyDown);
            // 
            // urlBoxRight
            // 
            this.urlBoxRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.urlBoxRight.Image = global::Browser.Properties.Resources.UrlBoxRight;
            this.urlBoxRight.Location = new System.Drawing.Point(163, 0);
            this.urlBoxRight.Name = "urlBoxRight";
            this.urlBoxRight.Size = new System.Drawing.Size(12, 28);
            this.urlBoxRight.TabIndex = 7;
            this.urlBoxRight.TabStop = false;
            // 
            // urlBoxLeft
            // 
            this.urlBoxLeft.Image = global::Browser.Properties.Resources.UrlBoxLeft;
            this.urlBoxLeft.Location = new System.Drawing.Point(0, 0);
            this.urlBoxLeft.Name = "urlBoxLeft";
            this.urlBoxLeft.Size = new System.Drawing.Size(12, 28);
            this.urlBoxLeft.TabIndex = 6;
            this.urlBoxLeft.TabStop = false;
            // 
            // buttonForward
            // 
            this.buttonForward.BackColor = System.Drawing.Color.Transparent;
            this.buttonForward.Image = global::Browser.Properties.Resources.ForwardActive;
            this.buttonForward.Location = new System.Drawing.Point(38, 5);
            this.buttonForward.Margin = new System.Windows.Forms.Padding(4, 4, 3, 3);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(28, 28);
            this.buttonForward.TabIndex = 3;
            this.buttonForward.TabStop = false;
            this.buttonForward.Click += new System.EventHandler(this.buttonForward_Click);
            this.buttonForward.MouseEnter += new System.EventHandler(this.buttonForward_MouseEnter);
            this.buttonForward.MouseLeave += new System.EventHandler(this.buttonForward_MouseLeave);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.Transparent;
            this.buttonBack.Image = global::Browser.Properties.Resources.BackActive;
            this.buttonBack.Location = new System.Drawing.Point(6, 5);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(4, 4, 3, 3);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(28, 28);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.TabStop = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            this.buttonBack.MouseEnter += new System.EventHandler(this.buttonBack_MouseEnter);
            this.buttonBack.MouseLeave += new System.EventHandler(this.buttonBack_MouseLeave);
            // 
            // openInANewTabToolStripMenuItem
            // 
            this.openInANewTabToolStripMenuItem.Name = "openInANewTabToolStripMenuItem";
            this.openInANewTabToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // BookmarksView
            // 
            this.BookmarksView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BookmarksView.Location = new System.Drawing.Point(38, 40);
            this.BookmarksView.Name = "BookmarksView";
            this.BookmarksView.Size = new System.Drawing.Size(279, 237);
            this.BookmarksView.TabIndex = 4;
            this.BookmarksView.Visible = false;
            this.BookmarksView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.BookmarksView_NodeMouseClick);
            this.BookmarksView.MouseEnter += new System.EventHandler(this.BookmarksView_MouseEnter);
            this.BookmarksView.MouseLeave += new System.EventHandler(this.BookmarksView_MouseLeave);
            // 
            // BrowserMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(326, 289);
            this.Controls.Add(this.BookmarksView);
            this.Controls.Add(this.toolbarBackground);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BrowserMain";
            this.Text = "Browser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BrowserMain_FormClosing);
            this.toolbarBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonBookmark)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.urlBoxRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.urlBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonForward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel toolbarBackground;
        private System.Windows.Forms.PictureBox urlBoxRight;
        private System.Windows.Forms.PictureBox urlBoxLeft;
        private System.Windows.Forms.TextBox AddressBar;
        private System.Windows.Forms.PictureBox buttonForward;
        private System.Windows.Forms.PictureBox buttonBack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox buttonBookmark;
        private System.Windows.Forms.PictureBox buttonSettings;
        private System.Windows.Forms.ToolStripMenuItem openInANewTabToolStripMenuItem;
        private System.Windows.Forms.TreeView BookmarksView;
    }
}

