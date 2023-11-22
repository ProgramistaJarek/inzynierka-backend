using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Babysitter> Babysitters { get; set; }
        public DbSet<Summons> Summons { get; set; }
        public DbSet<VaccinationCard> VaccinationCard { get; set; }
        public DbSet<VaccinationInfo> VaccinationInfo { get; set; }
        public DbSet<Vaccinations> Vaccinations { get; set; }
        public DbSet<AgeGroups> AgeGroups { get; set; }
        public DbSet<TypesVaccines> TypesVaccines { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Summons)
                .WithOne(e => e.Patient)
                .HasForeignKey(e => e.PatientId)
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .HasOne(e => e.VaccinationCard)
                .WithOne(e => e.Patient)
                .HasForeignKey<VaccinationCard>(e => e.PatientId)
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Babysitter)
                .WithOne(e => e.Patient)
                .HasForeignKey(e => e.PatientId);

            modelBuilder.Entity<VaccinationCard>()
                .HasMany(e => e.VaccinationInfo)
                .WithOne(e => e.VaccinationCard)
                .HasForeignKey(e => e.VaccinationCardId)
                .IsRequired();

            modelBuilder.Entity<Vaccinations>()
                .HasMany(e => e.VaccinationInfo)
                .WithOne(e => e.Vaccinations)
                .HasForeignKey(e => e.VaccinationId);

            modelBuilder.Entity<AgeGroups>()
                .HasMany(e => e.VaccinationInfo)
                .WithOne(e => e.AgeGroups)
                .HasForeignKey(e => e.AgeGroupId);

            modelBuilder.Entity<TypesVaccines>()
                .HasMany(e => e.VaccinationInfo)
                .WithOne(e => e.TypeVaccinations)
                .HasForeignKey(e => e.TypeVaccinationId);

            modelBuilder.Entity<AgeGroups>().HasData(
                new AgeGroups { Id = 1, Name = "Noworodek" },
                new AgeGroups { Id = 2, Name = "2 miesiąc życia" },
                new AgeGroups { Id = 3, Name = "3-4 miesiąc życia" },
                new AgeGroups { Id = 4, Name = "5-6 miesiąc życia" },
                new AgeGroups { Id = 5, Name = "7 miesiąc życia" },
                new AgeGroups { Id = 6, Name = "13-14 miesiąc życia" },
                new AgeGroups { Id = 7, Name = "16-18 miesiąc życia" },
                new AgeGroups { Id = 8, Name = "6 rok życia" },
                new AgeGroups { Id = 9, Name = "10 rok życia" },
                new AgeGroups { Id = 10, Name = "14 rok życia" },
                new AgeGroups { Id = 11, Name = "19 rok życia" }
            );

            modelBuilder.Entity<TypesVaccines>().HasData(
                new TypesVaccines { Id = 1, Name = "Gruźlica BCG" },
                new TypesVaccines { Id = 2, Name = "wzw B" },
                new TypesVaccines { Id = 3, Name = "DTP" },
                new TypesVaccines { Id = 4, Name = "Hib" },
                new TypesVaccines { Id = 5, Name = "polio IPV" },
                new TypesVaccines { Id = 6, Name = "odra, świnka, różyczka" },
                new TypesVaccines { Id = 7, Name = "DTaP" },
                new TypesVaccines { Id = 8, Name = "polio OPV" },
                new TypesVaccines { Id = 9, Name = "Td" }
            );
        }
    }
}
