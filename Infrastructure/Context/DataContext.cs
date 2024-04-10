using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<UserEntity>(options)
{
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<TeacherEntity> Teachers { get; set; }
}
