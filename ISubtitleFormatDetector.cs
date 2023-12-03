using OpenSubtitles.Enums;

namespace OpenSubtitles
{
    public interface ISubtitleFormatDetector
    {
        SubtitleFormat DetectFormat(string filePath);
    }
}

