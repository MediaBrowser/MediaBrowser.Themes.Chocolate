namespace Chocolate
{
    using MediaBrowser.Library.Persistance;
    using System;

    [Serializable]
    public class ConfigData
    {
        public bool alwaysShowPoster;
        public bool backdropfill;
        public bool backdropfit;
        public bool backdropStretch;
        [SkipField]
        private XmlSettings<ConfigData> ChocolateSettings;
        public bool disableehsmovietitle;
        public bool enable24hr;
        public bool enableEHSBackdrop;
        public bool enableFolderBackdrop;
        public bool enableStripBackdrop;
        public bool enableVideoBackdrop;
        [SkipField]
        private string file;
        public string npvAR;
        public bool showconfig;
        public bool showcoverflowendtime;
        public bool showcoverflowindicator;
        public bool showcoverflowlogos;
        public bool showcoverflowdetails;
        public bool showcoverflowposteroverlay;
        public bool showcoverflowtitle;
        public bool showcoverflowtotalnumber;
        public bool showInfoIcons;
        public bool showInfoIconsBackground;
        public bool showlistendtime;
        public bool showlistlogos;
        public bool showLogos;
        public bool showlogosonmoviedetail;
        public bool shownowplayingicon;
        public bool shownpv;
        public bool showposterendtime;
        public bool showposterlogos;
        public bool showstriplogos;
        public bool showthumbendtime;
        public bool showthumblogos;
        public bool showWeather;
        public bool smallEhs;
        public bool stripviewExpanded;
        public string themeCustomFont;
        public bool useSeasonPoster;
        public bool useCustomTvView;
        public bool AskToQuit;

        public ConfigData()
        {
            this.showInfoIcons = true;
            this.showInfoIconsBackground = true;
            this.useSeasonPoster = true;
            this.enableVideoBackdrop = true;
            this.showconfig = true;
            this.npvAR = "Normal";
            this.themeCustomFont = "Default";
            this.shownowplayingicon = true;
            this.showcoverflowtitle = true;
            this.showcoverflowdetails = true;
            this.disableehsmovietitle = true;
            this.showcoverflowlogos = false;
            this.showlistlogos = true;
            this.showposterlogos = true;
            this.showthumblogos = true;
            this.showstriplogos = true;
            this.showcoverflowendtime = true;
            this.showlistendtime = true;
            this.showposterendtime = true;
            this.showthumbendtime = true;
            this.showcoverflowindicator = true;
            this.showcoverflowposteroverlay = true;
            this.showcoverflowtotalnumber = true;
            useCustomTvView = true;
        }

        public ConfigData(string file)
        {
            this.showInfoIcons = true;
            this.showInfoIconsBackground = true;
            this.useSeasonPoster = true;
            this.enableVideoBackdrop = true;
            this.showconfig = true;
            this.npvAR = "Normal";
            this.themeCustomFont = "Default";
            this.shownowplayingicon = true;
            this.showcoverflowtitle = true;
            this.showcoverflowdetails = true;
            this.disableehsmovietitle = true;
            this.showcoverflowlogos = false;
            this.showlistlogos = true;
            this.showposterlogos = true;
            this.showthumblogos = true;
            this.showstriplogos = true;
            this.showcoverflowendtime = true;
            this.showlistendtime = true;
            this.showposterendtime = true;
            this.showthumbendtime = true;
            this.showcoverflowindicator = true;
            this.showcoverflowposteroverlay = true;
            this.showcoverflowtotalnumber = true;
            useCustomTvView = true;
            this.file = file;
            this.ChocolateSettings = XmlSettings<ConfigData>.Bind(this, file);
        }

        public static ConfigData FromFile(string file)
        {
            return new ConfigData(file);
        }

        public void Save()
        {
            this.ChocolateSettings.Write();
        }
    }
}

