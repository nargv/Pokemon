namespace Pokemon.Helpers
{
    public static class StringHelper
    {
        public static string RemoveLineBreaks(string text)
        {
            return text.Replace("\n", " ").Replace("\f", " ");
        }
    }
}
