namespace N67.EduCourse.Domin.Entities;

public class User
{
    public Guid Id { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public virtual ICollection<Course> TeacherCourse { get; set; }

    public virtual ICollection<CourseStudent> CourseStudent { get; set; }
}