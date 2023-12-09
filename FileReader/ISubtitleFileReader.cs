using System.Collections.Generic;

namespace OpenSubtitles.FileReader
{
    public interface ISubtitleFileReader
    {
        IEnumerable<SubtitleBlock> ReadFile(string filePath);
    }
}

