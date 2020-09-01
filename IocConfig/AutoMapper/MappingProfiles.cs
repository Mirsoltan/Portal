using AutoMapper;
using Entities;
using Entities.identity;
using ViewModels.Manage;
using ViewModels.RoleManager;
using ViewModels.UserManager;

using System;
using System.Collections.Generic;
using System.Text;

namespace IocConfig.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //CreateMap<Category, CategoryViewModel>().ReverseMap()
            //    .ForMember(p => p.Parent, opt => opt.Ignore())
            //    .ForMember(p => p.Categories, opt => opt.Ignore())
            //);

            CreateMap<Role, RolesViewModel>().ReverseMap()
                    .ForMember(p => p.Users, opt => opt.Ignore())
                    .ForMember(p => p.Claims, opt => opt.Ignore());

            //CreateMap<Video, VideoViewModel>().ReverseMap();

            CreateMap<User, UsersViewModel>().ReverseMap()
                  .ForMember(p => p.Claims, opt => opt.Ignore());

            CreateMap<User, ProfileViewModel>().ReverseMap()
                   .ForMember(p => p.Claims, opt => opt.Ignore());


        }
    }
}
