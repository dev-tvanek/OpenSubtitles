using System;
using System.IO;
using System.Text;
using UnicodeCharsetDetector;

namespace OpenSubtitles.Helper
{
    /// <summary>
    /// Třída EncodingRecognizer implementuje rozhraní IEncodingRecognizer.
    /// Jejím úkolem je detekovat kódování textových souborů, zejména souborů s titulky.
    /// </summary>
    public class EncodingRecognizer : IEncodingRecognizer
    {
        // Instanciace detektoru kódování
        private readonly UnicodeCharsetDetector.UnicodeCharsetDetector unicodeCharsetDetector = new();

        /// <summary>
        /// Detekuje kódování souboru na základě jeho obsahu.
        /// </summary>
        /// <param name="filePath">Cesta k souboru, jehož kódování má být detekováno.</param>
        /// <returns>Objekt Encoding reprezentující detekované kódování souboru.</returns>
        public Encoding DetectEncoding(string filePath)
        {
            try
            {
                // Otevření souboru pro čtení
                using var stream = File.OpenRead(filePath);
                // Použití detektoru kódování na streamu souboru
                var detectionResult = unicodeCharsetDetector.Check(stream);
                // Vrácení detekovaného kódování, nebo výchozího kódování, pokud detekce selže
                return detectionResult.ToEncoding() ?? Encoding.Default;
            }
            catch
            {
                // V případě výjimky vrátí výchozí kódování
                // Může zahrnovat logiku pro zaznamenávání chyb nebo další zpracování výjimek
                return Encoding.Default;
            }
        }
    }
}

