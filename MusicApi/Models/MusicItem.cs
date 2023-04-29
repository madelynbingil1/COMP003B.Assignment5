namespace MusicApi.Models
{
    public class MusicItem
    {
        public long Id {get; set;}
        public string Title {get; set;}
        public string Genre { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
    }
}