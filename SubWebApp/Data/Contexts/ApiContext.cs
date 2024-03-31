using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class ApiContext(DbContextOptions<ApiContext> options) : DbContext(options)
{
    public DbSet<SubEntity> SubEntities { get; set; }
}
