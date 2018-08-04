using System;

namespace SJ90.DesktopAPI.Domain
{
    public interface IBaseEntity
    {
        long Id { get; set; }
        DateTime AddedDate { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}