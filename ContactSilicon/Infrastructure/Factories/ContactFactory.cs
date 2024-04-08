using Infrastructure.Entitys;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public static class ContactFactory
{
    public static ContactEntity Contact (ContactForm form)
    {
        var contact = new ContactEntity
        {
            Id = Guid.NewGuid().ToString(),
            Email = form.Email,
            FullName = form.FullName,
            Message = form.Message,
            Service = form.Service,
        };
        return contact;
    }
}
