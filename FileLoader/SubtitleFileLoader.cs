using System;
using System.IO;
using OpenSubtitles.FileFormat;
using OpenSubtitles.FileFormat.Enum;
using OpenSubtitles.FileParser;
using OpenSubtitles.FileStruct;

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

                //Kontrola syntaxe -- prozatím nefunkční
                //if (!IdentifySubtitleSyntax.IsValidSyntax(fileContent, Format))
                //{
                //    throw new InvalidDataException("Soubor s titulky má neplatnou syntaxi.");
                //}

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
           
            }
        }


        public void DisplaySubtitles()
        {
            if (Content == null || Content.Count == 0)
            {
                Console.WriteLine("Žádný obsah pro zobrazení. Content je null nebo prázdný.");
                return;
            }

            foreach (var block in Content)
            {
                Console.WriteLine($"ID: {block.Id}");
                Console.WriteLine($"Start: {block.StartTime}");
                Console.WriteLine($"End: {block.EndTime}");
                foreach (var line in block.Lines)
                {
                    Console.WriteLine($"Text: {line}");
                }
                Console.WriteLine(); // Prázdný řádek pro oddělení bloků
            }
        }

    }
}

