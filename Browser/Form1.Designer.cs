
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
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonForward = new System.Windows.Forms.Button();
            this.AddressBar = new System.Windows.Forms.TextBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.panelBrowser = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.AutoSize = true;
            this.buttonBack.Location = new System.Drawing.Point(12, 12);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 27);
            this.buttonBack.TabIndex = 0;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonForward
            // 
            this.buttonForward.AutoSize = true;
            this.buttonForward.Location = new System.Drawing.Point(95, 12);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(75, 28);
            this.buttonForward.TabIndex = 1;
            this.buttonForward.Text = "Forward";
            this.buttonForward.UseVisualStyleBackColor = true;
            this.buttonForward.Click += new System.EventHandler(this.buttonForward_Click);
            // 
            // AddressBar
            // 
            this.AddressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressBar.Location = new System.Drawing.Point(176, 12);
            this.AddressBar.Name = "AddressBar";
            this.AddressBar.Size = new System.Drawing.Size(494, 30);
            this.AddressBar.TabIndex = 2;
            this.AddressBar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddressBar_KeyPress);
            // 
            // buttonGo
            // 
            this.buttonGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGo.AutoSize = true;
            this.buttonGo.Location = new System.Drawing.Point(676, 12);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(94, 28);
            this.buttonGo.TabIndex = 3;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // panelBrowser
            // 
            this.panelBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBrowser.AutoSize = true;
            this.panelBrowser.Location = new System.Drawing.Point(12, 48);
            this.panelBrowser.Name = "panelBrowser";
            this.panelBrowser.Size = new System.Drawing.Size(776, 390);
            this.panelBrowser.TabIndex = 4;
            // 
            // BrowserMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelBrowser);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.AddressBar);
            this.Controls.Add(this.buttonForward);
            this.Controls.Add(this.buttonBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BrowserMain";
            this.Text = "Browser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonForward;
        private System.Windows.Forms.TextBox AddressBar;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Panel panelBrowser;
    }
}

