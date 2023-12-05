using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSubtitles
{
    public abstract class SubtitleParserBase : ISubtitleParser
    {
        public abstract List<SubtitleBlockBase> Parse(string filePath);

        protected virtual string ProcessHtmlTags(string input)
        {
            return input;
        }

    }
}
