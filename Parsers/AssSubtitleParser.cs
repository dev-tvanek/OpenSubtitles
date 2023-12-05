using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace OpenSubtitles.Parsers
{
    public class AssSubtitleParser : SubtitleParserBase
    {
        public override List<SubtitleBlockBase> Parse(string filePath)
        {
            var subtitles = new List<SubtitleBlockBase>();
            var lines = File.ReadAllLines(filePath);
            bool isEventsSection = false;

            foreach (var line in lines)
            {
                // Kontrola, zda jsme v sekci událostí (Events)
                if (line.StartsWith("[Events]"))
                {
                    isEventsSection = true;
                    continue;
                }

                // Parsování titulků v sekci událostí
                if (isEventsSection && line.StartsWith("Dialogue:"))
                {
                    var subtitle = ParseDialogueLine(line);
                    if (subtitle != null)
                    {
                        subtitles.Add(subtitle);
                    }
                }
            }

            return subtitles;
        }

        private SubtitleBlockBase ParseDialogueLine(string line)
        {
            // ASS Dialogue line format: Dialogue: Layer, Start, End, Style, Name, MarginL, MarginR, MarginV, Effect, Text
            var parts = line.Split(',');

            if (parts.Length < 10)
            {
                return null; // Neplatný formát řádku
            }

            var startTime = ParseAssTime(parts[1].Trim());
            var endTime = ParseAssTime(parts[2].Trim());
            var text = string.Join(",", parts.Skip(9)); // Text může obsahovat další čárky

            return new SubtitleBlockBase
            {
                StartTime = startTime,
                EndTime = endTime,
                Text = ProcessHtmlTags(text) // Předpokládá se, že HTML značky mohou být v textu
            };
        }

        private TimeSpan ParseAssTime(string timeString)
        {
            // Formát času v ASS: h:mm:ss.cc (hodiny:minuty:sekundy.centisekundy)
            var parts = timeString.Split(':');
            var hours = int.Parse(parts[0]);
            var minutes = int.Parse(parts[1]);
            var seconds = int.Parse(parts[2].Split('.')[0]);
            var centiseconds = int.Parse(parts[2].Split('.')[1]);

            return new TimeSpan(0, hours, minutes, seconds, centiseconds * 10);
        }
    }
}

