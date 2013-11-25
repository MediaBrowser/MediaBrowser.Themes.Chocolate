namespace Chocolate
{
    using MediaBrowser.Library;
    using MediaBrowser.Library.Localization;
    using MediaBrowser.Library.Logging;
    using MediaBrowser.Library.Plugins;
    using MediaBrowser.Library.Util;
    using System;

    internal class Plugin : BasePlugin
    {
        private static readonly Guid ChocolateGuid = new Guid("8d66894c-89d3-4d25-97be-68501b24879a");
        public MyConfig config;

        public override void Init(Kernel kernel)
        {
            try
            {
                kernel.AddTheme("Chocolate", "resx://Chocolate/Chocolate.Resources/Page#PageChocolate", "resx://Chocolate/Chocolate.Resources/NewDetailMovieView#NewChocolateMovieView");
                if (AppDomain.CurrentDomain.FriendlyName.Contains("ehExtHost"))
                {
                    this.config = new MyConfig();
                    kernel.AddConfigPanel("Chocolate General", "resx://Chocolate/Chocolate.Resources/ConfigPanel#ConfigPanel", this.config);
                    kernel.AddConfigPanel("Chocolate Views", "resx://Chocolate/Chocolate.Resources/ConfigPanelViews#ConfigPanelViews", this.config);
                }
                else
                {
                    Logger.ReportInfo("Not creating menus for Chocolate.  Appear to not be in MediaCenter.  AppDomain is: " + AppDomain.CurrentDomain.FriendlyName);
                }
                kernel.StringData.AddStringData(MyStrings.FromFile(LocalizedStringData.GetFileName("Chocolate-")));
                CustomResourceManager.AppendFonts("Chocolate", Resources.Fonts, Resources.FontsSmall);
                CustomResourceManager.AppendStyles("Chocolate", Resources.Colors, Resources.Colors);
                Logger.ReportInfo("Chocolate Theme (version " + this.Version + ") Loaded.");
            }
            catch (Exception exception)
            {
                Logger.ReportException("Error adding theme - probably incompatable MB version", exception);
            }
        }

        public override string Description
        {
            get
            {
                return "The Smoothest of the bunch.";
            }
        }

        public override bool InstallGlobally
        {
            get
            {
                return true;
            }
        }

        public override string Name
        {
            get
            {
                return "Chocolate Theme";
            }
        }

        public override Version RequiredMBVersion
        {
            get
            {
                return new Version(2, 6, 0, 0);
            }
        }

        public override Version TestedMBVersion
        {
            get
            {
                return new Version(2, 6, 0, 0);
            }
        }
    }
}

