using AutoMapper;
using AutoMapper.Configuration;
using SJ90.DesktopAPI.Domain;
using SJ90.DesktopAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SJ90.DesktopAPI.API
{
    public class MappingProfile : MapperConfigurationExpression
    {
        public MappingProfile()
        {
            CreateMap<SchedulingEntity, Scheduling>().ReverseMap();
        }
    }
}
