using OpenSubtitles.Enums;

namespace OpenSubtitles.Detectors
{
    public class SrtFormatDetector : SubtitleFormatDetector
    {
        public override SubtitleFormat DetectFormat(string filePath)
        {
            // Implementace detekce pro SRT
            return SubtitleFormat.SRT;
        }
    }
}


