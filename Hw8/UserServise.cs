using Colors.Net;
using Colors.Net.StringColorExtensions;

public class UserService
{
    private List<User> users = InMemoryDB.Users; 
    public bool RegisterUser(User user)
    {
        var existingUser = InMemoryDB.Users.FirstOrDefault(u => u.UserName == user.UserName);
        if (existingUser != null)
        {
            ColoredConsole.WriteLine("Username Already".Red());
            return false;
        }



        InMemoryDB.Users.Add(user);
        ColoredConsole.WriteLine($"User {user.UserName} Registered".DarkGreen());
        return true;
    }
    public User Login(string username, string password)
    {
        var user = InMemoryDB.Users.FirstOrDefault(u => u.UserName == username);

        if (user == null)
        {
            ColoredConsole.WriteLine("User Does Not ".Red());
            return null;
        }

        if (!user.IsActived)
        {
            ColoredConsole.WriteLine("User Inactive".Red());
            return null;
        }

        if (user.Password != password)
        {
            ColoredConsole.WriteLine("Wrong Password".Red());
            return null;
        }

        ColoredConsole.WriteLine($"Welcome, {user.FirstName} To Golestan".Green());
        InMemoryDB.CurrentUser = user;

        return user;
    }
}