using SJ90.DesktopAPI.Domain;
using SJ90.DesktopAPI.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SJ90.DesktopAPI.Infrastructure.Repositories
{
    public class ResourceRepository : Repository<Resource>, IResourceRepository
    {
        public ResourceRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
