using YouTube.Models.Interfaces;
using YouTube.Models;
using Microsoft.EntityFrameworkCore;

namespace YouTube.Models.Repositries
{
   public class IChannelRepositry : IChannel
   {
      private AppDbContext _context;
      public IChannelRepositry(AppDbContext context)
      {
         _context = context;
      }
      public List<Channel> GetAllChannel()
      {
         return _context.channel.ToList();
      }
      public Channel GetChannelById(int id)
      {
         return _context.channel.Find(id);
      }
      public void AddChannel(Channel channel)
      {
         _context.channel.Add(channel);
         _context.SaveChanges();
      }
      public void UpdateChannel(Channel channel)
      {
         _context.Entry(channel).State = EntityState.Modified;
         _context.SaveChanges();
      }
      public void DeleteChannel(int id)
      {
         Channel channel = _context.channel.Find(id);
         _context.channel.Remove(channel);
         _context.SaveChanges();
      }
      public Channel GetChannelByEmail(string email)
      {
         return _context.channel.FirstOrDefault(u => u.User.Email == email);
      }
      public Channel GetChannelByUserName(string username)
      {
         return _context.channel.FirstOrDefault(u => u.User.Username == username);
      }
   }
}
