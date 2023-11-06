using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N67.EduCourse.Domin.Entities;

namespace Persistance.EntityConfiguration;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasOne(course => course.Teacher)
            .WithMany(user => user.TeacherCourses)
            .HasForeignKey(course => course.TeacherId);
    }
}