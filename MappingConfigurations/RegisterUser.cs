using AutoMapper;
using YouTube.Models;
using YouTube.ViewModels;

namespace YouTube.MappingConfigurations
{
   public class RegisterUser : Profile
   {
      public RegisterUser()
      {

         // Default mapping when property names are same
         CreateMap<RegisterViewModel, User>();

         // Mapping when property names are different
         CreateMap<RegisterViewModel, User>()
              .ForMember(dest => dest.createdBy, opt => opt.MapFrom(src => src.Username))
              .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));


      }
   }
}
