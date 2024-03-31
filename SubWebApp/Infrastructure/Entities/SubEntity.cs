using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class SubEntity
{
    [Key]
    public string Email { get; set; } = null!;

    public bool DailyNewsLetter { get; set; }
    public bool AdvertisingUpdate { get; set; }
    public bool WeekInReview { get; set; }
    public bool EventUpDates { get; set; }
    public bool StartupsWeekly { get; set; }
    public bool PodCasts { get; set; }

}
