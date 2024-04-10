using Infrastructure.Entities;
using Silicon.Models;

namespace Silicon.Factories
{
    public class TeacherFactory
    {
        public static Teacher CreateTeacher(TeacherEntity entity)
        {
            try
            {
                return new Teacher
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    Followers = entity.Followers,
                    Subscribers = entity.Subscribers,
                    Image = entity.Image,                    
                };
            }
            catch (Exception e) { }
            return null!;
        }
    }
}