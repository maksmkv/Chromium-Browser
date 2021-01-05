using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace Browser
{
    public partial class BrowserMain : Form
    {
        public BrowserMain()
        {
            InitializeComponent();
            InitChromium();
        }
        public ChromiumWebBrowser c;

        public void InitChromium()
        {
            Cef.EnableHighDPISupport();
            Cef.Initialize(new CefSettings());
            c = new ChromiumWebBrowser("https://www.google.com");
            c.AddressChanged += C_AddressChanged;
            c.TitleChanged += C_TitleChanged;
            panelBrowser.Controls.Add(c);
            CheckForIllegalCrossThreadCalls = false;
        }

        private void C_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            this.Text = e.Title;
        }

        private void C_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            AddressBar.Text = e.Address.ToString();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            c.Back();
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            c.Forward();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            c.Load(AddressBar.Text);
        }

        private void AddressBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                buttonGo_Click(null, null);
            }
            
        }
    }
}
