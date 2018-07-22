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

namespace SJ90.DestktopAPI.Tests
{
    public class SchedulingServiceTest
    {
        public IMapper _mapper;

        public SchedulingServiceTest()
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
                var scheduling = new Scheduling
                {
                    Day = DateTime.Today,
                    Hour = 12,
                    Id = 1,
                    Status = SchedulingStatus.Approved
                };

                var service = new SchedulingService(context, _mapper);
                service.Add(scheduling);
            }

            using (var context = new DatabaseContext(options))
            {
                Assert.Single(context.Set<SchedulingEntity>().ToList());

                Assert.Equal(1, context.Set<SchedulingEntity>().Single().Id);
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
                var scheduling = new Scheduling
                {
                    Day = DateTime.Today,
                    Hour = 12,
                    Id = 1,
                    Status = SchedulingStatus.Approved
                };

                var service = new SchedulingService(context, _mapper);
                service.Add(scheduling);
                Assert.Single(context.Set<SchedulingEntity>().ToList());

                service.Delete(1);
                Assert.Empty(context.Set<SchedulingEntity>().ToList());
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
                var scheduling = new Scheduling
                {
                    Day = DateTime.Today,
                    Hour = 12,
                    Id = 1,
                    Status = SchedulingStatus.Approved
                };

                var service = new SchedulingService(context, _mapper);
                service.Add(scheduling);
                Assert.Single(context.Set<SchedulingEntity>().ToList());
                Assert.Equal(12, context.Set<SchedulingEntity>().Single().Hour);

                scheduling.Hour = 13;
                service.Update(1, scheduling);
                Assert.Equal(13, context.Set<SchedulingEntity>().Single().Hour);
            }
        }
    }
}
