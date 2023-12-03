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
            detectors[extension.ToLower()] = detector;
        }

        // Metoda pro detekci formátu titulků. Vrátí formát titulků na základě přípony souboru.
        public static SubtitleFormat DetectFormat(string filePath)
        {
            // Získá příponu souboru a převede ji na malá písmena pro konzistenci.
            string extension = Path.GetExtension(filePath).ToLower();

            // Pokusí se najít detektor pro danou příponu a použít ho k detekci formátu.
            if (detectors.TryGetValue(extension, out var detector))
            {
                return detector.DetectFormat(filePath);
            }

            // Pokud není detektor nalezen, vrátí neznámý formát.
            return SubtitleFormat.Unknown;
        }
    }
    #endregion
}
