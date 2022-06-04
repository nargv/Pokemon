namespace Pokemon.DataModels.Dao
{
    public class TranslationDao
    {
        public ContentDao Contents { get; set; }
    }

    public class ContentDao
    {
        public string Translated { get; set; }

        public string Text { get; set; }

        public string Translation { get; set; }
    }
}
