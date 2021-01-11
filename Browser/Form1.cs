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
        }
        public ChromiumWebBrowser c;

        public void InitChromium()
        {
            Cef.EnableHighDPISupport();
            //Cef.Initialize(new CefSettings());
            c = new ChromiumWebBrowser("https://www.google.com");
            c.Dock = DockStyle.Fill;

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
            AddressBar.Text = e.Address;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (c.CanGoBack)
            {
                c.Back();
            }
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            if (c.CanGoForward)
            {
                c.Forward();
            }
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (AddressBar.Text.Contains("https://www") || AddressBar.Text.Contains("http://www"))
            {
                c.Load(AddressBar.Text);
            }
            else if (!AddressBar.Text.Contains("www"))
            {
                if (AddressBar.Text.Contains("https://") || AddressBar.Text.Contains("http://"))
                {
                    AddressBar.Text = AddressBar.Text.Substring(8);
                    AddressBar.Text = "https://www." + AddressBar.Text;
                    c.Load(AddressBar.Text);
                }
                else if (!AddressBar.Text.Contains(".com"))
                {
                    c.Load("https://duckduckgo.com/?q=" + AddressBar.Text);
                }
                else
                {
                    c.Load("https://www." + AddressBar.Text);
                }
            }
            else {
                c.Load("https://" + AddressBar.Text);
            }
        }

        private void AddressBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                buttonGo_Click(null, null);
            }
            
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            c.Refresh();
           
        }

        private void BrowserMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void BrowserMain_Load(object sender, EventArgs e)
        {
            InitChromium();
        }
    }
}
