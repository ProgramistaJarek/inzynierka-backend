using Microsoft.EntityFrameworkCore;
using backend.ModelsDTO;
using System.Reflection.Metadata;

namespace backend.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Vaccinations> Vaccinations { get; set; }
        public DbSet<AgeGroups> AgeGroups { get; set; }
        public DbSet<TypesVaccines> TypesVaccines { get; set; }
        public DbSet<VaccinationSchedule> VaccinationSchedules { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VaccinationSchedule>()
                .HasOne(x => x.AgeGroups)
                .WithMany()
                .HasForeignKey(x => x.IdAgeGroups);

            modelBuilder.Entity<VaccinationSchedule>()
                .HasOne(x => x.TypesVaccines)
                .WithMany()
                .HasForeignKey(x => x.IdTypesVaccines);

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

            modelBuilder.Entity<VaccinationSchedule>().HasData(
                new VaccinationSchedule { Id = 1, IdAgeGroups = 1, IdTypesVaccines = 1, Dose = "" },
                new VaccinationSchedule { Id = 2, IdAgeGroups = 1, IdTypesVaccines = 2, Dose = "1" },
                new VaccinationSchedule { Id = 3, IdAgeGroups = 2, IdTypesVaccines = 2, Dose = "2" },
                new VaccinationSchedule { Id = 4, IdAgeGroups = 2, IdTypesVaccines = 3, Dose = "1" },
                new VaccinationSchedule { Id = 5, IdAgeGroups = 2, IdTypesVaccines = 4, Dose = "1" },
                new VaccinationSchedule { Id = 6, IdAgeGroups = 3, IdTypesVaccines = 3, Dose = "2" },
                new VaccinationSchedule { Id = 7, IdAgeGroups = 3, IdTypesVaccines = 4, Dose = "2" },
                new VaccinationSchedule { Id = 8, IdAgeGroups = 3, IdTypesVaccines = 5, Dose = "1" },
                new VaccinationSchedule { Id = 9, IdAgeGroups = 4, IdTypesVaccines = 3, Dose = "3" },
                new VaccinationSchedule { Id = 10, IdAgeGroups = 4, IdTypesVaccines = 4, Dose = "3" },
                new VaccinationSchedule { Id = 11, IdAgeGroups = 4, IdTypesVaccines = 5, Dose = "2" },
                new VaccinationSchedule { Id = 12, IdAgeGroups = 5, IdTypesVaccines = 2, Dose = "3" },
                new VaccinationSchedule { Id = 13, IdAgeGroups = 6, IdTypesVaccines = 6, Dose = "1" },
                new VaccinationSchedule { Id = 14, IdAgeGroups = 7, IdTypesVaccines = 3, Dose = "4" },
                new VaccinationSchedule { Id = 15, IdAgeGroups = 7, IdTypesVaccines = 5, Dose = "3" },
                new VaccinationSchedule { Id = 16, IdAgeGroups = 7, IdTypesVaccines = 4, Dose = "4" },
                new VaccinationSchedule { Id = 17, IdAgeGroups = 8, IdTypesVaccines = 7, Dose = "1 dawka przypominająca" },
                new VaccinationSchedule { Id = 18, IdAgeGroups = 8, IdTypesVaccines = 8, Dose = "" },
                new VaccinationSchedule { Id = 19, IdAgeGroups = 9, IdTypesVaccines = 6, Dose = "2 dawka przypominająca" },
                new VaccinationSchedule { Id = 20, IdAgeGroups = 10, IdTypesVaccines = 9, Dose = "2 dawka przypominająca" },
                new VaccinationSchedule { Id = 21, IdAgeGroups = 11, IdTypesVaccines = 9, Dose = "3 dawka przypominająca" }
            );
        }
    }
}
