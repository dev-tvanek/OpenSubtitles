using System;
using System.IO;
using System.Collections.Generic;
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

        public static bool IsValidExtension(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLower();
            return ExtensionMap.ContainsKey(extension);
        }

        public static SubtitleFormat IdentifyFormat(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("Cesta k souboru je prázdná nebo null.", nameof(filePath));
            }

            if (!IsValidExtension(filePath))
            {
                throw new NotSupportedException($"Formát souboru s příponou '{Path.GetExtension(filePath)}' není podporován.");
            }

            try
            {
                var extension = Path.GetExtension(filePath).ToLower();

                if (ExtensionMap.TryGetValue(extension, out var format))
                {
                    return format;
                }
                else
                {
                    throw new FormatException($"Nepodařilo se identifikovat formát pro příponu '{extension}'.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Chyba argumentu: {ex.Message}");
                throw;
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine($"Nepodporovaný formát: {ex.Message}");
                throw;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Chyba formátu: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Neznámá chyba: {ex.Message}");
                throw;
            }
        }
    }
}



