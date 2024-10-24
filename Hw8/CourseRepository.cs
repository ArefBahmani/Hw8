using Colors.Net;
using Colors.Net.StringColorExtensions;


public class CourseRepository:ICourseRepository
{
    private List<Course> courses = InMemoryDB.Courses;

    public List<Course> GetAllCourses()
    {
        var courses = InMemoryDB.Courses;

        ColoredConsole.WriteLine("*******All Courses******".Green());
        foreach (var course in courses)
        {
            ColoredConsole.WriteLine($"ID: {course.Id} / Name: {course.Name} / Teacher: {course.Teacher.FirstName} {course.Teacher.LastName} / StartTime: {course.CourseTimeStart} /  EndTime: {course.CourseTimeEnd} /  Capacity: {course.Capacity} / Enrolled: {course.Students.Count}, Unit: {course.Unit}".DarkGray());
        }

        return courses; 
    }

    
    public Course GetCourseById(int courseId)
    {
        return InMemoryDB.Courses.FirstOrDefault(course => course.Id == courseId);
    }
    public void SelectStudentInCourse(Student student, int courseId)
    {
        var course = courses.FirstOrDefault(c => c.Id == courseId);
        if (course != null)
        {
            if (course.Students.Count >= course.Capacity)
            {
                ColoredConsole.WriteLine($"Course {course.Name} Full".DarkRed());
                return;
            }

            if (student.EnrolledCourses.Sum(c => c.Unit) + course.Unit > 20)
            {
                ColoredConsole.WriteLine($"{student.FirstName} Can not {course.Name}/Only Unit<20".DarkRed());
                return;
            }

            foreach (var enrolledCourse in student.EnrolledCourses)
            {
                if (course.CourseTimeStart < enrolledCourse.CourseTimeEnd && course.CourseTimeEnd > enrolledCourse.CourseTimeStart)
                {
                    ColoredConsole.WriteLine($"Time Course {course.Name} Time Interference {enrolledCourse.Name}".DarkRed());
                    return;
                }
            }
            if (student.EnrolledCourses.Any(c => c.Id == course.Id))
            {
                ColoredConsole.WriteLine($"You Have Already Chosen {course.Name}".DarkRed());
                return;
            }
            if (course.Capacity == 0)
            {
                ColoredConsole.WriteLine($"Capacity Of {course.Name} Full".DarkRed());
            }

            course.Capacity -= 1;
            course.Students.Add(student);
            student.EnrolledCourses.Add(course);

            

            ColoredConsole.WriteLine($"{student.FirstName} : {course.Name} Course Successfully".DarkGreen());
        }
        else
        {
            ColoredConsole.WriteLine("Course Not Found");
        }
    }

    public void ShowStudentCourses(Student student)
    {
        ColoredConsole.WriteLine($"Courses Enrolled By {student.FirstName}:".DarkGray());
        foreach (var course in student.EnrolledCourses)
        {
            ColoredConsole.WriteLine($"ID: {course.Id}/ Name: {course.Name} /  Capacity: {course.Capacity} / Unit: {course.Unit} / StartTime:{course.CourseTimeStart} / EndTime:{course.CourseTimeEnd}".Green());
        }
    }

    public void CreateCourse( string name, string prerequisite, int capacity, DateTime courseTime, DateTime endTime, Teacher teacher, int unit)
    {
        var course = new Course(name, prerequisite, capacity, courseTime, endTime, teacher, unit);
        InMemoryDB.Courses.Add(course);
        ColoredConsole.WriteLine($"Course {name} ADD Successfully.".DarkGreen());
    }
}