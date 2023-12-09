using OpenSubtitles.Format;

namespace OpenSubtitles
{
    public interface ISubtitleFormatRecognizer
    {
        SubtitleFormat RecognizeFormat(string filePath);
    }
}

