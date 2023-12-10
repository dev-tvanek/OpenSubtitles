

using OpenSubtitles.FileFormat.Enum;

namespace OpenSubtitles.FileFormat
{
    public class IdentitfySubtitleFormat
    {
        private static readonly Dictionary<string, SubtitleFormat> ExtensionMap = new Dictionary<string, SubtitleFormat>
        {
            { ".srt", Enum.SubtitleFormat.SRT },
            { ".ssa", Enum.SubtitleFormat.SSA },
            { ".ass", Enum.SubtitleFormat.ASS },
            { ".vtt", Enum.SubtitleFormat.VTT }
            // zde je místo pro další formáty
        };

        public static SubtitleFormat IdentifyFormat(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new ArgumentException("Cesta k souboru je prázdná nebo null.", nameof(filePath));
                }

                var extension = Path.GetExtension(filePath).ToLower();

                if (ExtensionMap.TryGetValue(extension, out var format))
                {
                    return format;
                }
                else
                {
                    return SubtitleFormat.Unknown;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Došlo k chybě: {ex.Message}");
                return SubtitleFormat.Unknown;
            }
        }

    }
}
