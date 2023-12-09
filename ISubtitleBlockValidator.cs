using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSubtitles
{
    public interface ISubtitleBlockValidator
    {
        bool IsValidTimeFormat(SubtitleBlock block);
        bool IsComplete(SubtitleBlock block);
        bool IsValid(SubtitleBlock block);
        bool HasTimeOverlaps(List<SubtitleBlock> subtitleBlocks);
    }
}
