using System.ComponentModel.DataAnnotations;

namespace Silicon.Models
{
    public class SubscribeViewModel
    {
        [Display(Name = "Daily NewsLetter")]
        public bool DailyNewsLetter { get; set; }

        [Display(Name = "Advertising Updates")]
        public bool AdvertisingUpdates { get; set; }

        [Display(Name = "Week In Review")]
        public bool WeekInReview { get; set; }

        [Display(Name = "Event Updates")]
        public bool EventUpdates { get; set; }

        [Display(Name = "Start UpWeekly")]
        public bool StartUpWeekly { get; set; }

        [Display(Name = "Pod Casts")]
        public bool PodCasts { get; set; }

        [Display(Name = "Email", Prompt = "Your Email")]
        [Required]
        public string Email { get; set; } = null!;
        
    }
}