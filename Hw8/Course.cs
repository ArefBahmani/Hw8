public class Course
{
    public int Id { get; private set; } 
    public string Name { get; set; }
    public int Unit { get; set; } 
    public Teacher Teacher { get; set; }
    public int Capacity { get; set; }
    public string Prerequisite { get; set; }
    public DateTime CourseTimeStart { get; set; } 
    public DateTime CourseTimeEnd { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();

    private static int _lastId = 1; 

    
    public Course(string name, string prerequisite, int capacity, DateTime courseTimeStart, DateTime courseTimeEnd, Teacher teacher, int unit)
    {
        Id = _lastId++;
        Name = name;
        Prerequisite = prerequisite;
        Capacity = capacity;
        CourseTimeStart = courseTimeStart;
        CourseTimeEnd = courseTimeEnd;
        Teacher = teacher;
        Unit = unit;
    }
}