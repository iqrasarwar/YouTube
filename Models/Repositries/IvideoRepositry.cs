using YouTube.Models.Interfaces;
using YouTube.Models;

namespace YouTube.Models.Repositries
{
   public class IvideoRepositry : Ivideo
   {
      // private static readonly SqlConnection Con = new(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=YouTubeClone;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
      //   public static bool RegisterNewUser(SignUp s)
      //   {
      //       Con.Open();
      //       SqlCommand Cmd = new("Insert into [UserBase] (Name,UserName, Password, Email) Values(@name,@username,@password,@email)",Con);
      //       Cmd.Parameters.Add(new("name", s.Name));
      //       Cmd.Parameters.Add(new("username", s.UserName));
      //       Cmd.Parameters.Add(new("password", s.Password));
      //       Cmd.Parameters.Add(new("email", s.Email));
      //       int status = Cmd.ExecuteNonQuery();
      //       Con.Close();
      //       return status != 0;
      //   }
      //   public static List<SignUp> GetUsers()
      //   {
      //       Con.Open();
      //       SqlCommand Cmd = new("select * from [UserBase]", Con);
      //       SqlDataReader dr = Cmd.ExecuteReader();
      //       List<SignUp> list = new();
      //       if(dr.HasRows)
      //       {
      //           while (dr.Read())
      //           {
      //               list.Add(new SignUp((String)dr[1], (String)dr[2], (String)dr[3], (String)dr[3], (String)dr[4])); //nme, usernme, pssword, emil
      //           }
      //       }
      //       Con.Close();
      //       return list;
      //   }
      public List<video> GetAllVideos()
      {
         return null;
      }
      public video GetVideoById(int id)
      {
         return null;
      }
      public void AddVideo(video video)
      {

      }
      public void UpdateVideo(video video)
      {

      }
      public void DeleteVideo(int id)
      {

      }
   }
}
