namespace N67.EduCourse.Domin.DTOs;

public class UserDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;
}