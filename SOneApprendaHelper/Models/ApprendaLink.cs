using System.ComponentModel.DataAnnotations;

namespace SOneApprendaHelper.Models
{
    public class ApprendaLink
    {
        [Required]
        [StringLength(1)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Editable(false)]
        [Display(Name = "URL")]
        public string Link { get; set; }
    }
}