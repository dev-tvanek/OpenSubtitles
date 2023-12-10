using System;
using System.IO;
using System.Text;
using UnicodeCharsetDetector;

namespace OpenSubtitles.FileFormat
{
    public class IdentifySubtitleUnicode
    {
        public static string DetectEncoding(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("Cesta k souboru je prázdná nebo null.", nameof(filePath));
            }

            try
            {
                using var stream = File.OpenRead(filePath);
                var unicodeCharsetDetector = new UnicodeCharsetDetector.UnicodeCharsetDetector();
                var charset = unicodeCharsetDetector.Check(stream);
                var encoding = charset.ToEncoding();

                if (encoding == null || !IsValidEncoding(encoding))
                {
                    throw new InvalidDataException($"Detekované kódování '{encoding?.WebName ?? "null"}' není platné Unicode nebo ASCII kódování.");
                }

                return encoding.WebName;
            }
            catch
            {
                return "unknown";
            }
            // ... Zbytek výjimek ...
        }

        private static bool IsValidEncoding(Encoding encoding)
        {
            return IsValidUnicodeEncoding(encoding) || encoding.Equals(Encoding.ASCII);
        }

        private static bool IsValidUnicodeEncoding(Encoding encoding)
        {
            return encoding.Equals(Encoding.UTF8) || encoding.Equals(Encoding.Unicode) || encoding.Equals(Encoding.UTF32) || encoding.Equals(Encoding.BigEndianUnicode);
        }
    }
}



