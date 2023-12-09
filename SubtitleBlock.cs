using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSubtitles
{
    public class SubtitleBlock
    {
        // Základní vlastnosti pro SRT a další formáty
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List<string> Lines { get; set; }

        // Vlastnosti specifické pro ASS
        public string Style { get; set; }
        public string Actor { get; set; }

        public string MarginL { get; set; }
        public string MarginR { get; set; }
        public string MarginV { get; set; }
        public string Effect { get; set; }

        // Vlastnosti specifické pro VTT
        public string Voice { get; set; }
        public string Position { get; set; }
        public string Align { get; set; }
        public string Size { get; set; }

        public SubtitleBlock()
        {
            Lines = new List<string>();
        }
    }
}

