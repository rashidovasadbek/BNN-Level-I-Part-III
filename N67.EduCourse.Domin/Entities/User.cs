namespace N67.EduCourse.Domin.Entities;

public class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public virtual ICollection<Course> TeacherCourses { get; set; }

    public virtual ICollection<CourseStudent> CourseStudents { get; set; }
}