using System;
using System.IO;
using System.Collections.Generic;

namespace OpenSubtitles
{
    #region Enums
    // Definuje výčtový typ pro různé podporované formáty titulkových souborů a pro neznámý formát.
    public enum SubtitleFormat
    {
        SRT,
        ASS,
        VTT,
        Unknown
    }
    #endregion

    #region Interfaces
    // Rozhraní pro detektor formátu titulků. Každý konkrétní detektor formátu musí implementovat tuto metodu.
    public interface ISubtitleFormatDetector
    {
        SubtitleFormat DetectFormat(string filePath);
    }
    #endregion

    #region Factory Class
    // Statická třída fungující jako továrna, která spravuje různé detektory formátů.
    public static class SubtitleFormatDetectorFactory
    {
        // Slovník pro ukládání detektorů s klíčem reprezentujícím příponu souboru a hodnotou jako detektor.
        private static Dictionary<string, ISubtitleFormatDetector> detectors = new Dictionary<string, ISubtitleFormatDetector>();

        // Metoda pro registraci nového detektoru. Přidá detektor do slovníku.
        public static void RegisterDetector(string extension, ISubtitleFormatDetector detector)
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

        // Metoda pro detekci formátu titulků. Vrátí formát titulků na základě přípony souboru.
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
                // Zde můžete logovat výjimku nebo provádět další akce
                throw new ApplicationException($"Došlo k chybě při detekci formátu souboru '{filePath}': {ex.Message}", ex);
            }
        }
    }
    #endregion
}

