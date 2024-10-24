public interface IUserRepository
{
    public void ShowTeacherCourses(Teacher teacher);
    public void ActivateUser(int userId);
    public void DeactivateUser(int userId);
    public void AddUser(User user);
    public List<User> GetAllUsers();



}

