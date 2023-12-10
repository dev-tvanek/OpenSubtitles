using System;
using System.IO;
using System.Text.RegularExpressions;
using OpenSubtitles.FileFormat.Enum;

namespace OpenSubtitles.FileFormat
{
    public class IdentifySubtitleSyntax
    {
        public static bool IsValidSyntax(string filePath, SubtitleFormat format)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("Cesta k souboru je prázdná nebo null.", nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Soubor '{filePath}' nebyl nalezen.");
            }

            try
            {
                string fileContent = File.ReadAllText(filePath);

                switch (format)
                {
                    case SubtitleFormat.SRT:
                        return IsValidSrtSyntax(fileContent);
                    // Přidat další případy pro další formáty
                    default:
                        throw new NotSupportedException($"Formát {format} není v tuto chvíli podporován.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Chyba při čtení souboru: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Obecná chyba: {ex.Message}");
                throw;
            }
        }

        private static bool IsValidSrtSyntax(string content)
        {
            var srtPattern = @"^\d+\s+\d{2}:\d{2}:\d{2},\d{3} --> \d{2}:\d{2}:\d{2},\d{3}\s+.*$";
            var regex = new Regex(srtPattern, RegexOptions.Multiline);

            return regex.IsMatch(content);
        }
    }
}


