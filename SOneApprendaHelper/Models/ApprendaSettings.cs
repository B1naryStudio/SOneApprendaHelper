using System.ComponentModel.DataAnnotations;

namespace SOneApprendaHelper.Models
{
    public class ApprendaSettings
    {
        public const string SETTINGS_KEY = "ApprendaSettings";

        public ApprendaSettings()
        {
            ApprendaBaseUrl = @"https://apps.swissphone-sone.ch/";
        }

        // {host}
        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "Apprenda Base URL")]
        public string ApprendaBaseUrl { get; set; }

        // {aid}
        [Required]
        [RegularExpression(@"\w{8}-\w{4}-\w{4}-\w{4}-\w{12}", ErrorMessage = "The field Application ID must match the format 'XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX'.")]
        [Display(Name = "Application ID")]
        public string ApplicationId { get; set; }

        // {vid}
        [Required]
        [RegularExpression(@"\w{8}-\w{4}-\w{4}-\w{4}-\w{12}", ErrorMessage = "The field Application Version ID must match the format 'XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX'.")]
        [Display(Name = "Application Version ID")]
        public string ApplicationVersionId { get; set; }
    }
}