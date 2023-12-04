using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSubtitles.Parsers
{
    public class SrtSubtitleParser : SubtitleParserBase
    {
        public override List<SubtitleBlock> Parse(string filePath)
        {
            var subtitles = new List<SubtitleBlock>();
            var lines = File.ReadAllLines(filePath);
            SubtitleBlock currentSubtitle = null;
            int lineNumber = 0;

            foreach (var line in lines)
            {
                lineNumber++;

                // Kontrola pořadového čísla titulku
                if (currentSubtitle == null && int.TryParse(line, out int subtitleNumber))
                {
                    currentSubtitle = new SubtitleBlock { OrderNumber = subtitleNumber };
                    continue;
                }

                // Kontrola časové značky
                if (currentSubtitle != null && currentSubtitle.StartTime == TimeSpan.Zero)
                {
                    var times = line.Split(new[] { " --> " }, StringSplitOptions.None);
                    currentSubtitle.StartTime = TimeSpan.Parse(times[0]);
                    currentSubtitle.EndTime = TimeSpan.Parse(times[1]);
                    continue;
                }

                // Kontrola textu titulku
                if (!string.IsNullOrWhiteSpace(line) && currentSubtitle != null)
                {
                    if (currentSubtitle.Text == null)
                        currentSubtitle.Text = line;
                    else
                        currentSubtitle.Text += "\n" + line;
                    continue;
                }

                // Konec titulku
                if (string.IsNullOrWhiteSpace(line) && currentSubtitle != null)
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
    }
}
