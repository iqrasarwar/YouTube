using YouTube.Models.Interfaces;
using YouTube.Models;
using Microsoft.EntityFrameworkCore;

namespace YouTube.Models.Repositries
{
   public class IUserRepositry: IUser
   {
      private AppDbContext _context;
      public IUserRepositry(AppDbContext context)
      {
         _context = context;
      }
      public List<User> GetAllUser()
      {
         return _context.user.ToList();
      }
      public User GetUserById(int id)
      {
         return _context.user.Find(id);
      }
      public void AddUser(User user)
      {
         _context.user.Add(user);
         _context.SaveChanges();
      }
      public void UpdateUser(User user)
      {
         _context.Entry(user).State = EntityState.Modified;
         _context.SaveChanges();
      }
      public void DeleteUser(int id)
      {
         User user = _context.user.Find(id);
         _context.user.Remove(user);
         _context.SaveChanges();
      }
      public User GetUserByEmail(string email)
      {
         return _context.user.FirstOrDefault(u => u.Email == email);
      }
      // public User GetUserByChannelId(int id)
      // {
      //    return _context.user.FirstOrDefault(u => u.channelId == id);
      // }

      public User GetUserByUserName(string username)
      {
         return _context.user.FirstOrDefault(u => u.Username == username);
      }

   }
}
