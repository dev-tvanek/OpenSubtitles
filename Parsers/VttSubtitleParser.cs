using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace OpenSubtitles.Parsers
{
    public class VttSubtitleParser : SubtitleParserBase
    {
        public override List<SubtitleBlock> Parse(string filePath)
        {
            var subtitles = new List<SubtitleBlock>();
            var lines = File.ReadAllLines(filePath);
            SubtitleBlock currentSubtitle = null;

            foreach (var line in lines)
            {
                // Kontrola a zpracování časových značek
                if (line.Contains("-->"))
                {
                    var times = line.Split(new[] { " --> " }, StringSplitOptions.None);
                    currentSubtitle = new SubtitleBlock
                    {
                        StartTime = ParseVttTime(times[0].Trim()),
                        EndTime = ParseVttTime(times[1].Trim())
                    };
                }
                else if (!string.IsNullOrWhiteSpace(line) && currentSubtitle != null)
                {
                    if (currentSubtitle.Text == null)
                        currentSubtitle.Text = line;
                    else
                        currentSubtitle.Text += "\n" + line;
                }
                else if (string.IsNullOrWhiteSpace(line) && currentSubtitle != null)
                {
                    subtitles.Add(currentSubtitle);
                    currentSubtitle = null;
                }
            }

            // Přidání posledního titulku, pokud soubor nekončí prázdným řádkem
            if (currentSubtitle != null)
            {
                subtitles.Add(currentSubtitle);
            }

            return subtitles;
        }

        private TimeSpan ParseVttTime(string timeString)
        {
            // Formát času ve VTT: HH:MM:SS.MMM
            return TimeSpan.ParseExact(timeString, @"hh\:mm\:ss\.fff", CultureInfo.InvariantCulture);
        }
    }
}


