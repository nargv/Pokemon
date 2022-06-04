using System.Web;

namespace Pokemon.Helpers
{
    public static class UrlHelper
    {
        public static string GetTranslationPath(string type, string text)
        {
            return $"https://api.funtranslations.com/translate/{type}.json?text={HttpUtility.UrlPathEncode(text)}";
        }
    }
}
