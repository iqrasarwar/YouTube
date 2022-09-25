namespace YouTube.Models.Interfaces
{
   public interface IChannel
   {
      public List<Channel> GetAllChannel();
      public Channel GetChannelById(int id);
      public void AddChannel(Channel channel);
      public void UpdateChannel(Channel channel);
      public void DeleteChannel(int id);
      // public Channel GetChannelByUserId(int id);
      public Channel GetChannelByEmail(string email);
      public Channel GetChannelByUserName(string username);
   }
}
