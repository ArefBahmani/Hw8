
public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public int Mobile { get; set; }
    public string Address {  get; set; }
    public string Password { get; set; }
    public bool IsActived { get; set; }
    private static int _lastId = 1;

    public User(string firstName,string lastName, string email , string userName,int mobile, string addres, string password) 
    {
        Id = _lastId++;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = userName;
        Mobile = mobile;
        Address = addres;
        Password = password;
        IsActived = false;
    }

}

