
public class Teacher : User
{
    public Teacher(string firstName, string lastName, string email, string userName, int mobile, string addres, string password) : base(firstName, lastName, email, userName, mobile, addres, password)
    {
    }
    public List<Course> courses { get; set; }= new List<Course>();
}

