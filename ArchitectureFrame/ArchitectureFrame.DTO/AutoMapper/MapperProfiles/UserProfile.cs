using ArchitectureFrame.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.DTO.AutoMapper.MapperProfiles
{
   public class UserProfile:Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<User, SessionUser>()
                .ForMember(dest => dest.Roles, opt => { opt.Ignore(); });
        }
    }
}
