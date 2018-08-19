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
                    Status = SchedulingStatus.Active,
                    SchedulingRequestId = 1
                };

                var service = new SchedulingService(context, new SchedulingRepository(context));
                service.Add(scheduling);
            }

            using (var context = new DatabaseContext(options))
            {
                Assert.Single(context.Set<Scheduling>().ToList());

                Assert.Equal(1, context.Set<Scheduling>().Single().Id);
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
                    Status = SchedulingStatus.Active
                };

                var service = new SchedulingService(context, new SchedulingRepository(context));
                service.Add(scheduling);
                Assert.Single(context.Set<Scheduling>().ToList());

                var insertedScheduling = service.GetAll().First();

                service.Delete(insertedScheduling.Id);
                Assert.Empty(context.Set<Scheduling>().ToList());
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
                    Status = SchedulingStatus.Active
                };

                var service = new SchedulingService(context, new SchedulingRepository(context));
                service.Add(scheduling);
                Assert.Single(context.Set<Scheduling>().ToList());
                Assert.Equal(12, context.Set<Scheduling>().Single().Hour);

                scheduling.Hour = 13;
                service.Update(1, scheduling);
                Assert.Equal(13, context.Set<Scheduling>().Single().Hour);
            }
        }
    }

    public class CitizenServiceTest
    {
        public IMapper _mapper;

        public CitizenServiceTest()
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
                var citizen = new Citizen
                {
                    Name = "Jorge",
                    CPF = "12345678901",
                    Id = 1
                };

                var service = new CitizenService(context, new CitizenRepository(context));
                service.Add(citizen);
            }

            using (var context = new DatabaseContext(options))
            {
                Assert.Single(context.Set<Citizen>().ToList());

                Assert.Equal(1, context.Set<Citizen>().Single().Id);
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
                var citizen = new Citizen
                {
                    Name = "Joana",
                    CPF = "23456789012"
                };

                var service = new CitizenService(context, new CitizenRepository(context));
                service.Add(citizen);
                Assert.Single(context.Set<Citizen>().ToList());

                var insertedCitizen = service.GetAll().First();

                service.Delete(insertedCitizen.Id);
                Assert.Empty(context.Set<Citizen>().ToList());
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
                var citizen = new Citizen
                {
                    Name = "José",
                    CPF = "34567890123",
                    Id = 1
                };

                var service = new CitizenService(context, new CitizenRepository(context));
                service.Add(citizen);
                Assert.Single(context.Set<Citizen>().ToList());
                Assert.Equal("José", context.Set<Citizen>().Single().Name);

                citizen.Name = "Zé das Couves";
                service.Update(1, citizen);
                Assert.Equal("Zé das Couves", context.Set<Citizen>().Single().Name);
            }
        }
    }
}
