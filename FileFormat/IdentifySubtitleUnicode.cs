using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicodeCharsetDetector;

namespace OpenSubtitles.FileFormat
{
    public class IdentifySubtitleUnicode
    {
        public static string DetectEncoding(string filePath)
        {
            using var stream = File.OpenRead(filePath);
            var unicodeCharsetDetector = new UnicodeCharsetDetector.UnicodeCharsetDetector();
            var charset = unicodeCharsetDetector.Check(stream);
            var encoding = charset.ToEncoding();

            return encoding?.WebName ?? "unknown";
        }
    }
}
