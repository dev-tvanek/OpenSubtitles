using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSubtitles.SubtitleBlocks
{
    public class SrtSubtitleBlock : SubtitleBlockBase
    {
        public new int OrderNumber { get; set; }
        public new TimeSpan StartTime { get; set; }
        public new TimeSpan EndTime { get; set; }
        public new string? Text { get; set; }
    }
}
