using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaBrowser.Library;
using MediaBrowser.Library.Entities;
using MediaBrowser.Library.Threading;

namespace Chocolate.ModelItems
{
    class WholeSeriesFolderModel : FolderModel
    {
        public static bool IsOne(BaseItem item)
        {
            return !(item is Season) && item is Series;
        }

        public override void NavigatingInto()
        {
            base.NavigatingInto();
            Async.Queue("Series Whole Child Load", () =>
            {
                //trickle down to all our seasons - first load all children at base item level
                foreach (var child in Folder.Children.OfType<Season>())
                {
                    child.ReloadChildren();
                }

            },50);
        }
    }
}
