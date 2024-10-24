public interface ICourseRepository
{
    public List<Course> GetAllCourses();

    public Course GetCourseById(int courseId);

    public void SelectStudentInCourse(Student student, int courseId);

    public void ShowStudentCourses(Student student);
    public void CreateCourse(string name, string prerequisite, int capacity, DateTime courseTime, DateTime endTime, Teacher teacher, int unit);


}