using AutoMapper;
using SJ90.DesktopAPI.API;
using System;
using Xunit;

namespace SJ90.DesktopAPI.Tests
{
    public class AutoMapperTests
    {
        [Fact]
        public void MappingProfile_VerifyMappings()
        {
            var mappingProfile = new MappingProfile();

            var config = new MapperConfiguration(mappingProfile);
            var mapper = new Mapper(config);

            (mapper as IMapper).ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
