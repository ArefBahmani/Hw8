
using Colors.Net;
using Colors.Net.StringColorExtensions;


public class UserRepository : IUserRepository
{
    private List<User> users = InMemoryDB.Users;

    public void ShowTeacherCourses(Teacher teacher)
    {
        ColoredConsole.WriteLine("******** Your Courses ********".Green());

        var teacherCourses = InMemoryDB.Courses.Where(c => c.Teacher.Id == teacher.Id).ToList();

        if (teacherCourses.Count == 0)
        {
            ColoredConsole.WriteLine("You Not Courses".DarkRed());
            return;
        }

        foreach (var course in teacherCourses)
        {
            ColoredConsole.WriteLine($"ID: {course.Id} / Name: {course.Name} /  Enrolled: {course.Students.Count} /  Unit: {course.Unit} / Prerequisite: {course.Prerequisite} / StartTime:{course.CourseTimeStart} / EndTime:{course.CourseTimeEnd}".DarkCyan());
        }

    }
    

    public void ActivateUser(int userId)
    {
        var user = users.FirstOrDefault(u => u.Id == userId);
        if (user != null)
        {
            user.IsActived = true;
            ColoredConsole.WriteLine($"User  ID {userId} Activated".Green());
        }
        else
        {
            ColoredConsole.WriteLine("User Not Found".DarkRed());
        }
    }


    public void DeactivateUser(int userId)
    {
        var user = InMemoryDB.Users.FirstOrDefault(u => u.Id == userId);
        if (user != null)
        {
            user.IsActived = false;
            ColoredConsole.WriteLine($"User ID {userId} Deactivated".Green());
        }
        else
        {
            ColoredConsole.WriteLine("User Not Found".DarkRed());
        }
    }
    public void AddUser(User user)
    {
        users.Add(user);
    }
    public List<User> GetAllUsers()
    {
        return InMemoryDB.Users.ToList();

    }
}

