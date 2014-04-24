using MediaBrowser.Library.Localization;
using MediaBrowser.Library.Threading;
using Microsoft.MediaCenter;
using Microsoft.MediaCenter.Hosting;

namespace Chocolate
{
    using MediaBrowser;
    using MediaBrowser.Library;
    using Microsoft.MediaCenter.UI;
    using System;
    using System.Runtime.CompilerServices;

    public class ChocHelper : ModelItem
    {
        private MediaBrowser.Library.Item _currentItem;
        public bool _showOverveiew;
        private static bool buttonPanelHasFocus = false;
        private static Image currentBackdrop;
        private static string currentPage = "Page";
        private static Image defaultBackdrop;
        private static bool isMenuOpen = false;
        private int NavCount;
        private static bool navigatingForward = true;
        private Timer OverviewTimer;

        private static SizeRef _seasonPosterSize = new SizeRef(new Size(200,300));

        public ChocHelper()
        {
            this.OverviewTimer = new Timer();
            this.setupHelper();
        }

        public ChocHelper(MediaBrowser.Library.Item Item)
        {
            this.OverviewTimer = new Timer();
            this.CurrentItem = Item;
            this.setupHelper();
        }

        private string calculateEndTime()
        {
            return CurrentItem == null ? "" : CurrentItem.EndTime.ToString(Config.Enable24hr ? "HH:mm" : "h:mm");
        }

        private float calculatePercentWatched()
        {
            float num = 0f;
            if (!string.IsNullOrEmpty(this.CurrentItem.RunningTimeString))
            {
                int num2 = int.Parse(this.CurrentItem.RunningTimeString.Substring(0, this.CurrentItem.RunningTimeString.IndexOf(' ')));
                int totalMinutes = (int) this.CurrentItem.WatchedTime.TotalMinutes;
                if ((num2 > 0) && (totalMinutes > 0))
                {
                    num = ((float) totalMinutes) / ((float) num2);
                }
            }
            return num;
        }

        private void FireGameChanges()
        {
            base.FirePropertyChanged("Players");
            base.FirePropertyChanged("TgdbRating");
            base.FirePropertyChanged("ProductionYear");
            base.FirePropertyChanged("EsrbRating");
            base.FirePropertyChanged("Company");
            base.FirePropertyChanged("ConsoleReleaseYear");
            base.FirePropertyChanged("CpuBits");
            base.FirePropertyChanged("GpuBits");
        }

        private void FireMusicChanges()
        {
            base.FirePropertyChanged("Album");
            base.FirePropertyChanged("Artist");
            base.FirePropertyChanged("ProductionYear");
            base.FirePropertyChanged("Duration");
        }

        private string GetDynamicProperty(string PropertyName)
        {
            try
            {
                return (this.CurrentItem.DynamicProperties[PropertyName] as string);
            }
            catch (Exception)
            {
                return "";
            }
        }

        private int GetDynamicPropertyAsInt(string PropertyName)
        {
            try
            {
                return Convert.ToInt32(this.CurrentItem.DynamicProperties[PropertyName]);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private float GetDynamicPropertyAsSingle(string PropertyName)
        {
            try
            {
                return Convert.ToSingle(this.CurrentItem.DynamicProperties[PropertyName]);
            }
            catch
            {
                return 0f;
            }
        }

        public string GetLongDateString(DateTime date)
        {
            if (date.Date == DateTime.Today)
            {
                return "Added Today";
            }
            if (date.Date == DateTime.Today.AddDays(-1.0))
            {
                return "Added Yesterday";
            }
            return string.Format("Added on {0}", date.ToLongDateString());
        }

        public Inset getMargin(int Index)
        {
            int num = this.SelectedIndex - Index;
            if (Math.Abs(num) > 1)
            {
                return new Inset(-15, 0, -15, 0);
            }
            return new Inset(0, 0, 0, 0);
        }

        public float getPosition(int Index)
        {
            int num = this.SelectedIndex - Index;
            if (Math.Abs(num) > 1)
            {
                return (float) (60 * num);
            }
            return 0f;
        }

        public bool getProperty(string propertyname)
        {
            return this.ShowOverview;
        }

        public Rotation getRotation(int Index)
        {
            int num = this.SelectedIndex - Index;
            Rotation rotation = new Rotation();
            if (Math.Abs(num) > 4)
            {
                rotation.AngleDegrees = 60;
                rotation.Axis = new Vector3(0f, 1f, 1f);
                if (num < 0)
                {
                    rotation.AngleDegrees = -rotation.AngleDegrees;
                }
                return rotation;
            }
            if (Math.Abs(num) > 1)
            {
                rotation.AngleDegrees = 0;
                if (num < 0)
                {
                    rotation.AngleDegrees = -rotation.AngleDegrees;
                }
                rotation.Axis = new Vector3(0f, 1f, 0f);
                return rotation;
            }
            rotation.AngleDegrees = 0;
            rotation.Axis = new Vector3(0f, 1f, 0f);
            return rotation;
        }

        public Vector3 getScale(int Index)
        {
            int num = this.SelectedIndex - Index;
            float num2 = Math.Abs(num);
            if (num2 > 7f)
            {
                return new Vector3(0.2f, 0.2f, 0.2f);
            }
            return new Vector3((10f - num2) / 10f, (10f - num2) / 10f, (10f - num2) / 10f);
        }

        public void setupHelper()
        {
            this.SelectedIndex = 0;
            this.Config = new MyConfig();
            this.ShowOverview = false;
            this.OverviewTimer.AutoRepeat = false;
            this.OverviewTimer.Interval = 0x7d0;
            this.OverviewTimer.Tick += delegate {
                if ((((this.CurrentItem.Overview != "") && !this.ShowOverview) && ((this.CurrentItem.ItemTypeString != "Season") && (this.CurrentItem.ItemTypeString != "Album"))) && (((this.CurrentItem.ItemTypeString != "ArtistAlbum") && (this.CurrentItem.ItemTypeString != "Folder")) && (this.CurrentItem.ItemTypeString != "MusicFolder")))
                {
                    this.ShowOverview = true;
                }
                this.NavCount = 0;
            };
        }

        public string LayoutRoot { get { return "resx://Chocolate/Chocolate.Resources/LayoutRoot#LayoutRoot"; } }
        public string LayoutSeries { get { return "resx://Chocolate/Chocolate.Resources/LayoutSeries#ChocolateLayoutSeries"; } }
        public string LayoutCoverflow { get { return "resx://Chocolate/Chocolate.Resources/LayoutCoverflow#ChocolateLayoutCoverflow"; } }
        public string LayoutDetails { get { return "resx://Chocolate/Chocolate.Resources/LayoutDetails#ChocolateLayoutDetails"; } }
        public string LayoutPoster { get { return "resx://Chocolate/Chocolate.Resources/LayoutPoster#ChocolateLayoutPoster"; } }
        public string LayoutThumb { get { return "resx://Chocolate/Chocolate.Resources/LayoutThumb#ChocolateLayoutThumb"; } }
        public string LayoutThumbStrip { get { return "resx://Chocolate/Chocolate.Resources/LayoutThumbStrip#ChocolateLayoutThumbStrip"; } }

        public SizeRef SeasonPosterSize {get { return _seasonPosterSize; }}

        public string Album
        {
            get
            {
                string dynamicProperty = this.GetDynamicProperty("Album");
                if (dynamicProperty != null)
                {
                    return dynamicProperty;
                }
                return "";
            }
        }

        public string Artist
        {
            get
            {
                string dynamicProperty = this.GetDynamicProperty("Artist");
                if (dynamicProperty != null)
                {
                    return dynamicProperty;
                }
                return "";
            }
        }

        public string AudioBitRate
        {
            get
            {
                if (this.CurrentItem.MediaInfo.AudioBitRate == 0)
                {
                    return "";
                }
                int num = this.CurrentItem.MediaInfo.AudioBitRate / 0x3e8;
                return (num.ToString() + " " + Kernel.Instance.StringData.GetString("KBsStr"));
            }
        }

        public bool ButtonPanelHasFocus
        {
            get
            {
                return buttonPanelHasFocus;
            }
            set
            {
                buttonPanelHasFocus = value;
                base.FirePropertyChanged("ButtonPanelHasFocus");
            }
        }

        public string Company
        {
            get
            {
                string dynamicProperty = this.GetDynamicProperty("Manufacturer");
                if (dynamicProperty != null)
                {
                    return dynamicProperty;
                }
                return "";
            }
        }

        public MyConfig Config { get; set; }

        public string ConsoleReleaseYear
        {
            get
            {
                int dynamicPropertyAsInt = this.GetDynamicPropertyAsInt("ReleaseYear");
                if (dynamicPropertyAsInt != 0)
                {
                    return dynamicPropertyAsInt.ToString();
                }
                return "";
            }
        }

        public string CpuBits
        {
            get
            {
                string dynamicProperty = this.GetDynamicProperty("CPU");
                if (dynamicProperty != null)
                {
                    return dynamicProperty;
                }
                return "";
            }
        }

        public Image CurrentBackdrop
        {
            get
            {
                return currentBackdrop;
            }
            set
            {
                currentBackdrop = value;
            }
        }

        public FolderModel CurrentFolder
        {
            get
            {
                return MediaBrowser.Application.CurrentInstance.CurrentFolder;
            }
        }

        public MediaBrowser.Library.Item CurrentItem
        {
            get
            {
                return this._currentItem;
            }
            set
            {
                this._currentItem = value;
                if (this.NavCount > 1)
                {
                    if (this.ShowOverview)
                    {
                        this.ShowOverview = false;
                    }
                    this.NavCount = 0;
                }
                this.NavCount++;
                this.OverviewTimer.Stop();
                this.OverviewTimer.Start();
                base.FirePropertyChanged("EndTime");
                base.FirePropertyChanged("CurrentItem");
                base.FirePropertyChanged("GenreString");
                base.FirePropertyChanged("PercentWatched");
                this.FireMusicChanges();
                this.FireGameChanges();
            }
        }

        public string CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
            }
        }

        public string CurrentTime
        {
            get
            {
                DateTime now = DateTime.Now;
                if (this.Config.Enable24hr)
                {
                    return now.ToString("HH:mm");
                }
                return now.ToString("h:mm");
            }
        }

        public Image DefaultBackdrop
        {
            get
            {
                return defaultBackdrop;
            }
            set
            {
                defaultBackdrop = value;
            }
        }

        public string Duration
        {
            get
            {
                string dynamicProperty = this.GetDynamicProperty("Duration");
                if (dynamicProperty != null)
                {
                    return dynamicProperty;
                }
                return "";
            }
        }

        public string EndTime
        {
            get
            {
                return this.calculateEndTime();
            }
        }

        public string EsrbRating
        {
            get
            {
                string dynamicProperty = this.GetDynamicProperty("EsrbRating");
                if (dynamicProperty != null)
                {
                    return dynamicProperty;
                }
                return "";
            }
        }

        public string GenreString
        {
            get
            {
                string genrestring = "";
                this.CurrentItem.Genres.ForEach(delegate (string item) {
                    genrestring = genrestring + item + ", ";
                });
                if (genrestring.Length > 0)
                {
                    genrestring = genrestring.Substring(0, genrestring.Length - 2);
                }
                return genrestring;
            }
        }

        public string GpuBits
        {
            get
            {
                string dynamicProperty = this.GetDynamicProperty("GPU");
                if (dynamicProperty != null)
                {
                    return dynamicProperty;
                }
                return "";
            }
        }

        public bool IsMenuOpen
        {
            get
            {
                return isMenuOpen;
            }
            set
            {
                isMenuOpen = value;
                base.FirePropertyChanged("IsMenuOpen");
            }
        }

        public bool NavigatingForward
        {
            get
            {
                return navigatingForward;
            }
            set
            {
                navigatingForward = value;
                base.FirePropertyChanged("NavigatingForward");
            }
        }

        public float PercentWatched
        {
            get
            {
                return this.calculatePercentWatched();
            }
        }

        public string Players
        {
            get
            {
                string dynamicProperty = this.GetDynamicProperty("Players");
                if (dynamicProperty != null)
                {
                    return dynamicProperty;
                }
                return "";
            }
        }

        public string ProductionYear
        {
            get
            {
                string dynamicProperty = this.GetDynamicProperty("ProductionYear");
                if (dynamicProperty != null)
                {
                    return dynamicProperty;
                }
                return "";
            }
        }

        public string Resolution
        {
            get
            {
                if ((this.CurrentItem.MediaInfo.Width != 0) && (this.CurrentItem.MediaInfo.Height != 0))
                {
                    return (this.CurrentItem.MediaInfo.Width.ToString() + "x" + this.CurrentItem.MediaInfo.Height.ToString());
                }
                return "";
            }
        }

        public int SelectedIndex { get; set; }

        public bool ShowBackdrop
        {
            get
            {
                if (MediaBrowser.Application.CurrentInstance.Config.ShowBackdrop)
                {
                    if (this.CurrentFolder.DisplayPrefs.UseBackdrop.Value && (this.CurrentPage == "Page"))
                    {
                        return true;
                    }
                    if (this.CurrentPage == "DetailsPage")
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool ShowOverview
        {
            get
            {
                return this._showOverveiew;
            }
            set
            {
                this._showOverveiew = value;
                base.FirePropertyChanged("ShowOverview");
            }
        }

        public string Subtitles
        {
            get
            {
                if (this.CurrentItem.MediaInfo.Subtitles == "")
                {
                    return "";
                }
                return this.CurrentItem.MediaInfo.Subtitles;
            }
        }

        public float TgdbRating
        {
            get
            {
                float dynamicPropertyAsSingle = this.GetDynamicPropertyAsSingle("TgdbRating");
                if (dynamicPropertyAsSingle > 0f)
                {
                    return dynamicPropertyAsSingle;
                }
                return 0f;
            }
        }

        public string VideoBitRate
        {
            get
            {
                if (this.CurrentItem.MediaInfo.VideoBitRate == 0)
                {
                    return "";
                }
                int num = this.CurrentItem.MediaInfo.VideoBitRate / 0x3e8;
                return (num.ToString() + " " + Kernel.Instance.StringData.GetString("KBsStr"));
            }
        }

        #region Prevent Quit from EHS
        public void AskToQuit()
        {
            Async.Queue("Exit confirmation", () =>
                                                 {
                                                     if (MediaBrowser.Application.CurrentInstance.YesNoBox(LocalizedStrings.Instance.GetString("ConfirmExit")) == "Y")
                                                     {
                                                         MediaBrowser.Application.CurrentInstance.BackOut();
                                                     }

                                                 });


        }
        #endregion
    }
}

