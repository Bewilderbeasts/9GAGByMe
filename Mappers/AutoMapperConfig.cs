using AutoMapper;
using FunnyImages.Domain;
using FunnyImages.DTO;
using FunnyImages.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
           => new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<JwtSettings, JwtDto>();
               cfg.CreateMap<User, UserDto>();
               cfg.CreateMap<Image, ImageDto>();
               cfg.CreateMap<Comment, CommentDto>();
           })
            .CreateMapper();
    }
}
