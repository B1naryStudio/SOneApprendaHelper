using SOneApprendaHelper.Models;

namespace SOneApprendaHelper.Services
{
    public interface ITextGenerator
    {
        string Generate(string pattern, ApprendaSettings settings);
    }
}