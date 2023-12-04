using OpenSubtitles.Parsers;
using System;
using System.IO; 

namespace OpenSubtitles
{
    public static class SubtitleParserFactory
    {
        public static ISubtitleParser GetParser(string filePath)
        {
            // Získání přípony souboru a převedení na malá písmena pro porovnání
            var extension = Path.GetExtension(filePath)?.ToLower();

            switch (extension)
            {
                case ".srt":
                    return new SrtSubtitleParser();
                case ".ass":
                    return new AssSubtitleParser();
                case ".vtt":
                    return new VttSubtitleParser();
                // Přidejte další podporované formáty
                default:
                    throw new NotSupportedException($"Formát '{extension}' není podporován.");
            }
        }
    }
}

