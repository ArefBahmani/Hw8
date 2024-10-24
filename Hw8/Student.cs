
public class Student : User
{
    public int StuNum { get; set; }
    public int Age { get; set; }
    public StudentEnum Status { get; set; }
    public GendeEnum Gender { get; set; }
    public Student(string firstName, string lastName, string email, string userName, int mobile, string addres, string password) : base(firstName, lastName, email,userName,mobile,addres,password)
    {
        Status = StudentEnum.Inactive;
    }
    public Student(string firstName, string lastName, string email, string userName, int mobile, string addres, string password,int stuNum,int age,GendeEnum gender): this(firstName, lastName, email, userName, mobile, addres, password)
    {
        StuNum = stuNum;
        Age = age;
        Gender = gender;
    }
    public List<Course> EnrolledCourses { get; set; } = new List<Course>();
}

