﻿using System;
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
            else
            {
                c.Load("https://"+AddressBar.Text);
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
    }
}
