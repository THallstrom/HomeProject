using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public static class SubFactory
{
    public static SubEntity Create (SubRegistrationForm form)
    {
        var entity = new SubEntity
        {
            Email = form.Email,
            DailyNewsLetter = form.DailyNewsLetter,
            AdvertisingUpdate = form.AdvertisingUpdate,
            WeekInReview = form.WeekInReview,
            EventUpDates = form.EventUpDates,
            PodCasts = form.PodCasts,
            StartupsWeekly = form.StartupsWeekly,
        };

        return entity;
    }
}
