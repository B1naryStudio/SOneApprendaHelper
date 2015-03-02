using System;
using System.Collections.Generic;
using System.Linq;
using SOneApprendaHelper.Models;

namespace SOneApprendaHelper.Services
{
    public class ApprendaLinksGenerator
    {
        #region Singlton

        private static readonly Lazy<ApprendaLinksGenerator> _instance =
            new Lazy<ApprendaLinksGenerator>(() => new ApprendaLinksGenerator());

        private ApprendaLinksGenerator()
        {
        }

        public static ApprendaLinksGenerator Instance
        {
            get { return _instance.Value; }
        }

        #endregion

        #region Instance

        private static readonly Dictionary<string, string> _patterns =
            new Dictionary<string, string>
            {
                {
                    "Lifecycle",
                    @"https://apps.swissphone-sone.ch/developer/Pages/Applications/Version/Lifecycle/default.aspx?vid={vid}"
                },
                {
                    "SQL Console",
                    @"https://apps.swissphone-sone.ch/developer/Pages/Applications/Version/ControlPanel/SQLConsole/?vid={vid}"
                }
            };

        public IEnumerable<ApprendaLink> Generate(ApprendaSettings settings)
        {
            return _patterns.Select(
                x => new ApprendaLink
                     {
                         Name = x.Key,
                         Link = generateLink(x.Value, settings)
                     });
        }

        private static string generateLink(string pattern, ApprendaSettings settings)
        {
            return pattern.Replace("{aid}", settings.ApplicationId).Replace("{vid}", settings.ApplicationVersionId);
        }

        #endregion
    }
}