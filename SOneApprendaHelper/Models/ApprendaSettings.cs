using System.ComponentModel.DataAnnotations;

namespace SOneApprendaHelper.Models
{
    public class ApprendaSettings
    {
        public const string SETTINGS_KEY = "ApprendaSettings";

        public ApprendaSettings()
        {
            ApprendaBaseUrl = @"apps.swissphone-sone.ch";
            ApplicationVersion = 1;
        }

        // {email}
        [Required]
        [RegularExpression(@".+@.+", ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Apprenda User E-mail")]
        public string ApprendaUserEmail { get; set; }

        // {uid}
        [Required]
        [RegularExpression(@"\w{8}-\w{4}-\w{4}-\w{4}-\w{12}", ErrorMessage = "The field Apprenda User ID must match the format 'XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX'.")]
        [Display(Name = "Apprenda User ID")]
        public string ApprendaUserId { get; set; }

        // {host}
        [Required]
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

        // {gid}
        [Required]
        [RegularExpression(@"\w{8}-\w{4}-\w{4}-\w{4}-\w{12}", ErrorMessage = "The field Subscription Group ID must match the format 'XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX'.")]
        [Display(Name = "Subscription Group ID")]
        public string SubscriptionGroupId { get; set; }
    }
}