﻿using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class SubRegistrationForm
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    public bool DailyNewsLetter { get; set; }
    public bool AdvertisingUpdate { get; set; }
    public bool WeekInReview { get; set; }
    public bool EventUpDates { get; set; }
    public bool StartupsWeekly { get; set; }
    public bool PodCasts { get; set; }
}
