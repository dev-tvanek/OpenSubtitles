namespace OpenSubtitles
{
    public class SubtitleBlock
    {
        public int OrderNumber { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Text { get; set; }
        // Další vlastnosti pro pokročilé formátování, například HTML značky
    }
}
