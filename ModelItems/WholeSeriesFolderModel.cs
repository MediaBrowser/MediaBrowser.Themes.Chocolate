using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaBrowser.Library;
using MediaBrowser.Library.Entities;
using MediaBrowser.Library.Threading;

namespace Chocolate
{
    public class WholeSeriesFolderModel : FolderModel
    {
        public static bool IsOne(BaseItem item)
        {
            return !(item is Season) && item is Series;
        }

        /// <summary>
        /// Refresh all our children when our unwatched value changes
        /// </summary>
        public void UnwatchedChanged()
        {
            RefreshAllSeasons();
        }

        public override void NavigatingInto()
        {
            base.NavigatingInto();
            FilterUnwatched = PhysicalParent.FilterUnwatched;
            RefreshAllSeasons();
        }

        protected void RefreshAllSeasons()
        {
            Async.Queue("Series Whole Child Load", () =>
            {
                //trickle down to all our seasons
                foreach (var child in Children.OfType<FolderModel>().Where(f => f.Folder is Season))
                {
                    child.Folder.SetFilterUnWatched(FilterUnwatched);
                    child.NavigatingInto();
                    child.RefreshChildren();
                }

            },50);
            
        }
    }
}
