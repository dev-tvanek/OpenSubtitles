using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OpenSubtitles.FileParser
{
    internal class SubtitleParser
    {
        public static List<SubtitleBlock> ParseSrt(string srtContent)
        {
            var subtitleBlocks = new List<SubtitleBlock>();
            var blocks = Regex.Split(srtContent.Trim(), @"\r?\n\r?\n");

            foreach (var block in blocks)
            {
                var lines = block.Split('\n');
                var timecodes = lines[1].Split(new string[] { " --> " }, StringSplitOptions.None);
                var startTime = TimeSpan.Parse(timecodes[0]);
                var endTime = TimeSpan.Parse(timecodes[1]);

                SubtitleBlock subtitleBlock = new SubtitleBlock
                {
                    Id = int.Parse(lines[0]),
                    StartTime = startTime,
                    EndTime = endTime,
                    Lines = new List<string>(lines[2..])
                };

                subtitleBlocks.Add(subtitleBlock);
            }

            return subtitleBlocks;
        }
       

    }
}
