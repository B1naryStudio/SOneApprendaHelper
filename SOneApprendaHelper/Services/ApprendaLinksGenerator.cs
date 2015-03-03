using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SOneApprendaHelper.Models;

namespace SOneApprendaHelper.Services
{
    public class ApprendaLinksGenerator
    {
        #region Static

        private static readonly Lazy<ApprendaLinksGenerator> _instance =
            new Lazy<ApprendaLinksGenerator>(() => new ApprendaLinksGenerator());

        private static List<ApprendaLinkPattern> _patterns;

        public static ApprendaLinksGenerator Instance
        {
            get { return _instance.Value; }
        }

        private static void initPatterns()
        {
            var path = HttpContext.Current.Server.MapPath("~/App_Data/Links.json");
            var fileData = File.ReadAllText(path);
            _patterns = JsonConvert.DeserializeObject<List<ApprendaLinkPattern>>(fileData);
        }

        #endregion

        #region Instance

        private ApprendaLinksGenerator()
        {
            initPatterns();
        }

        public IEnumerable<ApprendaLink> GenerateAllLinks(ApprendaSettings settings)
        {
            return _patterns.Select(
                x => new ApprendaLink
                     {
                         Id = x.Id,
                         Name = x.Name,
                         Link = generateUrl(x.Pattern, settings)
                     });
        }

        public string GenerateUrl(string id, ApprendaSettings settings)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            var pattern = _patterns.SingleOrDefault(x => x.Id == id);
            if (pattern == null)
                return null;

            return generateUrl(pattern.Pattern, settings);
        }

        private static string generateUrl(string pattern, ApprendaSettings settings)
        {
            // Make sure that host has a '/' at the end.
            var host = settings.ApprendaBaseUrl;
            if (!string.IsNullOrEmpty(host) && host.Last() != '/')
            {
                host += '/';
            }

            return pattern.Replace("{host}", host)
                          .Replace("{alias}", settings.ApplicationAlias)
                          .Replace("{aid}", settings.ApplicationId)
                          .Replace("{ver}", settings.ApplicationVersion.ToString())
                          .Replace("{vid}", settings.ApplicationVersionId);
        }

        #endregion
    }
}