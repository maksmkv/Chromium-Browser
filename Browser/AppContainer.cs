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
            CefSettings cefSettings = new CefSettings();
            cefSettings.DisableGpuAcceleration();

            Cef.Initialize(cefSettings);
        }

        public override TitleBarTab CreateTab()
        {
            return new TitleBarTab(this)
            {
                Content = new BrowserMain(null, false) { Text = "New Tab" }
            };
        }
        
    }
}
