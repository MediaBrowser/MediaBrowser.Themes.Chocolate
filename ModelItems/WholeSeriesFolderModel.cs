using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaBrowser.Library;
using MediaBrowser.Library.Entities;

namespace Chocolate.ModelItems
{
    class WholeSeriesFolderModel : FolderModel
    {
        public static bool IsOne(BaseItem item)
        {
            return item is Series;
        }

        public override void NavigatingInto()
        {
            base.NavigatingInto();
            var ignore = UnwatchedCount;
            //trickle down to all our seasons
            foreach (var child in Children.OfType<FolderModel>())
            {
                child.NavigatingInto();
                ignore = child.UnwatchedCount;
            }
        }
    }
}
