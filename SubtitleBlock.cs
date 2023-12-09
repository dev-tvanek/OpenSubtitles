using System;
using System.Collections.Generic;

namespace OpenSubtitles
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
        public int Id { get; set; }

        /// <summary>
        /// Časové razítko začátku titulku.
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// Časové razítko konce titulku.
        /// </summary>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// Text titulku rozdělený do jednotlivých řádků.
        /// </summary>
        public List<string> Lines { get; set; }

        // Specifické vlastnosti pro formát ASS

        /// <summary>
        /// Styl formátování titulku (specifické pro ASS).
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// Jméno herce nebo postavy, která mluví (specifické pro ASS).
        /// </summary>
        public string Actor { get; set; }

        /// <summary>
        /// Levý okraj titulku (specifické pro ASS).
        /// </summary>
        public string MarginL { get; set; }

        /// <summary>
        /// Pravý okraj titulku (specifické pro ASS).
        /// </summary>
        public string MarginR { get; set; }

        /// <summary>
        /// Vertikální okraj titulku (specifické pro ASS).
        /// </summary>
        public string MarginV { get; set; }

        /// <summary>
        /// Speciální efekty (specifické pro ASS).
        /// </summary>
        public string Effect { get; set; }

        // Specifické vlastnosti pro formát VTT

        /// <summary>
        /// Hlas, který mluví v titulku (specifické pro VTT).
        /// </summary>
        public string Voice { get; set; }

        /// <summary>
        /// Pozice titulku na obrazovce (specifické pro VTT).
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Zarovnání titulku (specifické pro VTT).
        /// </summary>
        public string Align { get; set; }

        /// <summary>
        /// Velikost titulku (specifické pro VTT).
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Konstruktor třídy SubtitleBlock inicializuje seznam řádků titulku.
        /// </summary>
        public SubtitleBlock()
        {
            Lines = new List<string>();
        }

        // Metoda pro kontrolu správnosti formátu času (čitelnost a vyhledatelnost)
        public bool IsValidTimeFormat()
        {
            // Zde můžete přidat logiku pro kontrolu, zda StartTime a EndTime jsou v platném formátu
            // Například: StartTime by měl být menší než EndTime, a oba by měli být nenulové
            return StartTime < EndTime && StartTime.TotalMilliseconds >= 0 && EndTime.TotalMilliseconds >= 0;
        }

        // Metoda pro kontrolu celistvosti bloku (všechny potřebné informace jsou přítomny)
        public bool IsComplete()
        {
            // Zde můžete přidat logiku pro kontrolu, zda všechny potřebné informace jsou přítomny
            // Například: kontrola, zda Id, StartTime, EndTime a Lines nejsou prázdné nebo nulové
            return Id >= 0 && IsValidTimeFormat() && Lines.Any();
        }

        // Metoda pro kontrolu celkové správnosti bloku
        public bool IsValid()
        {
            // Tato metoda může kombinovat všechny výše uvedené kontroly
            // Můžete také přidat další kontroly specifické pro formát titulků, jako jsou ASS nebo VTT
            return IsComplete() && Lines.All(line => IsValidLine(line));
        }

        // Metoda pro kontrolu jednotlivých řádků titulků
        private bool IsValidLine(string line)
        {
            // Implementace závisí na vašich specifických požadavcích
            // Můžete například zkontrolovat, zda řádek neobsahuje neplatné znaky nebo je v nesprávném formátu
            return !string.IsNullOrEmpty(line) && line.Length <= 100; // Příklad: řádky by neměly být prázdné a měly by být omezené délkou
        }

    }
}
