using System;
using System.IO;
using OpenSubtitles.FileFormat;
using OpenSubtitles.FileFormat.Enum;
using OpenSubtitles.FileParser;

namespace OpenSubtitles.FileLoader
{
    public class SubtitleFileLoader
    {
        public string FilePath { get; }
        public SubtitleFormat Format { get; private set; }
        public string Encoding { get; private set; }
        public List<SubtitleBlock> Content { get; private set; }

        public SubtitleFileLoader(string filePath)
        {
            FilePath = filePath;
            LoadFile();
        }

        private void LoadFile()
        {
            try
            {
                Format = IdentitfySubtitleFormat.IdentifyFormat(FilePath);
                Encoding = IdentifySubtitleUnicode.DetectEncoding(FilePath);

                if (Format == SubtitleFormat.Unknown || Encoding == "unknown")
                {
                    throw new InvalidOperationException("Nelze identifikovat formát nebo kódování souboru.");
                }

                var fileContent = File.ReadAllText(FilePath, System.Text.Encoding.GetEncoding(Encoding));

                switch (Format)
                {
                    case SubtitleFormat.SRT:
                        Content = SubtitleParser.ParseSrt(fileContent);
                        break;
                    // Přidat další case pro další formáty jako SSA, ASS, VTT atd.
                    default:
                        throw new NotSupportedException($"Formát {Format} není podporován.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba při načítání souboru: {ex.Message}");
                // Zde můžete přidat další zpracování výjimek, například logování
            }
        }
        public void DisplaySubtitles()
        {
            foreach (var block in Content)
            {
                Console.WriteLine($"ID: {block.Id}");
                Console.WriteLine($"Start: {block.StartTime}");
                Console.WriteLine($"End: {block.EndTime}");
                Console.WriteLine($"Text: {block.Lines[0]}");
                Console.WriteLine(); // Prázdný řádek pro oddělení bloků
            }
        }
    }
}
