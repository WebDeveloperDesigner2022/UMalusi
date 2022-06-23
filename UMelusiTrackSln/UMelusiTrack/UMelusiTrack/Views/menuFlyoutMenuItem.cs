using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMelusiTrack.Views
{
    public class menuFlyoutMenuItem
    {
        public menuFlyoutMenuItem()
        {
            TargetType = typeof(menuFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}