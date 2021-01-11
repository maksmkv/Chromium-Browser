using CefSharp;
using CefSharp.WinForms;
using EasyTabs;

namespace Browser
{
    public partial class AppContainer : TitleBarTabs
    {
        public AppContainer()
        {
            InitializeComponent();
            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
            Icon = Properties.Resources.DefaultIcon;
        }
        static AppContainer()
        {
            // This is only so that generating a thumbnail for Aero peek works properly:  with GPU acceleration enabled, all you get is a black box
            // when you try to "snapshot" the web browser control.  If you don't plan on using Aero peek, remove this method.
            CefSettings cefSettings = new CefSettings();
            cefSettings.DisableGpuAcceleration();

            Cef.Initialize(cefSettings);
        }

        public override TitleBarTab CreateTab()
        {
            return new TitleBarTab(this)
            {
                Content = new BrowserMain(null) { Text = "New Tab" }
            };
        }
        public TitleBarTab NavigateTab(string address)
        {
            return new TitleBarTab(this)
            {
                Content = new BrowserMain(address) { Text = "New Tab" }
            };
        }
    }
}
