namespace Pokemon.Models
{
    public class Translation
    {
        public Content Contents { get; set; }
    }

    public class Content
    {
        public string Translated { get; set; }

        public string Text { get; set; }

        public string Translation { get; set; }
    }
}
