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
        public DbSet<VaccinationSchedule> VaccinationSchedules { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VaccinationSchedule>()
                .HasOne(x => x.AgeGroups)
                .WithMany(x => x.VaccinationSchedules)
                .HasForeignKey(x => x.AgeGroupsId)
                .IsRequired();

            modelBuilder.Entity<VaccinationSchedule>()
                .HasOne(x => x.TypesVaccines)
                .WithMany(x => x.VaccinationSchedules)
                .HasForeignKey(x => x.TypesVaccinesId)
                .IsRequired();

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

            modelBuilder.Entity<Babysitter>()
                .HasMany(e => e.Patient)
                .WithOne(e => e.Babysitter)
                .HasForeignKey(e => e.BabysitterId)
                .IsRequired();

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
                new VaccinationSchedule { Id = 1, AgeGroupsId = 1, TypesVaccinesId = 1, Dose = "" },
                new VaccinationSchedule { Id = 2, AgeGroupsId = 1, TypesVaccinesId = 2, Dose = "1" },
                new VaccinationSchedule { Id = 3, AgeGroupsId = 2, TypesVaccinesId = 2, Dose = "2" },
                new VaccinationSchedule { Id = 4, AgeGroupsId = 2, TypesVaccinesId = 3, Dose = "1" },
                new VaccinationSchedule { Id = 5, AgeGroupsId = 2, TypesVaccinesId = 4, Dose = "1" },
                new VaccinationSchedule { Id = 6, AgeGroupsId = 3, TypesVaccinesId = 3, Dose = "2" },
                new VaccinationSchedule { Id = 7, AgeGroupsId = 3, TypesVaccinesId = 4, Dose = "2" },
                new VaccinationSchedule { Id = 8, AgeGroupsId = 3, TypesVaccinesId = 5, Dose = "1" },
                new VaccinationSchedule { Id = 9, AgeGroupsId = 4, TypesVaccinesId = 3, Dose = "3" },
                new VaccinationSchedule { Id = 10, AgeGroupsId = 4, TypesVaccinesId = 4, Dose = "3" },
                new VaccinationSchedule { Id = 11, AgeGroupsId = 4, TypesVaccinesId = 5, Dose = "2" },
                new VaccinationSchedule { Id = 12, AgeGroupsId = 5, TypesVaccinesId = 2, Dose = "3" },
                new VaccinationSchedule { Id = 13, AgeGroupsId = 6, TypesVaccinesId = 6, Dose = "1" },
                new VaccinationSchedule { Id = 14, AgeGroupsId = 7, TypesVaccinesId = 3, Dose = "4" },
                new VaccinationSchedule { Id = 15, AgeGroupsId = 7, TypesVaccinesId = 5, Dose = "3" },
                new VaccinationSchedule { Id = 16, AgeGroupsId = 7, TypesVaccinesId = 4, Dose = "4" },
                new VaccinationSchedule { Id = 17, AgeGroupsId = 8, TypesVaccinesId = 7, Dose = "1 dawka przypominająca" },
                new VaccinationSchedule { Id = 18, AgeGroupsId = 8, TypesVaccinesId = 8, Dose = "" },
                new VaccinationSchedule { Id = 19, AgeGroupsId = 9, TypesVaccinesId = 6, Dose = "2 dawka przypominająca" },
                new VaccinationSchedule { Id = 20, AgeGroupsId = 10, TypesVaccinesId = 9, Dose = "2 dawka przypominająca" },
                new VaccinationSchedule { Id = 21, AgeGroupsId = 11, TypesVaccinesId = 9, Dose = "3 dawka przypominająca" }
            );
        }
    }
}
