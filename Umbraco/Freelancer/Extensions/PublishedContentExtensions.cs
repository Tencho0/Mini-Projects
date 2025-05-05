namespace Freelancer.Extensions
{
    public static class PublishedContentExtensions
    {
        public static HomePage? GetHomePage(this IPublishedContent publishedContent)
        {
            return publishedContent.AncestorOrSelf<HomePage>();
        }

        public static SiteSettings? GetSiteSettings(this IPublishedContent publishedContent)
        {
            var homePage = GetHomePage(publishedContent);
            if (homePage == null)
                return null;

            return homePage.FirstChild<SiteSettings>();
        }
    }
}