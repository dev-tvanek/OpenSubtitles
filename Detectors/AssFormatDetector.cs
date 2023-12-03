using OpenSubtitles.Enums;

namespace OpenSubtitles.Detectors
{
    public class AssFormatDetector : SubtitleFormatDetector
    {
        public override SubtitleFormat DetectFormat(string filePath)
        {
            // Implementace detekce pro ASS
            return SubtitleFormat.ASS;
        }
    }
}


