using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Browser.Properties;
using CefSharp;
using CefSharp.WinForms;
using EasyTabs;

namespace Browser
{
    public partial class BrowserMain : Form
    {
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

        protected TitleBarTabs ParentTabs
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

            if(address == null || address == "")
            {
                WebBrowser = new ChromiumWebBrowser("about:blank")
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                    Location = new Point(0, 38),
                    MinimumSize = new Size(20, 20),
                    Name = "webBrowser",
                    Size = new Size(326, 251),
                    TabIndex = 6,
                    LifeSpanHandler = new NewTabLifespanHandler(this)
                };
            }
            else
            {
                WebBrowser = new ChromiumWebBrowser(address)
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                    Location = new Point(0, 38),
                    MinimumSize = new Size(20, 20),
                    Name = "webBrowser",
                    Size = new Size(326, 251),
                    TabIndex = 6,
                    LifeSpanHandler = new NewTabLifespanHandler(this)
                };
            }

            
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
                                    Icon = new Icon(ms);

                                    ParentTabs.UpdateThumbnailPreviewIcon(ParentTabs.Tabs.Single(t => t.Content == this));
                                    ParentTabs.RedrawTabs();
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

                if (!Regex.IsMatch(fullUrl, "^[a-zA-Z0-9]+\\://"))
                    fullUrl = "http://" + fullUrl;

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
//    public partial class BrowserMain : Form
//    {
//        public BrowserMain()
//        {
//            InitializeComponent();
//        }
//        public ChromiumWebBrowser c;

//        public void InitChromium()
//        {
//            Cef.EnableHighDPISupport();
//            c = new ChromiumWebBrowser("https://www.google.com") {
//                Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom),
//                Location = new Point(0, 38),
//                MinimumSize = new Size(20, 20),
//                Size = new Size(326, 251),
//                Name = "Browser"
//            };
//            c.Dock = DockStyle.Fill;
//            c.AddressChanged += C_AddressChanged;
//            c.TitleChanged += C_TitleChanged;
//            panelBrowser.Controls.Add(c);
//            CheckForIllegalCrossThreadCalls = false;
//        }

//        private void C_TitleChanged(object sender, TitleChangedEventArgs e)
//        {
//            this.Text = e.Title;
//        }

//        private void C_AddressChanged(object sender, AddressChangedEventArgs e)
//        {
//            AddressBar.Text = e.Address;
//        }

//        private void buttonBack_Click(object sender, EventArgs e)
//        {
//            if (c.CanGoBack)
//            {
//                c.Back();
//            }
//        }

//        private void buttonForward_Click(object sender, EventArgs e)
//        {
//            if (c.CanGoForward)
//            {
//                c.Forward();
//            }
//        }

//        private void buttonGo_Click(object sender, EventArgs e)
//        {
//            if (AddressBar.Text.Contains("https://www") || AddressBar.Text.Contains("http://www"))
//            {
//                c.Load(AddressBar.Text);
//            }
//            else if (!AddressBar.Text.Contains("www"))
//            {
//                if (AddressBar.Text.Contains("https://") || AddressBar.Text.Contains("http://"))
//                {
//                    AddressBar.Text = AddressBar.Text.Substring(8);
//                    AddressBar.Text = "https://www." + AddressBar.Text;
//                    c.Load(AddressBar.Text);
//                }
//                else if (!AddressBar.Text.Contains(".com"))
//                {
//                    c.Load("https://duckduckgo.com/?q=" + AddressBar.Text);
//                }
//                else
//                {
//                    c.Load("https://www." + AddressBar.Text);
//                }
//            }
//            else {
//                c.Load("https://" + AddressBar.Text);
//            }
//        }

//        private void AddressBar_KeyPress(object sender, KeyPressEventArgs e)
//        {
//            if(e.KeyChar == (char)Keys.Enter)
//            {
//                e.Handled = true;
//                buttonGo_Click(null, null);
//            }

//        }

//        private void buttonRefresh_Click(object sender, EventArgs e)
//        {
//            c.Refresh();

//        }

//        private void BrowserMain_Load(object sender, EventArgs e)
//        {
//            InitChromium();
//        }

//        private void BrowserMain_FormClosing(object sender, FormClosingEventArgs e)
//        {
//            Cef.Shutdown();
//        }
//    }
//}
