using YouTube.Models.Interfaces;
using YouTube.Models;
using Microsoft.EntityFrameworkCore;

namespace YouTube.Models.Repositries
{
   public class IExploreReposity<video> : IExplore<video> where video : class
   {
      private AppDbContext _context;
      private DbSet<video> _videos;
      public IExploreReposity(AppDbContext context)
      {
         _context = context;
         _videos = _context.Set<video>();
      }
      public List<video> GetAllTrendingVideos()
      {
         return _videos.ToList();
      }

   }
}
