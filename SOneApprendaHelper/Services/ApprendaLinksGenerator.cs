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

        private readonly TextGenerator _textGenerator = new TextGenerator();

        private ApprendaLinksGenerator()
        {
            initPatterns();
        }

        public IEnumerable<ApprendaLink> GenerateApprendaLinks(ApprendaSettings settings)
        {
            return _patterns.Select(
                x => new ApprendaLink
                     {
                         Id = x.Id,
                         Name = x.Name,
                         ApprendaUrl = _textGenerator.Generate(x.Pattern, settings)
                     });
        }

        public string GenerateApprendaUrl(string id, ApprendaSettings settings)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            var pattern = _patterns.SingleOrDefault(x => x.Id == id);
            if (pattern == null)
                return null;

            return _textGenerator.Generate(pattern.Pattern, settings);
        }

        #endregion
    }
}