namespace Chocolate
{
    using MediaBrowser.Library.Logging;
    using MediaBrowser.Library.Configuration;
    using Microsoft.MediaCenter;
    using Microsoft.MediaCenter.Hosting;
    using Microsoft.MediaCenter.UI;
    using System;
    using System.IO;

    public class MyConfig : ModelItem
    {
        private readonly string configFilePath = Path.Combine(ApplicationPaths.AppPluginPath, @"Configurations\Chocolate.xml");
        private readonly string configFolderPath = Path.Combine(ApplicationPaths.AppPluginPath, "Configurations");
        private static string CUSTOM_FONTS_FILE = Path.Combine(ApplicationPaths.AppPluginPath, @"Chocolate\Fonts\Choc_Custom_Fonts.mcml");
        private ConfigData data;
        private static string DEFAULT_FONTS_FILE = Path.Combine(ApplicationPaths.AppPluginPath, @"Chocolate\Fonts\Choc_Default_Fonts.mcml");
        private static string fontsFilePath = Path.Combine(ApplicationPaths.AppPluginPath, @"Chocolate\Chocolate_Fonts.mcml");
        private static string fontsFolderPath = Path.Combine(ApplicationPaths.AppPluginPath, @"Chocolate\Fonts");
        private bool isValid;
        private static string themeFolderPath = Path.Combine(ApplicationPaths.AppPluginPath, "Chocolate");

        public MyConfig()
        {
            this.isValid = this.Load();
            this.CheckActiveFonts();
        }

        public void CheckActiveFonts()
        {
            string themeCustomFont = this.ThemeCustomFont;
            this.data.themeCustomFont = "";
            this.ThemeCustomFont = themeCustomFont;
            if (!File.Exists(fontsFilePath))
            {
                this.data.themeCustomFont = "";
                this.ThemeCustomFont = "Default";
            }
        }

        private bool Load()
        {
            try
            {
                if (!Directory.Exists(themeFolderPath))
                {
                    Logger.ReportInfo("Chocolate - Creating theme folder: " + themeFolderPath);
                    Directory.CreateDirectory(themeFolderPath);
                }
                if (!Directory.Exists(fontsFolderPath))
                {
                    Logger.ReportInfo("Chocolate - Creating fonts folder: " + fontsFolderPath);
                    Directory.CreateDirectory(fontsFolderPath);
                }
                if (!File.Exists(DEFAULT_FONTS_FILE))
                {
                    Logger.ReportInfo("Chocolate - Creating default fonts file: " + DEFAULT_FONTS_FILE);
                    File.WriteAllBytes(DEFAULT_FONTS_FILE, Resources.Fonts);
                }
                if (!File.Exists(CUSTOM_FONTS_FILE))
                {
                    Logger.ReportInfo("Chocolate - Creating custom fonts file: " + CUSTOM_FONTS_FILE);
                    File.WriteAllBytes(CUSTOM_FONTS_FILE, Resources.Fonts);
                }
                if (!File.Exists(fontsFilePath))
                {
                    Logger.ReportInfo("Chocolate - Creating basic fonts file: " + fontsFilePath);
                    File.WriteAllBytes(fontsFilePath, Resources.Fonts);
                }
                this.data = ConfigData.FromFile(this.configFilePath);
                return true;
            }
            catch (Exception exception)
            {
                if (AddInHost.Current.MediaCenterEnvironment.Dialog(exception.Message + "\nReset to default?", "Error in configuration file", DialogButtons.No | DialogButtons.Yes, 600, true) == DialogResult.Yes)
                {
                    if (!Directory.Exists(this.configFolderPath))
                    {
                        Directory.CreateDirectory(this.configFolderPath);
                    }
                    this.data = new ConfigData(this.configFilePath);
                    this.Save();
                    return true;
                }
                return false;
            }
        }

        private void Save()
        {
            lock (this)
            {
                this.data.Save();
            }
        }

        public bool AlwaysShowPoster
        {
            get
            {
                return this.data.alwaysShowPoster;
            }
            set
            {
                if (this.data.alwaysShowPoster != value)
                {
                    this.data.alwaysShowPoster = value;
                    base.FirePropertyChanged("AlwaysShowPoster");
                    this.Save();
                }
            }
        }

        public bool BackdropFill
        {
            get
            {
                return this.data.backdropfill;
            }
            set
            {
                if (this.data.backdropfill != value)
                {
                    this.data.backdropfill = value;
                    base.FirePropertyChanged("BackdropFill");
                    this.Save();
                }
            }
        }

        public bool BackdropFit
        {
            get
            {
                return this.data.backdropfit;
            }
            set
            {
                if (this.data.backdropfit != value)
                {
                    this.data.backdropfit = value;
                    base.FirePropertyChanged("BackdropFit");
                    this.Save();
                }
            }
        }

        public bool BackdropStretch
        {
            get
            {
                return this.data.backdropStretch;
            }
            set
            {
                if (this.data.backdropStretch != value)
                {
                    this.data.backdropStretch = value;
                    base.FirePropertyChanged("BackdropStretch");
                    this.Save();
                }
            }
        }

        public bool DisableEHSMovieTitle
        {
            get
            {
                return this.data.disableehsmovietitle;
            }
            set
            {
                if (this.data.disableehsmovietitle != value)
                {
                    this.data.disableehsmovietitle = value;
                    base.FirePropertyChanged("DisableEHSMovieTitle");
                    this.Save();
                }
            }
        }

        public bool Enable24hr
        {
            get
            {
                return this.data.enable24hr;
            }
            set
            {
                if (this.data.enable24hr != value)
                {
                    this.data.enable24hr = value;
                    base.FirePropertyChanged("Enable24hr");
                    this.Save();
                }
            }
        }

        public bool EnableEHSBackdrop
        {
            get
            {
                return this.data.enableEHSBackdrop;
            }
            set
            {
                if (this.data.enableEHSBackdrop != value)
                {
                    this.data.enableEHSBackdrop = value;
                    base.FirePropertyChanged("EnableEHSBackdrop");
                    this.Save();
                }
            }
        }

        public bool EnableFolderBackdrop
        {
            get
            {
                return this.data.enableFolderBackdrop;
            }
            set
            {
                if (this.data.enableFolderBackdrop != value)
                {
                    this.data.enableFolderBackdrop = value;
                    base.FirePropertyChanged("EnableFolderBackdrop");
                    this.Save();
                }
            }
        }

        public bool EnableStripBackdrop
        {
            get
            {
                return this.data.enableStripBackdrop;
            }
            set
            {
                if (this.data.enableStripBackdrop != value)
                {
                    this.data.enableStripBackdrop = value;
                    base.FirePropertyChanged("EnableStripBackdrop");
                    this.Save();
                }
            }
        }

        public bool EnableVideoBackdrop
        {
            get
            {
                return this.data.enableVideoBackdrop;
            }
            set
            {
                if (this.data.enableVideoBackdrop != value)
                {
                    this.data.enableVideoBackdrop = value;
                    base.FirePropertyChanged("EnableVideoBackdrop");
                    this.Save();
                }
            }
        }

        public string NPVAR
        {
            get
            {
                if (((this.data.npvAR != "Normal") && (this.data.npvAR != "Double")) && (this.data.npvAR != "Triple"))
                {
                    this.data.npvAR = "Normal";
                    base.FirePropertyChanged("NPVAR");
                    this.Save();
                }
                return this.data.npvAR;
            }
            set
            {
                if (this.data.npvAR != value)
                {
                    this.data.npvAR = value;
                    base.FirePropertyChanged("NPVAR");
                    this.Save();
                }
            }
        }

        public bool ShowConfig
        {
            get
            {
                return this.data.showconfig;
            }
            set
            {
                if (this.data.showconfig != value)
                {
                    this.data.showconfig = value;
                    base.FirePropertyChanged("ShowConfig");
                    this.Save();
                }
            }
        }

        public bool ShowCoverFlowEndTime
        {
            get
            {
                return this.data.showcoverflowendtime;
            }
            set
            {
                if (this.data.showcoverflowendtime != value)
                {
                    this.data.showcoverflowendtime = value;
                    base.FirePropertyChanged("ShowCoverFlowEndTime");
                    this.Save();
                }
            }
        }

        public bool ShowCoverflowIndicator
        {
            get
            {
                return this.data.showcoverflowindicator;
            }
            set
            {
                if (this.data.showcoverflowindicator != value)
                {
                    this.data.showcoverflowindicator = value;
                    base.FirePropertyChanged("ShowCoverflowIndicator");
                    this.Save();
                }
            }
        }

        public bool ShowCoverFlowLogos
        {
            get
            {
                return this.data.showcoverflowlogos;
            }
            set
            {
                if (this.data.showcoverflowlogos != value)
                {
                    this.data.showcoverflowlogos = value;
                    base.FirePropertyChanged("ShowCoverFlowLogos");
                    this.Save();
                }
            }
        }

        public bool ShowCoverFlowDetails
        {
            get
            {
                return this.data.showcoverflowdetails;
            }
            set
            {
                if (this.data.showcoverflowdetails != value)
                {
                    this.data.showcoverflowdetails = value;
                    base.FirePropertyChanged("ShowCoverFlowDetails");
                    this.Save();
                }
            }
        }

        public bool ShowCoverflowPosterOverlay
        {
            get
            {
                return this.data.showcoverflowposteroverlay;
            }
            set
            {
                if (this.data.showcoverflowposteroverlay != value)
                {
                    this.data.showcoverflowposteroverlay = value;
                    base.FirePropertyChanged("ShowCoverflowPosterOverlay");
                    this.Save();
                }
            }
        }

        public bool ShowCoverFlowTitle
        {
            get
            {
                return this.data.showcoverflowtitle;
            }
            set
            {
                if (this.data.showcoverflowtitle != value)
                {
                    this.data.showcoverflowtitle = value;
                    base.FirePropertyChanged("ShowCoverFlowTitle");
                    this.Save();
                }
            }
        }

        public bool ShowCoverflowTotalNumber
        {
            get
            {
                return this.data.showcoverflowtotalnumber;
            }
            set
            {
                if (this.data.showcoverflowtotalnumber != value)
                {
                    this.data.showcoverflowtotalnumber = value;
                    base.FirePropertyChanged("ShowCoverflowTotalNumber");
                    this.Save();
                }
            }
        }

        public bool ShowInfoIcons
        {
            get
            {
                return this.data.showInfoIcons;
            }
            set
            {
                if (this.data.showInfoIcons != value)
                {
                    this.data.showInfoIcons = value;
                    base.FirePropertyChanged("ShowInfoIcons");
                    this.Save();
                }
            }
        }

        public bool ShowInfoIconsBackground
        {
            get
            {
                return this.data.showInfoIconsBackground;
            }
            set
            {
                if (this.data.showInfoIconsBackground != value)
                {
                    this.data.showInfoIconsBackground = value;
                    base.FirePropertyChanged("ShowInfoIconsBackground");
                    this.Save();
                }
            }
        }

        public bool ShowListEndTime
        {
            get
            {
                return this.data.showlistendtime;
            }
            set
            {
                if (this.data.showlistendtime != value)
                {
                    this.data.showlistendtime = value;
                    base.FirePropertyChanged("ShowListEndTime");
                    this.Save();
                }
            }
        }

        public bool ShowListLogos
        {
            get
            {
                return this.data.showlistlogos;
            }
            set
            {
                if (this.data.showlistlogos != value)
                {
                    this.data.showlistlogos = value;
                    base.FirePropertyChanged("ShowListLogos");
                    this.Save();
                }
            }
        }

        public bool ShowLogos
        {
            get
            {
                return this.data.showLogos;
            }
            set
            {
                if (this.data.showLogos != value)
                {
                    this.data.showLogos = value;
                    base.FirePropertyChanged("ShowLogos");
                    this.Save();
                }
            }
        }

        public bool ShowLogosOnMovieDetail
        {
            get
            {
                return this.data.showlogosonmoviedetail;
            }
            set
            {
                if (this.data.showlogosonmoviedetail != value)
                {
                    this.data.showlogosonmoviedetail = value;
                    base.FirePropertyChanged("ShowLogosOnMovieDetail");
                    this.Save();
                }
            }
        }

        public bool ShowDiscDetail
        {
            get
            {
                return this.data.ShowDiscDetail;
            }
            set
            {
                if (this.data.ShowDiscDetail != value)
                {
                    this.data.ShowDiscDetail = value;
                    base.FirePropertyChanged("ShowDiscDetail");
                    this.Save();
                }
            }
        }

        public bool ShowListBackground
        {
            get
            {
                return this.data.ShowListBackground;
            }
            set
            {
                if (this.data.ShowListBackground != value)
                {
                    this.data.ShowListBackground = value;
                    base.FirePropertyChanged("ShowListBackground");
                    this.Save();
                }
            }
        }

        public bool ShowPosterInfo
        {
            get
            {
                return this.data.ShowPosterInfo;
            }
            set
            {
                if (this.data.ShowPosterInfo != value)
                {
                    this.data.ShowPosterInfo = value;
                    base.FirePropertyChanged("ShowPosterInfo");
                    this.Save();
                }
            }
        }

        public bool UseCustomTvView
        {
            get
            {
                return this.data.useCustomTvView;
            }
            set
            {
                if (this.data.useCustomTvView != value)
                {
                    this.data.useCustomTvView = value;
                    base.FirePropertyChanged("UseCustomTvView");
                    this.Save();
                }
            }
        }

        public bool ShowNowPlayingIcon
        {
            get
            {
                return this.data.shownowplayingicon;
            }
            set
            {
                if (this.data.shownowplayingicon != value)
                {
                    this.data.shownowplayingicon = value;
                    base.FirePropertyChanged("ShowConfig");
                    this.Save();
                }
            }
        }

        public bool ShowLegend
        {
            get
            {
                return this.data.ShowLegend;
            }
            set
            {
                if (this.data.ShowLegend != value)
                {
                    this.data.ShowLegend = value;
                    base.FirePropertyChanged("ShowLegend");
                    this.Save();
                }
            }
        }

        public bool ShowNPV
        {
            get
            {
                return this.data.shownpv;
            }
            set
            {
                if (this.data.shownpv != value)
                {
                    this.data.shownpv = value;
                    base.FirePropertyChanged("ShowConfig");
                    this.Save();
                }
            }
        }

        public bool ShowPosterEndTime
        {
            get
            {
                return this.data.showposterendtime;
            }
            set
            {
                if (this.data.showposterendtime != value)
                {
                    this.data.showposterendtime = value;
                    base.FirePropertyChanged("ShowPosterEndTime");
                    this.Save();
                }
            }
        }

        public bool ShowPosterLogos
        {
            get
            {
                return this.data.showposterlogos;
            }
            set
            {
                if (this.data.showposterlogos != value)
                {
                    this.data.showposterlogos = value;
                    base.FirePropertyChanged("ShowPosterLogos");
                    this.Save();
                }
            }
        }

        public bool ShowStripLogos
        {
            get
            {
                return this.data.showstriplogos;
            }
            set
            {
                if (this.data.showstriplogos != value)
                {
                    this.data.showstriplogos = value;
                    base.FirePropertyChanged("ShowStripLogos");
                    this.Save();
                }
            }
        }

        public bool ShowThumbEndTime
        {
            get
            {
                return this.data.showthumbendtime;
            }
            set
            {
                if (this.data.showthumbendtime != value)
                {
                    this.data.showthumbendtime = value;
                    base.FirePropertyChanged("ShowThumbEndTime");
                    this.Save();
                }
            }
        }

        public bool ShowThumbLogos
        {
            get
            {
                return this.data.showthumblogos;
            }
            set
            {
                if (this.data.showthumblogos != value)
                {
                    this.data.showthumblogos = value;
                    base.FirePropertyChanged("ShowThumbLogos");
                    this.Save();
                }
            }
        }

        public bool ShowWeather
        {
            get
            {
                return this.data.showWeather;
            }
            set
            {
                if (this.data.showWeather != value)
                {
                    this.data.showWeather = value;
                    base.FirePropertyChanged("ShowWeather");
                    this.Save();
                }
            }
        }

        public bool SmallEhs
        {
            get
            {
                return this.data.smallEhs;
            }
            set
            {
                if (this.data.smallEhs != value)
                {
                    this.data.smallEhs = value;
                    base.FirePropertyChanged("SmallEhs");
                    this.Save();
                }
            }
        }

        public bool StripviewExpanded
        {
            get
            {
                return this.data.stripviewExpanded;
            }
            set
            {
                if (this.data.stripviewExpanded != value)
                {
                    this.data.stripviewExpanded = value;
                    base.FirePropertyChanged("StripviewExpanded");
                    this.Save();
                }
            }
        }

        public string ThemeCustomFont
        {
            get
            {
                return this.data.themeCustomFont;
            }
            set
            {
                if (this.data.themeCustomFont != value)
                {
                    File.Copy(Path.Combine(fontsFolderPath, "Choc_" + value + "_Fonts.mcml"), fontsFilePath, true);
                    this.data.themeCustomFont = value;
                    this.Save();
                    base.FirePropertyChanged("ThemeFont");
                }
            }
        }

        public bool UseSeasonPoster
        {
            get
            {
                return this.data.useSeasonPoster;
            }
            set
            {
                if (this.data.useSeasonPoster != value)
                {
                    this.data.useSeasonPoster = value;
                    base.FirePropertyChanged("UseSeasonPoster");
                    this.Save();
                }
            }
        }

    }
}

