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
        public string DisableEHSMovieTitle = "Enable Movie Title on EHS";
        public string DisableEHSMovieTitleDesc = "This Option Will Show Item Title On EHS";
        public string Duration = "Duration";
        public string Enable24hr = "Use 24 Hour Format";
        public string Enable24hrDesc = "Clock and End Time use 24 hour format.";
        public string EnableEHSBackdrop = "Recent Items Backdrops on EHS";
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
        public string ShowCoverFlowEndTime = "Show Coverflow End Time";
        public string ShowCoverFlowEndTimeDesc = "This Option Will Show End Time On Coverflow View.";
        public string ShowCoverflowIndicator = "Show Coverflow Watched Indicator";
        public string ShowCoverflowIndicatorDesc = "This Option Will Show Coverflow Watched Indicator";
        public string ShowCoverFlowLogos = "Show Coverflow Logos";
        public string ShowCoverFlowLogosDesc = "Show Logos On Coverflow View.";
        public string ShowCoverFlowOverlay = "Show Coverflow Overlay";
        public string ShowCoverFlowOverlayDesc = "This Option will show to overlay image on the backdrop within coverflow.";
        public string ShowCoverflowPosterOverlay = "Show Coverflow Poster Overlay";
        public string ShowCoverflowPosterOverlayDesc = "This Option Will Show Poster Overlay Within Coverflow";
        public string ShowCoverFlowTitle = "Show Item Title In Cover Flow";
        public string ShowCoverFlowTitleDesc = "This Option will show title display in coverflow";
        public string ShowCoverflowTotalNumber = "Show Coverflow Total Number";
        public string ShowCoverflowTotalNumberDesc = "This Option Will Show The Total Number Of Items Within Coverflow View";
        public string ShowInfoIcons = "Show Info Icons";
        public string ShowInfoIconsBackgrounds = "Show Info Icon Background";
        public string ShowInfoIconsBackgroundsDesc = "Adds semi-transparent background to Info Icons.";
        public string ShowInfoIconsDesc = "Displays Info Icons at the top of the screen when browsing media.";
        public string ShowListEndTime = "Show List End Time";
        public string ShowListEndTimeDesc = "This Option Will Show End Time On List View.";
        public string ShowListLogos = "Show List Logos";
        public string ShowListLogosDesc = "Show Logos On List View.";
        public string ShowLogosOnMovieDetail = "Show Logos In Movie Detail View";
        public string ShowLogosOnMovieDetailDesc = "This Option Will Replace The Movie Title In Movie Detail View With A Logo Image, If There Is One Available";
        public string ShowNowPlayingIcon = "Show Now Playing Icon";
        public string ShowNowPlayingIconDesc = "Display Now Playing Icon on the detail page";
        public string ShowNPV = "Show Small NPV";
        public string ShowNPVDesc = "Display small NPV on the detail page";
        public string ShowPosterEndTime = "Show Poster End Time";
        public string ShowPosterEndTimeDesc = "This Option Will Show End Time On Poster View.";
        public string ShowPosterLogos = "Show Poster Logos";
        public string ShowPosterLogosDesc = "Show Logos On Poster View.";
        public string ShowStripLogos = "Show Strip Logos";
        public string ShowStripLogosDesc = "Show Logos On Strip View.";
        public string ShowThumbEndTime = "Show Thumb End Time";
        public string ShowThumbEndTimeDesc = "This Option Will Show End Time On Thumb View.";
        public string ShowThumbLogos = "Show Thumb Logos";
        public string ShowThumbLogosDesc = "Show Logos On Thumb View.";
        public string ShowWeather = "Show Weather Panel on EHS";
        public string SmallEhs = "Smaller EHS Icons";
        public string SORT = "SORT";
        public string STRIP = "STRIP";
        public string StripviewExpandedDesc = "Set whether the Strip view will be expanded by default.";
        public string STUDIO = "STUDIO";
        public string SUBTITLES = "SUBTITLES : ";
        public string Synopsis = "Synopsis";
        public string ThemeCustomFont = "* Choose theme font style";
        public string ThemeCustomFontDesc = "Chose which font file to use with the theme. This Won't Take Effect Until Media Browser Restarted.";
        public string ThemeStyle = "Change The Theme Style";
        public string ThemeStyleDesc = "You can chose between the classic black style of chocolate or use the Blue style instead.";
        public string THUMB = "THUMB";
        public string Unwatched = "Unwatched";
        public string UNWATCHED = "UNWATCHED";
        public string UseSeasonPoster = "Use Season Poster on EHS";
        public string UseSeasonPosterDesc = "Replace episode thumbs with season posters on the EHS (Enhanced Home Screen).";
        private const string VERSION = "1.0001";
        public string VERTSCROLL = "VERT SCROLL";
        public string VIDEO = "VIDEO";
        public string VIEW = "VIEW";
        public string Watched = "Watched";
        public string Year = "Year";
        public string YEAR = "YEAR";

        public static MyStrings FromFile(string file)
        {
            MyStrings strings = new MyStrings();
            XmlSettings<MyStrings>.Bind(strings, file);
            Logger.ReportInfo("Using String Data from " + file);
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

