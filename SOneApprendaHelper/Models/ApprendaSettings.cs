using System.ComponentModel.DataAnnotations;

namespace SOneApprendaHelper.Models
{
    public class ApprendaSettings
    {
        // d113c1aa-e2bc-e411-80c6-0050560115d4
        [Required]
        [RegularExpression(@"\w{8}-\w{4}-\w{4}-\w{4}-\w{12}")]
        [Display(Name = "Application ID")]
        public string ApplicationId { get; set; }

        // d313c1aa-e2bc-e411-80c6-0050560115d4
        [Required]
        [RegularExpression(@"\w{8}-\w{4}-\w{4}-\w{4}-\w{12}")]
        [Display(Name = "Application Version ID")]
        public string ApplicationVersionId { get; set; }
    }
}