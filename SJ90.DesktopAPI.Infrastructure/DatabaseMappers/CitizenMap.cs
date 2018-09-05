using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SJ90.DesktopAPI.Domain;

namespace SJ90.DesktopAPI.Infrastructure.DatabaseMappers
{
    public class CitizenMap
    {
        public CitizenMap(EntityTypeBuilder<Citizen> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.CPF).IsRequired();

            entityBuilder.HasMany<Scheduling>(citizen => citizen.Scheduling)
                         .WithOne(scheduling => scheduling.Citizen)
                         .HasPrincipalKey(citizen => citizen.Id);
        }
    }
}
