using Colors.Net;
using Colors.Net.StringColorExtensions;
public class Program
{
    IUserRepository _userRepository = new UserRepository();
    ICourseRepository _courseRepository = new CourseRepository();
    UserService _userService = new UserService();
    bool _isRunning = true;
    public void Run() 
    {
        while (_isRunning) 
        {
            ShowMainMenu();
        }
    }
    void ShowMainMenu()
    {
        ColoredConsole.WriteLine("                                         ****Welcome To Golestan*****".DarkGreen());
        ColoredConsole.WriteLine("1. Register ".Blue());
        ColoredConsole.WriteLine("2. Login".Blue());
        ColoredConsole.WriteLine("3. Exit".DarkRed());
        string option = Console.ReadLine();
        switch (option)
        {
            case "1":
                RegisterUser();
                break;
            case "2":
                Login();
                break;
            case "3":
                _isRunning = false; 
                break;
            default:
                ColoredConsole.WriteLine("Invalid Option".DarkRed());
                break;
        }
    }

    void RegisterUser()
    {
        ColoredConsole.WriteLine("******* Register User *******".DarkMagenta());
        ColoredConsole.Write("First Name: ".Blue());
        string firstName = Console.ReadLine();
        ColoredConsole.Write("Last Name: ".Blue());
        string lastName = Console.ReadLine();
        ColoredConsole.Write("Email: ".Blue());
        string email = Console.ReadLine();
        ColoredConsole.Write("Username: ".Blue());
        string username = Console.ReadLine();
        ColoredConsole.Write("Mobile: ".Blue());
        int mobile = Convert.ToInt32(Console.ReadLine());
        ColoredConsole.Write("Address: ".Blue());
        string address = Console.ReadLine();
        ColoredConsole.Write("Password: ".Blue());
        string password = Console.ReadLine();
        ColoredConsole.Write("Choose role (1- Student, 2- Teacher, 3- Operator): ".DarkMagenta());
        string input = Console.ReadLine();
        RoleEnum role = input switch
        {
            "1" => RoleEnum.Student,
            "2" => RoleEnum.Teacher,
            "3" => RoleEnum.Operator,
            
        };

        User user = role switch
        {
            RoleEnum.Student => new Student(firstName, lastName, email, username, mobile, address, password),
            RoleEnum.Teacher => new Teacher(firstName, lastName, email, username, mobile, address, password),
            RoleEnum.Operator => new Operator(firstName, lastName, email, username, mobile, address, password),
        };
        ColoredConsole.WriteLine($"User Role {role} Created Successfully.".DarkGreen());

        if (user != null)
        {
            bool isRegistered = _userService.RegisterUser(user);
            if (isRegistered)
            {
                ColoredConsole.WriteLine("Successfully registered".Green());
            }
            else
            {
                ColoredConsole.WriteLine("User not registered.".DarkRed());
            }
        }
        else
        {
            ColoredConsole.WriteLine("User not registered.".DarkRed());
        }
    }

    void Login()
    {
        isUserMenuRunning = true;
        ColoredConsole.WriteLine("*******Login*******".DarkBlue());
        ColoredConsole.Write("Username: ".Blue());
        string username = Console.ReadLine();
        ColoredConsole.Write("Password: ".Blue());
        string password = Console.ReadLine();
        var user = _userService.Login(username, password);
        if (user != null)
        {
            if (!user.IsActived)
            {
                ColoredConsole.WriteLine("Your Account Is Inactive.".DarkCyan());
                return;
            }
            ShowUserMenu(user);
        }
        else
        {
            ColoredConsole.WriteLine("Invalid username or password. Please try again.".DarkRed());
        }
    }
     bool isUserMenuRunning = true;

    void ShowUserMenu(User user)
    {
        while (isUserMenuRunning)
        {
            ColoredConsole.WriteLine($"\n   ****Welcome, {user.FirstName}******".DarkGreen());
            switch (user)
            {
                case Teacher teacher:
                    ShowTeacherMenu(teacher);
                    break;
                case Operator operatorUser:
                    ShowOperatorMenu(operatorUser);
                    break;
                case Student student:
                    ShowStudentMenu(student);
                    break;
                default:
                    ColoredConsole.WriteLine("Unknown user role.".DarkRed());
                    break;
            }
        }
    }

    void ShowTeacherMenu(Teacher teacher)
    {
        while (isUserMenuRunning)
        {
            ColoredConsole.WriteLine("\n**********   Teacher Menu  **********".DarkCyan());
            ColoredConsole.WriteLine("1. Add Course: ".Cyan());
            ColoredConsole.WriteLine("2. Shoe Corse: ".Cyan());
            ColoredConsole.WriteLine("3. Logout".DarkRed());
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    AddCourse(teacher);
                    break;
                case "2":
                    ViewEnrolledStudents(teacher);
                    break;
                case "3":
                    InMemoryDB.CurrentUser = null;
                    isUserMenuRunning = false; 
                    return;
                default:
                    ColoredConsole.WriteLine("Invalid Option".DarkRed());
                    break;
            }

        }
    }

    void ShowOperatorMenu(Operator operatorUser)
    {
        while (isUserMenuRunning)
        {
            ColoredConsole.WriteLine("\n**********Operator Menu**********".DarkGray());
            ColoredConsole.WriteLine("1. Activate User".Gray());
            ColoredConsole.WriteLine("2. Deactivate User".Gray());
            ColoredConsole.WriteLine("3. Show Users".Gray());
            ColoredConsole.WriteLine("4. Logout".DarkRed());
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    ActivateUser();
                    break;
                case "2":
                    DeactivateUser();
                    break;
                case "3":
                    ShowUsers(); ;
                    break;
                case "4":
                    InMemoryDB.CurrentUser = null;
                    isUserMenuRunning = false; 
                    return;
                default:
                    Console.WriteLine("Invalid Option".DarkRed());
                    break;
            }
        }
    }

    void ShowStudentMenu(Student student)
    {
        while (isUserMenuRunning)
        {
            ColoredConsole.WriteLine("\nStudent Menu:".DarkMagenta());
            ColoredConsole.WriteLine("1. Show Courses".Blue());
            ColoredConsole.WriteLine("2. Select In Course".Blue());
            ColoredConsole.WriteLine("3. Show My Courses".Blue());
            ColoredConsole.WriteLine("4. Logout".DarkRed());
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    ShowCourses();
                    break;
                case "2":
                    EnrollInCourse(student);
                    break;
                case "3":
                    _courseRepository.ShowStudentCourses(student);
                    break;
                case "4":
                    InMemoryDB.CurrentUser = null; 
                    isUserMenuRunning = false; 
                    break;
                default:
                    Console.WriteLine("Invalid Option".DarkRed());
                    break;
            }

        }
    }

    void ShowCourses()
    {
        _courseRepository.GetAllCourses();
    }

    void EnrollInCourse(Student student)
    {
        ColoredConsole.WriteLine("Select In  Course:".Gray());
        ShowCourses();
        ColoredConsole.Write("Enter Course ID To Select: ".Gray());
        int courseId = Convert.ToInt32(Console.ReadLine());
        var course = _courseRepository.GetCourseById(courseId);
        if (course == null)
        {
            ColoredConsole.WriteLine("Course Not Found".DarkRed());
            return;
        }
        _courseRepository.SelectStudentInCourse(student, courseId);
    }

    void AddCourse(Teacher teacher)
    {
        ColoredConsole.WriteLine("****Add New Course****".DarkGreen());
        ColoredConsole.Write("Course Name: ".Blue());
        string courseName = Console.ReadLine();
        ColoredConsole.Write("Prerequisite: ".Blue());
        string prerequisite = Console.ReadLine();
        ColoredConsole.Write("Unit: ".Blue());
        int unit=Convert.ToInt32(Console.ReadLine());
        if(unit<=0)
        {
            ColoredConsole.WriteLine("Wrong.Unit>0".DarkRed());

        }
        ColoredConsole.Write("Capacity:".Blue());
        int capacity = Convert.ToInt32(Console.ReadLine());
        if(capacity<=0)
        {
            ColoredConsole.WriteLine("Wrong.capacity>0".DarkRed());
        }
        DateTime startTime = CreateDateTime();
        Console.WriteLine($"Course Start Time: {startTime}".DarkCyan());
        DateTime endTime = CreateDateTime();
        Console.WriteLine($"Course End Time: {endTime}".DarkGray());
        _courseRepository.CreateCourse(courseName, prerequisite, capacity, startTime, endTime, teacher, unit);
        ColoredConsole.WriteLine($"Course '{courseName}' added successfully".DarkGreen());
    }

    void ViewEnrolledStudents(Teacher teacher)
    {
        _userRepository.ShowTeacherCourses(teacher);
    }

    void ActivateUser()
    {
        ColoredConsole.Write("Enter UserID to activate: ".Blue());
        int userID = Convert.ToInt32(Console.ReadLine());
        _userRepository.ActivateUser(userID);
    }

    void DeactivateUser()
    {
        ColoredConsole.Write("Enter UserID to deactivate: ".Blue());
        int userID = Convert.ToInt32(Console.ReadLine());
        _userRepository.DeactivateUser(userID);
    }

    void ShowUsers()
    {
        ColoredConsole.WriteLine("Users List:".Green());
        var users = _userRepository.GetAllUsers();
        foreach (var user in users)
        {
            string role = user switch
            {
                Student => "Student",
                Teacher => "Teacher",
                Operator => "Operator"
            };
            ColoredConsole.WriteLine($" ID: {user.Id}, Username: {user.UserName} (Role: {role}, Active: {user.IsActived})".DarkGray());
        }
    }
    DateTime CreateDateTime()
    {
        ColoredConsole.Write("Enter Day:".DarkBlue());
        int day = Convert.ToInt32(Console.ReadLine());
        ColoredConsole.Write("Enter Hour (0-23):".DarkGray());
        int hour = Convert.ToInt32(Console.ReadLine());
        ColoredConsole.Write("Enter Minute (0-59):".DarkBlue());
        int minute = Convert.ToInt32(Console.ReadLine());
        DateTime dateTime = new DateTime(1403, 07, day, hour, minute, 0);
        return dateTime;
    }
}








