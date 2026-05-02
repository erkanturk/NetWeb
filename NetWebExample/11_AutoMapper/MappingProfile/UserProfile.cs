using _11_AutoMapper.Dto;
using _11_AutoMapper.Models;
using AutoMapper;

namespace _11_AutoMapper.MappingProfile
{
    public class UserProfile:Profile
    {
        //User =>UserDto dönüşümü sağlayacağız.
        //Bu alanda FirstName ve LastName i FullName e mapliyeceğiz.
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src =>
                $"{src.FirstName} {src.LastName}"
                ));
            CreateMap<UserDto, User>();
        }
    }
}
