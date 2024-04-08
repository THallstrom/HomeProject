using Infrastructure.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<ContactEntity> Contacts { get; set; }
}
