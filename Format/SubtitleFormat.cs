namespace OpenSubtitles.Format
{
    /// <summary>
    /// Výčet (Enum) SubtitleFormat definuje podporované formáty titulků.
    /// Tato enumerace se používá v celé knihovně pro identifikaci a rozpoznávání různých formátů titulků.
    /// </summary>
    public enum SubtitleFormat
    {
        /// <summary>
        /// Neznámý formát. Používá se, pokud formát souboru s titulky není rozpoznán.
        /// </summary>
        Unknown,

        /// <summary>
        /// SRT (SubRip Text) - populární formát titulků, který je jednoduchý a široce podporovaný.
        /// </summary>
        SRT,

        /// <summary>
        /// SSA (SubStation Alpha) - formát používaný hlavně pro pokročilé titulky s možnostmi stylizace.
        /// </summary>
        SSA,

        /// <summary>
        /// ASS (Advanced SubStation Alpha) - vylepšená verze SSA s více možnostmi formátování.
        /// </summary>
        ASS,

        /// <summary>
        /// VTT (Web Video Text Tracks) - moderní formát titulků používaný hlavně pro web a HTML5 video.
        /// </summary>
        VTT

        // Další formáty, pokud jsou potřeba
        // Příklad: Přidání dalších formátů, jako je MicroDVD, SubViewer, atd.
    }
}


