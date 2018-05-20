namespace WebBlazor.Models
{
    public static class UrlApi
    {
        private static string url = "http://localhost:8181/api/";
        public static string Url(string path = "")
        {
            if (!string.IsNullOrEmpty(path))
            {
                return url + path;
            }
            return url;
        }
    }
}
