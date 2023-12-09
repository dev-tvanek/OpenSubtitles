using OpenSubtitles.Format;
using OpenSubtitles.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using UnicodeCharsetDetector;

namespace OpenSubtitles.FileReader
{
    public class SubtitleFileReader : ISubtitleFileReader
    {
        private readonly ISubtitleFormatRecognizer formatRecognizer;
        private readonly IEncodingRecognizer encodingRecognizer;

        public SubtitleFileReader(ISubtitleFormatRecognizer formatRecognizer, IEncodingRecognizer encodingRecognizer)
        {
            this.formatRecognizer = formatRecognizer ?? throw new ArgumentNullException(nameof(formatRecognizer));
            this.encodingRecognizer = encodingRecognizer ?? throw new ArgumentNullException(nameof(encodingRecognizer));
        }

        public IEnumerable<SubtitleBlock> ReadFile(string filePath)
        {
            var format = formatRecognizer.RecognizeFormat(filePath);
            var encoding = encodingRecognizer.DetectEncoding(filePath);
            var subtitleBlocks = new List<SubtitleBlock>();

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (var reader = new StreamReader(stream, encoding))
                {
                    SubtitleBlock block = null;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        switch (format)
                        {
                            case SubtitleFormat.SRT:
                                block = ProcessSRTLine(line, block);
                                break;
                            case SubtitleFormat.SSA:
                                block = ProcessSSALine(line, block);
                                break;
                            case SubtitleFormat.ASS:
                                block = ProcessASSLine(line, block);
                                break;
                            case SubtitleFormat.VTT:
                                block = ProcessVTTLine(line, block);
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

        private SubtitleBlock ProcessSRTLine(string line, SubtitleBlock currentBlock)
        {
            // Implementace zpracování řádku pro SRT
            throw new NotImplementedException();
        }

        private SubtitleBlock ProcessSSALine(string line, SubtitleBlock currentBlock)
        {
            // Implementace zpracování řádku pro ASS
            throw new NotImplementedException();
        }

        private SubtitleBlock ProcessASSLine(string line, SubtitleBlock currentBlock)
        {
            // Implementace zpracování řádku pro ASS
            throw new NotImplementedException();
        }

        private SubtitleBlock ProcessVTTLine(string line, SubtitleBlock currentBlock)
        {
            // Implementace zpracování řádku pro VTT
            throw new NotImplementedException();
        }
    }
}



