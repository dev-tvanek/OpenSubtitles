using System;
using System.Collections.Generic;

namespace OpenSubtitles.FileStruct
{
    /// <summary>
    /// Třída SubtitleBlock reprezentuje jeden blok titulků.
    /// Obsahuje vlastnosti pro různé formáty titulků, jako jsou SRT, ASS a VTT.
    /// </summary>
    public class SubtitleBlock
    {
        // Základní vlastnosti pro všechny formáty titulků

        /// <summary>
        /// Jedinečný identifikátor bloku titulků.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Časové razítko začátku titulku.
        /// </summary>
        public TimeSpan? StartTime { get; set; }

        /// <summary>
        /// Časové razítko konce titulku.
        /// </summary>
        public TimeSpan? EndTime { get; set; }

        /// <summary>
        /// Text titulku rozdělený do jednotlivých řádků.
        /// </summary>
        public List<string> Lines { get; set; }

        // Specifické vlastnosti pro formát ASS

        /// <summary>
        /// Styl formátování titulku (specifické pro ASS).
        /// </summary>
        public string? Style { get; set; }

        /// <summary>
        /// Jméno herce nebo postavy, která mluví (specifické pro ASS).
        /// </summary>
        public string? Actor { get; set; }

        /// <summary>
        /// Levý okraj titulku (specifické pro ASS).
        /// </summary>
        public string? MarginL { get; set; }

        /// <summary>
        /// Pravý okraj titulku (specifické pro ASS).
        /// </summary>
        public string? MarginR { get; set; }

        /// <summary>
        /// Vertikální okraj titulku (specifické pro ASS).
        /// </summary>
        public string? MarginV { get; set; }

        /// <summary>
        /// Speciální efekty (specifické pro ASS).
        /// </summary>
        public string? Effect { get; set; }

        // Specifické vlastnosti pro formát VTT

        /// <summary>
        /// Hlas, který mluví v titulku (specifické pro VTT).
        /// </summary>
        public string? Voice { get; set; }

        /// <summary>
        /// Pozice titulku na obrazovce (specifické pro VTT).
        /// </summary>
        public string? Position { get; set; }

        /// <summary>
        /// Zarovnání titulku (specifické pro VTT).
        /// </summary>
        public string? Align { get; set; }

        /// <summary>
        /// Velikost titulku (specifické pro VTT).
        /// </summary>
        public string? Size { get; set; }

        /// <summary>
        /// Konstruktor třídy SubtitleBlock inicializuje seznam řádků titulku.
        /// </summary>
        public SubtitleBlock()
        {
            Lines = new List<string>();
        }

    }
}
