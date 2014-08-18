namespace Chocolate
{
    using MediaBrowser.Library.Localization;
    using MediaBrowser.Library.Logging;
    using MediaBrowser.Library.Persistance;
    using System;
    using System.IO;

    [Serializable]
    public class MyStrings : LocalizedStringData
    {
        public string ACTOR = "ACTOR";
        public string Cast = "Cast...";
        public string Scenes = "Scenes...";
        public string Album = "Album";
        public string AlwaysShowPoster = "Always Show Poster";
        public string AlwaysShowPosterDesc = "When using non-widescreen displays, posters are disabled in some screens, enabling this option forces them on.";
        public string Artist = "Artist";
        public string AUDIO = "AUDIO";
        public string BACKDROP = "BACKDROP";
        public string BackdropFill = "Fill Backdrop";
        public string BackdropFit = "Fit Backdrop";
        public string BackdropStretch = "Stretch Backdrop";
        public string BANNERS = "BANNERS";
        public string ChocolateOptionsDesc = "Options for the Chocolate Theme.";
        public string CLOSE = "CLOSE";
        public string Company = "Company";
        public string CONFIG = "CONFIG";
        public string COVERFLOW = "COVERFLOW";
        public string CPU = "CPU";
        public string DATE = "DATE";
        public string DECREASESIZE = "- SIZE";
        public string Director = "Director";
        public string DIRECTOR = "DIRECTOR";
        public string DisableEHSMovieTitle = "Show Selected Title";
        public string DisableEHSMovieTitleDesc = "This Option Will Show Item Title On EHS";
        public string Duration = "Duration";
        public string Enable24hr = "Use 24 Hour Format";
        public string Enable24hrDesc = "Clock and End Time use 24 hour format.";
        public string EnableEHSBackdrop = "Show Recent Items Backdrops";
        public string EnableEHSBackdropDesc = "The backdrop on the EHS rotates through the backdrops from the recent items of the currently selected folder.";
        public string EnableFolderBackdrop = "Folder Backdrop";
        public string EnableFolderBackdropDesc = "Adds Folder Backdrop tier between Fan Art and Initial Folder Background.";
        public string EnableStripBackdrop = "Strip Backdrop";
        public string EnableStripBackdropDesc = "The backdrop in Strip view slides back and fourth with navigation.";
        public string EnableVideoBackdrop = "Show Video Backdrop *";
        public string EnableVideoBackdropDesc = "Replace backdrop image with currently playing video. This Won't Take Effect Until Media Browser Restarted.";
        public string Ends = "Ends";
        public string ENDS = "ENDS";
        public string Episodes = "Episodes";
        public string FILTER = "FILTER";
        public string INDEX = "INDEX";
        public string GENRE = "GENRE";
        public string Genres = "Genres";
        public string GPU = "GPU";
        public string INCREASESIZE = "+ SIZE";
        public string LABELS = "LABELS";
        public string Latest = "Latest";
        public string LIST = "LIST";
        public string MaintainBackdropAR = "Backdrop Position";
        public string MaintainBackdropARDesc = "Stretch recommended for non-widescreen backdrops.";
        public string NAME = "NAME";
        public string NONE = "NONE";
        public string NPVAR = "NPV Scale";
        public string NPVARDesc = "Set NPV to Double or Triple Normal Size.";
        public string PLAYALL = "PLAY ALL";
        public string Players = "Players";
        public string PLAYRANDOM = "PLAY RANDOM";
        public string PLAYUNWATCHED = "PLAY UNWATCHED";
        public string POSTER = "POSTER";
        public string QUEUEALL = "QUEUE ALL";
        public string RATING = "RATING";
        public string Released = "Released";
        public string RESO = "RESO";
        public string Runs = "Runs";
        public string RUNS = "RUNS";
        public string RUNTIME = "RUNTIME";
        public string Seasons = "Seasons";
        public string ShowConfig = "Show Config Button";
        public string ShowConfigDesc = "Show config button on all levels of media browser";
        public string ShowCoverFlowDetails = "Show Details";
        public string ShowCoverFlowDetailsDesc = "Show Details for selected item within coverflow.";
        public string ShowCoverflowPosterOverlay = "Show Poster Floor";
        public string ShowCoverflowPosterOverlayDesc = "This Option Will Show a 'Floor' Under the Posters in Coverflow";
        public string ShowCoverFlowTitle = "Show Item Title In Cover Flow";
        public string ShowCoverFlowTitleDesc = "This Option will show title display in coverflow";
        public string ShowCoverflowTotalNumber = "Show Total Number";
        public string ShowCoverflowTotalNumberDesc = "This Option Will Show The Total Number Of Items Within Coverflow View";
        public string ShowListBackground = "Show List Background";
        public string ShowListBackgroundDesc = "Show A Dark Background Under the List.  Should only be needed in odd screen size situations.";
        public string ShowInfoIcons = "Show Info Icons";
        public string ShowLegend = "Show Shortcut Legend";
        public string ShowLegendDesc = "Show A Legend of Available Shortcuts when config menu is in focus";
        public string ShowInfoIconsBackgrounds = "Show Info Icon Background";
        public string ShowInfoIconsBackgroundsDesc = "Adds semi-transparent background to Info Icons.";
        public string ShowInfoIconsDesc = "Displays Media Info Icons in various views.";
        public string ShowLogosOnMovieDetail = "Show Logos";
        public string ShowDiscDetail = "Show Disc Image";
        public string ShowDiscDetailDesc = "Show A Disc Image on Top of Poster in Detail View";
        public string ShowLogosOnMovieDetailDesc = "Display a Logo Image, If There Is One Available, on the Movie Detail Screen";
        public string ShowNowPlayingIcon = "Show Now Playing Icon";
        public string ShowNowPlayingIconDesc = "Display Now Playing Icon on the detail page";
        public string ShowNPV = "Show Small NPV";
        public string ShowNPVDesc = "Display small NPV on the detail page";
        public string ShowPosterEndTime = "Show End Time";
        public string ShowPosterEndTimeDesc = "This Option Will Show End Time On Poster View.";
        public string ShowPosterLogos = "Show Logos";
        public string ShowPosterLogosDesc = "Show Logos On Poster View.";
        public string ShowPosterInfo = "Show Info Box";
        public string ShowPosterInfoDesc = "Show An Information Box for the Selected Item in Poster View.";
        public string ShowStripLogos = "Show Logos";
        public string ShowStripLogosDesc = "Show Logos On Strip View.";
        public string ShowEndTime = "Show End Time";
        public string ShowEndTimeDesc = "Show the time the currently selected item will end if started now.";
        public string ShowLogos = "Show Logos";
        public string ShowLogosDesc = "Show Item Logos in This View.";
        public string ShowWeather = "Show Weather Panel";
        public string ShowWeatherDesc = "Show Weather Information on EHS.  Requires configuration on server.";
        public string UseCustomTvView = "Use Custom View for Series";
        public string UseCustomTvViewDesc = "Show TV Series in a special view that shows all seasons and episodes on one screen";
        public string SmallEhs = "Smaller Recent List Images";
        public string SmallEhsDesc = "Show slightly smaller images in the Recent List on EHS.";
        public string SpecialFeatures = "Specials...";
        public string SORT = "SORT";
        public string STRIP = "STRIP";
        public string StripviewExpandedDesc = "Set whether the Strip view will be expanded by default.";
        public string STUDIO = "STUDIO";
        public string SUBTITLES = "SUBTITLES : ";
        public string SubsDetail = "Subs: ";
        public string Synopsis = "Synopsis";
        public string ThemeCustomFont = "* Choose theme font style";
        public string ThemeCustomFontDesc = "Chose which font file to use with the theme. This Won't Take Effect Until Media Browser Restarted.";
        public string THUMB = "THUMB";
        public string Unwatched = "Unwatched";
        public string UNWATCHED = "UNWATCHED";
        public string UseSeasonPoster = "Use Season Poster in Recent List";
        public string UseSeasonPosterDesc = "Replace episode thumbs with season posters on the EHS (Enhanced Home Screen).";
        private const string VERSION = "1.0001";
        public string VERTSCROLL = "VERT SCROLL";
        public string VIDEO = "VIDEO";
        public string VIEW = "VIEW";
        public string Watched = "Watched";
        public string Year = "Year";
        public string YEAR = "YEAR";
        public string ConfirmExit = "Are you sure you wish to exit?";
        public string InProgressEHS = "In-Progress";

        public static MyStrings FromFile(string file)
        {
            MyStrings strings = new MyStrings();
            XmlSettings<MyStrings>.Bind(strings, file);
            Logger.ReportInfo("Using String Data from " + file);
            Logger.ReportInfo("****Version is: {0}",strings.Version);
            if ("1.0001" != strings.Version)
            {
                File.Delete(file);
                strings = new MyStrings();
                XmlSettings<MyStrings>.Bind(strings, file);
            }
            return strings;
        }
    }
}

