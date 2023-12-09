using System;
using System.IO;
using OpenSubtitles.Format;

namespace OpenSubtitles.Helper
{

    public class SubtitleFormatRecognizer : ISubtitleFormatRecognizer
    {


        public SubtitleFormat RecognizeFormat(string filePath)
        {
            var fileExtension = Path.GetExtension(filePath).ToLower();

            switch (fileExtension)
            {
                case ".srt":
                    return SubtitleFormat.SRT;
                case ".ass":
                    return SubtitleFormat.ASS;
                case ".ssa": // SSA je starší verze ASS
                    return SubtitleFormat.SSA;
                case ".vtt":
                    return SubtitleFormat.VTT;


                // Přidat další přípony pro jiné formáty
                default:
                    return SubtitleFormat.Unknown;
            }
        }
    }
}
