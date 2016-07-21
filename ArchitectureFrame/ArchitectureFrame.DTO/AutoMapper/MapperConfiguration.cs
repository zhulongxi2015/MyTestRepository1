using ArchitectureFrame.DTO.AutoMapper.MapperProfiles;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.DTO.AutoMapper
{
   public class MapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(g => {
                g.AddProfile<UserProfile>();
            });
        }
    }
}
