using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicodeCharsetDetector;

namespace OpenSubtitles.Helper
{
    public class EncodingRecognizer : IEncodingRecognizer
    {
        private readonly UnicodeCharsetDetector.UnicodeCharsetDetector unicodeCharsetDetector = new();

        public Encoding DetectEncoding(string filePath)
        {
            try
            {
                using var stream = File.OpenRead(filePath);
                var detectionResult = unicodeCharsetDetector.Check(stream);
                return detectionResult.ToEncoding() ?? Encoding.Default;
            }
            catch
            {
                // Logika pro zpracování výjimek nebo vrácení výchozího kódování
                return Encoding.Default;
            }
        }

    }
}
