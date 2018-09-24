using SJ90.DesktopAPI.Services;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using SJ90.DesktopAPI.Infrastructure;
using AutoMapper;
using SJ90.DesktopAPI.API;
using SJ90.DesktopAPI.Domain;
using System;
using SJ90.DesktopAPI.Domain.Enums;
using System.Linq;
using SJ90.DesktopAPI.Infrastructure.Repositories;

namespace SJ90.DesktopAPI.Tests
{
    public class ResourceServiceTest
    {
        public IMapper _mapper;

        public ResourceServiceTest()
        {
            var mappingProfile = new MappingProfile();

            var config = new MapperConfiguration(mappingProfile);
            _mapper = new Mapper(config);
        }

        [Fact]
        public void Add_writes_to_database()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            using (var context = new DatabaseContext(options))
            {
                var resource = new Resource
                {
                    Weight = 10,
                    MaximumWeight = 15,
                    SchedulingId = 10
                };

                var service = new ResourceService(context, new ResourceRepository(context));
                service.Add(resource);
            }

            using (var context = new DatabaseContext(options))
            {
                Assert.Single(context.Set<Resource>().ToList());

                Assert.Equal(1, context.Set<Resource>().Single().Id);
            }
        }

        [Fact]
        public void Delete_deletes_from_database()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Delete_deletes_from_database")
                .Options;

            using (var context = new DatabaseContext(options))
            {
                var resource = new Resource
                {
                    Weight = 10,
                    MaximumWeight = 15,
                    SchedulingId = 10
                };

                var service = new ResourceService(context, new ResourceRepository(context));
                service.Add(resource);
                Assert.Single(context.Set<Resource>().ToList());

                var insertedResource = service.GetAll().First();

                service.Delete(insertedResource.Id);
                Assert.Empty(context.Set<Resource>().ToList());
            }
        }

        [Fact]
        public void Update_updates_item_from_database()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Update_updates_item_from_database")
                .Options;

            using (var context = new DatabaseContext(options))
            {
                var resource = new Resource
                {
                    Weight = 10,
                    MaximumWeight = 15,
                    SchedulingId = 10
                };

                var service = new ResourceService(context, new ResourceRepository(context));
                service.Add(resource);
                Assert.Single(context.Set<Resource>().ToList());
                Assert.Equal(10, context.Set<Resource>().Single().Weight);

                resource.Weight = 13;
                service.Update(1, resource);
                Assert.Equal(13, context.Set<Resource>().Single().Weight);
            }
        }
    }
}
