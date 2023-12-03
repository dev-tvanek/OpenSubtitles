using OpenSubtitles.Enums;

namespace OpenSubtitles.Detectors
{
    public class VttFormatDetector : SubtitleFormatDetector
    {
        public override SubtitleFormat DetectFormat(string filePath)
        {
            // Implementace detekce pro VTT
            return SubtitleFormat.VTT;
        }
    }
}


