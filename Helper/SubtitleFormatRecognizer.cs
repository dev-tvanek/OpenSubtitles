using System;
using System.IO;
using OpenSubtitles.Format;

namespace OpenSubtitles.Helper
{
    /// <summary>
    /// Třída SubtitleFormatRecognizer implementuje rozhraní ISubtitleFormatRecognizer.
    /// Jejím hlavním úkolem je rozpoznat formát souboru s titulky na základě jeho přípony.
    /// </summary>
    public class SubtitleFormatRecognizer : ISubtitleFormatRecognizer
    {
        /// <summary>
        /// Rozpozná formát souboru s titulky na základě jeho přípony.
        /// </summary>
        /// <param name="filePath">Cesta k souboru, jehož formát se má rozpoznat.</param>
        /// <returns>Vrátí člen výčtu SubtitleFormat odpovídající rozpoznanému formátu.</returns>
        public SubtitleFormat RecognizeFormat(string filePath)
        {
            // Získání přípony souboru a její konverze na malá písmena pro konzistenci
            var fileExtension = Path.GetExtension(filePath).ToLower();

            // Rozhodovací struktura pro určení formátu na základě přípony
            switch (fileExtension)
            {
                case ".srt":
                    return SubtitleFormat.SRT;
                case ".ass":
                    return SubtitleFormat.ASS;
                case ".ssa": // SSA je starší verze ASS
                    return SubtitleFormat.SSA;
                case ".vtt":
                    return SubtitleFormat.VTT;

                // Případ pro přidání dalších formátů, pokud jsou podporovány
                // Například: .sub pro MicroDVD nebo SubViewer
                default:
                    // Vrátí Unknown, pokud formát není rozpoznán
                    return SubtitleFormat.Unknown;
            }
        }
    }
}

