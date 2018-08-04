using SJ90.DesktopAPI.Domain;
using SJ90.DesktopAPI.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SJ90.DesktopAPI.Infrastructure.Repositories
{
    public class SchedulingRepository : Repository<Scheduling>, ISchedulingRepository
    {
        public SchedulingRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
