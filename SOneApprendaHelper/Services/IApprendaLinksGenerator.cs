using System.Collections.Generic;
using SOneApprendaHelper.Models;

namespace SOneApprendaHelper.Services
{
    public interface IApprendaLinksGenerator
    {
        IEnumerable<ApprendaLink> GenerateApprendaLinks(ApprendaSettings settings);
        string GenerateApprendaUrl(string id, ApprendaSettings settings);
    }
}