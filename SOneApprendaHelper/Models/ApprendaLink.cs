using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SOneApprendaHelper.Models
{
    public class ApprendaLink
    {
        public string Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "URL")]
        public string Link { get; set; }

        #region Comparer

        private static readonly IComparer<ApprendaLink> _nameComparer = new ApprendaLinkNameComparer();

        public static IComparer<ApprendaLink> NameComparer
        {
            get { return _nameComparer; }
        }

        private sealed class ApprendaLinkNameComparer : IComparer<ApprendaLink>
        {
            public int Compare(ApprendaLink x, ApprendaLink y)
            {
                return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
            }
        }

        #endregion
    }
}