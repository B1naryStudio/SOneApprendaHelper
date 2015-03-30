using SOneApprendaHelper.Models;

namespace SOneApprendaHelper.Services
{
    public class TextGenerator : ITextGenerator
    {
        public string Generate(string pattern, ApprendaSettings settings)
        {
            var host = settings.ApprendaBaseUrl.TrimEnd('/');

            return pattern.Replace("{email}", settings.ApprendaUserEmail)
                          .Replace("{uid}", settings.ApprendaUserId)
                          .Replace("{host}", host)
                          .Replace("{alias}", settings.ApplicationAlias)
                          .Replace("{aid}", settings.ApplicationId)
                          .Replace("{ver}", settings.ApplicationVersion.ToString())
                          .Replace("{vid}", settings.ApplicationVersionId)
                          .Replace("{gid}", settings.SubscriptionGroupId);
        }
    }
}