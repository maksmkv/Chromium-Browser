﻿using Browser.Properties;
using CefSharp;
using CefSharp.WinForms;
using EasyTabs;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Browser
{
    public partial class BrowserMain : Form
    {
        private ContextMenuHandler mHandler;
        private class NewTabLifespanHandler : ILifeSpanHandler
        {
            private BrowserMain _tab;

            public NewTabLifespanHandler(BrowserMain tab)
            {
                _tab = tab;
            }
            
            public bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
            {
                return true;
            }

            public void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
            {
            }

            public void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
            {
            }

            public bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
            {
                BrowserMain newTab = null;

                _tab.ParentTabs.Invoke(new Action(() =>
                {
                    _tab.ParentTabs.AddNewTab();
                    newTab = _tab.ParentTabs.SelectedTab.Content as BrowserMain;

                    bool newTabLoaded = false;

                    if (!newTab.WebBrowser.IsBrowserInitialized)
                    {
                        newTab.WebBrowser.IsBrowserInitializedChanged += (_, __) =>
                        {
                            newTab.WebBrowser.LoadingStateChanged += (___, e) =>
                            {
                                if (!newTabLoaded)
                                {
                                    if (!e.IsLoading)
                                    {
                                        newTabLoaded = true;
                                        newTab.WebBrowser.Load(targetUrl);
                                    }
                                }
                            };
                        };
                    }

                    else
                    {
                        newTab.WebBrowser.LoadingStateChanged += (_, e) =>
                        {
                            if (!newTabLoaded)
                            {
                                if (!e.IsLoading)
                                {
                                    newTabLoaded = true;
                                    newTab.WebBrowser.Load(targetUrl);
                                }
                            }
                        };
                    }
                }));
                newBrowser = null;
                return true;
            }

            private void WebBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
            {
                throw new NotImplementedException();
            }
        }

        public readonly ChromiumWebBrowser WebBrowser;
        private bool faviconLoaded = false;

        public TitleBarTabs ParentTabs
        {
            get
            {
                return (ParentForm as TitleBarTabs);
            }
        }

        public BrowserMain(string address)
        {
            InitializeComponent();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            WebBrowser = new ChromiumWebBrowser(string.IsNullOrWhiteSpace(address) ? "about:blank" : address)
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                    Location = new Point(0, 38),
                    MinimumSize = new Size(20, 20),
                    Name = "webBrowser",
                    Size = new Size(326, 251),
                    TabIndex = 6,
                    LifeSpanHandler = new NewTabLifespanHandler(this)
                };
            mHandler = new ContextMenuHandler(this);
            WebBrowser.MenuHandler = mHandler;
            Controls.Add(WebBrowser);
            WebBrowser.TitleChanged += WebBrowser_TitleChanged;
            WebBrowser.AddressChanged += WebBrowser_AddressChanged;
            WebBrowser.LoadingStateChanged += webBrowser_DocumentCompleted;
        }
        

        private void WebBrowser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            Invoke(new Action(() => AddressBar.Text = e.Address));

            if (e.Address != "about.blank" && !faviconLoaded)
            {
                Uri uri = new Uri(e.Address);

                if (uri.Scheme == "http" || uri.Scheme == "https")
                {
                    try
                    {
                        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri.Scheme + "://" + uri.Host + "/favicon.ico");
                        webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.83 Safari/537.36";
                        webRequest.KeepAlive = false;
                        webRequest.AllowAutoRedirect = true;

                        WebResponse response = webRequest.GetResponse();
                        Stream stream = response.GetResponseStream();

                        if (stream != null)
                        {
                            byte[] buffer = new byte[1024];

                            using (MemoryStream ms = new MemoryStream())
                            {
                                int read;

                                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                                    ms.Write(buffer, 0, read);

                                ms.Seek(0, SeekOrigin.Begin);

                                Invoke(new Action(() =>
                                {
                                    try
                                    {
                                        Icon = new Icon(ms);
                                        ParentTabs.UpdateThumbnailPreviewIcon(ParentTabs.Tabs.Single(t => t.Content == this));
                                        ParentTabs.RedrawTabs();
                                    }
                                    catch(Exception ex) 
                                    {
                                        var thread = new Thread(new ThreadStart(new Action(() =>
                                        {
                                            using (EventLog eventLog = new EventLog("Application"))
                                            {
                                                eventLog.Source = "Application";
                                                eventLog.WriteEntry(ex.Message, EventLogEntryType.Information, 101, 1);
                                            }
                                        })));
                                        thread.Start();
                                        Icon = Resources.DefaultIcon;
                                    }
                                }));
                            }
                        }
                    }

                    catch
                    {
                        Invoke(new Action(() => Icon = Resources.DefaultIcon));
                    }
                }

                Invoke(new Action(() => Parent.Refresh()));
                faviconLoaded = true;
            }
        }
        
        public void CreateNewTab(string url)
        {
           var newtab = new TitleBarTab(ParentTabs) { Content = new BrowserMain(url) { Text = "New Tab" } };
           if (ParentTabs.InvokeRequired) 
           {
               ParentTabs.Invoke(new Action(() => {
                     ParentTabs.Tabs.Insert(ParentTabs.SelectedTabIndex + 1, newtab);
                     ParentTabs.SelectedTabIndex++;
                     ParentTabs.RedrawTabs();
                     ParentTabs.Refresh();
               }));
           }
           else 
           {
               ParentTabs.Tabs.Insert(ParentTabs.SelectedTabIndex + 1, newtab);
               ParentTabs.SelectedTabIndex++;
               ParentTabs.RedrawTabs();
               ParentTabs.Refresh();
           }
        }
        public void CloseActiveTab()
        {
            if (ParentTabs.InvokeRequired)
            {
                if (ParentTabs.Tabs.Count() > 1) {
                    ParentTabs.Invoke(new Action(() => {
                        ParentTabs.Tabs.Remove(ParentTabs.SelectedTab);
                        ParentTabs.SelectedTabIndex--;
                        ParentTabs.RedrawTabs();
                        ParentTabs.Refresh();
                    }));
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                if (ParentTabs.Tabs.Count() > 1) {
                    ParentTabs.Tabs.Remove(ParentTabs.SelectedTab);
                    ParentTabs.SelectedTabIndex = ParentTabs.Tabs.Count() - 1;
                    ParentTabs.RedrawTabs();
                    ParentTabs.Refresh();
                }
                else
                {
                    this.Close();
                }
            }
        }
        public void RefreshActiveTab()
        {
            if (ParentTabs.InvokeRequired)
            {
                ParentTabs.Invoke(new Action(()=> {
                    WebBrowser.Load(this.AddressBar.Text);
                }));
            }
            else
            {
                WebBrowser.Load(this.AddressBar.Text);
            }
        }
        public void Print()
        {
            WebBrowser.Print();
        }
        public void SaveAsPDF()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt= "pdf";
            sfd.Filter = "Adobe PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";
            sfd.ShowDialog();
            WebBrowser.PrintToPdfAsync(sfd.FileName);
        }
        private void WebBrowser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            Invoke(new Action(() => Text = e.Title));
        }

        void webBrowser_DocumentCompleted(object sender, LoadingStateChangedEventArgs e)
        {
            if (AddressBar.Text == "about:blank")
            {
                Invoke(new Action(() => Icon = Resources.DefaultIcon));
            }
        }

        private void buttonBack_MouseEnter(object sender, EventArgs e)
        {
            buttonBack.BackgroundImage = Resources.ButtonHoverBackground;
        }

        private void buttonBack_MouseLeave(object sender, EventArgs e)
        {
            buttonBack.BackgroundImage = null;
        }
        private void buttonBookmark_MouseEnter(object sender, EventArgs e)
        {
            buttonBookmark.BackgroundImage = Resources.ButtonHoverBackground;
        }

        private void buttonBookmark_MouseLeave(object sender, EventArgs e)
        {
            buttonBookmark.BackgroundImage = null;
        }
        private void buttonSettings_MouseEnter(object sender, EventArgs e)
        {
            buttonSettings.BackgroundImage = Resources.ButtonHoverBackground;
        }

        private void buttonSettings_MouseLeave(object sender, EventArgs e)
        {
            buttonSettings.BackgroundImage = null;
        }

        private void AddressBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string fullUrl = AddressBar.Text;
                if (!fullUrl.Contains(".com"))
                {
                    fullUrl = "https://duckduckgo.com/?q=" + fullUrl;
                }
                else if (!Regex.IsMatch(fullUrl, "^[a-zA-Z0-9]+\\://"))
                {
                    fullUrl = "http://" + fullUrl;
                }
                e.SuppressKeyPress = true;
                faviconLoaded = false;
                WebBrowser.Load(fullUrl);
            }
        }

        private void buttonForward_MouseEnter(object sender, EventArgs e)
        {
            buttonForward.BackgroundImage = Resources.ButtonHoverBackground;
        }

        private void buttonForward_MouseLeave(object sender, EventArgs e)
        {
            buttonForward.BackgroundImage = null;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            WebBrowser.Back();
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            WebBrowser.Forward();
        }

        private void BrowserMain_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
       
    }
}
