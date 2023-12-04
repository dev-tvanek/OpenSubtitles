using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSubtitles
{
    public interface ISubtitleParser
    {
        List<SubtitleBlock> Parse(string filePath);
    }
}
