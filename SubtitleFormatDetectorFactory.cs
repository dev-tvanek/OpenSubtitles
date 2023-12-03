using OpenSubtitles.Enums;

namespace OpenSubtitles
{
    public static class SubtitleFormatDetectorFactory
    {
        private static Dictionary<string, SubtitleFormatDetector> detectors = new Dictionary<string, SubtitleFormatDetector>();

        public static void RegisterDetector(string extension, SubtitleFormatDetector detector)
        {
            if (string.IsNullOrWhiteSpace(extension))
            {
                throw new ArgumentException("Přípona souboru nesmí být prázdná.", nameof(extension));
            }

            if (detector == null)
            {
                throw new ArgumentNullException(nameof(detector), "Detektor nesmí být null.");
            }

            detectors[extension.ToLower()] = detector;
        }

        public static SubtitleFormat DetectFormat(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("Cesta k souboru nesmí být prázdná.", nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Soubor nebyl nalezen.", filePath);
            }

            try
            {
                string extension = Path.GetExtension(filePath).ToLower();
                if (detectors.TryGetValue(extension, out var detector))
                {
                    return detector.DetectFormat(filePath);
                }

                return SubtitleFormat.Unknown;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Došlo k chybě při detekci formátu souboru '{filePath}': {ex.Message}", ex);
            }
        }
    }
}

