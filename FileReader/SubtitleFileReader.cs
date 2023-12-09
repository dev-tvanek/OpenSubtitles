using OpenSubtitles.Format;
using System;
using System.Collections.Generic;
using System.IO;

namespace OpenSubtitles.FileReader
{
    public class SubtitleFileReader : ISubtitleFileReader
    {
        private readonly ISubtitleFormatRecognizer formatRecognizer;

        public SubtitleFileReader(ISubtitleFormatRecognizer formatRecognizer)
        {
            this.formatRecognizer = formatRecognizer ?? throw new ArgumentNullException(nameof(formatRecognizer));
        }

        public IEnumerable<SubtitleBlock> ReadFile(string filePath)
        {
            var format = formatRecognizer.RecognizeFormat(filePath);
            var subtitleBlocks = new List<SubtitleBlock>();

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (var reader = new StreamReader(stream))
                {
                    SubtitleBlock block = null;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        switch (format)
                        {
                            case SubtitleFormat.SRT:
                                block = ProcessSrtLine(line, block);
                                break;
                            case SubtitleFormat.SSA:
                            case SubtitleFormat.ASS:
                                block = ProcessAssLine(line, block);
                                break;
                            case SubtitleFormat.VTT:
                                block = ProcessVttLine(line, block);
                                break;
                            default:
                                throw new NotSupportedException("Nepodporovaný formát titulků");
                        }

                        if (block != null)
                        {
                            subtitleBlocks.Add(block);
                            block = null;
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Chyba při čtení souboru: " + ex.Message);
            }

            return subtitleBlocks;
        }

        private SubtitleBlock ProcessSrtLine(string line, SubtitleBlock currentBlock)
        {
            // Implementace zpracování řádku pro SRT
            throw new NotImplementedException();
        }

        private SubtitleBlock ProcessAssLine(string line, SubtitleBlock currentBlock)
        {
            // Implementace zpracování řádku pro ASS
            throw new NotImplementedException();
        }

        private SubtitleBlock ProcessVttLine(string line, SubtitleBlock currentBlock)
        {
            // Implementace zpracování řádku pro VTT
            throw new NotImplementedException();
        }
    }
}



