
public static class InMemoryDB
{
    public static User? CurrentUser { get; set; }
    public static List<User> Users { get; set; } = new List<User>();
    public static List<Course> Courses { get; set; } = new List<Course>();
    static InMemoryDB()
    {
        Users.Add(new Operator("H", "H", "H", "H", 1, "H", "H")
        {
            IsActived = true
        });
        Users.Add(new Teacher("s", "s", "s", "s", 2, "s", "s")
        {
            
            IsActived = true
        });
        Users.Add(new Student("a", "a", "a", "a", 3, "a", "a")
        {
            IsActived = true
        });

        var teacher = (Teacher)Users[1]; 

        Courses.Add(new Course("C#", "None", 10, new DateTime(1403, 07, 1, 9, 0, 0), new DateTime(1403, 07, 1, 12, 0, 0), teacher,10));
        Courses.Add(new Course("C", "Sql", 10, new DateTime(1403, 07, 1, 11, 0, 0), new DateTime(1403, 07, 1, 14, 0,0,0), teacher,6));
        Courses.Add(new Course("C++", "None", 10, new DateTime(1403, 07, 2, 14, 0, 0), new DateTime(1403, 07, 2, 16, 0, 0), teacher,4));
        Courses.Add(new Course("Django", "Python", 10, new DateTime(1403, 07, 3, 9, 0, 0), new DateTime(1403, 07, 3, 10, 0, 0), teacher,8));
        Courses.Add(new Course("ASp.Net", "C#", 10, new DateTime(1403, 07, 4, 12, 0, 0), new DateTime(1403, 07, 4, 14 ,0, 0), teacher,5));

    }



}
