using System.Text;

namespace OpenSubtitles.Helper
{
    public interface IEncodingRecognizer
    {
        Encoding DetectEncoding(string filePath);
    }
}

