namespace YouTube.Models.Interfaces
{
   public interface IUser
   {
      public List<User> GetAllUser();
      public User GetUserById(int id);
      public void AddUser(User user);
      public void UpdateUser(User user);
      public void DeleteUser(int id);
      public User GetUserByUserName(string username);
      public User GetUserByEmail(string email);
      public User GetUserByChannelId(int id);
   }
}
