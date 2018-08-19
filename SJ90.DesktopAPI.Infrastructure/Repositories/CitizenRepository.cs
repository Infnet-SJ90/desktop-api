using SJ90.DesktopAPI.Domain;
using SJ90.DesktopAPI.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SJ90.DesktopAPI.Infrastructure.Repositories
{
    public class CitizenRepository : Repository<Citizen>, ICitizenRepository
    {
        public CitizenRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
