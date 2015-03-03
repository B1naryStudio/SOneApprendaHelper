using System.ComponentModel.DataAnnotations;

namespace SOneApprendaHelper.Models
{
    public class ApprendaSettings
    {
        public const string SETTINGS_KEY = "ApprendaSettings";

        public ApprendaSettings()
        {
            ApprendaBaseUrl = @"https://apps.swissphone-sone.ch/";
            ApplicationVersion = 1;
        }

        // {host}
        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "Apprenda Base URL")]
        public string ApprendaBaseUrl { get; set; }

        // {alias}
        [Required]
        [Display(Name = "Application Alias")]
        public string ApplicationAlias { get; set; }

        // {aid}
        [Required]
        [RegularExpression(@"\w{8}-\w{4}-\w{4}-\w{4}-\w{12}", ErrorMessage = "The field Application ID must match the format 'XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX'.")]
        [Display(Name = "Application ID")]
        public string ApplicationId { get; set; }

        // {ver}
        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Application Version")]
        public int ApplicationVersion { get; set; }

        // {vid}
        [Required]
        [RegularExpression(@"\w{8}-\w{4}-\w{4}-\w{4}-\w{12}", ErrorMessage = "The field Application Version ID must match the format 'XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX'.")]
        [Display(Name = "Application Version ID")]
        public string ApplicationVersionId { get; set; }
    }
}