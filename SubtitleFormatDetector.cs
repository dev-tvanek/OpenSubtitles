using OpenSubtitles.Enums;

namespace OpenSubtitles
{
    public abstract class SubtitleFormatDetector : ISubtitleFormatDetector
    {
        public abstract SubtitleFormat DetectFormat(string filePath);
    }
}


