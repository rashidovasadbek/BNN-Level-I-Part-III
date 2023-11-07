using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace N67.EduCourse.Domin.Entities;

public class User
{
    public Guid Id { get; set; }
    
    public required string? FirstName { get; set; }

    public required string? LastName { get; set; }
 
    public virtual ICollection<Course> TeacherCourses { get; set; }

    public virtual ICollection<CourseStudent> CourseStudents { get; set; }
}