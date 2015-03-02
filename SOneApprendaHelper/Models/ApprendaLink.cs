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
    }
}