﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Database;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231210100327_init3")]
    partial class init3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("backend.Entities.AgeGroups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AgeGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Noworodek"
                        },
                        new
                        {
                            Id = 2,
                            Name = "2 miesiąc życia"
                        },
                        new
                        {
                            Id = 3,
                            Name = "3-4 miesiąc życia"
                        },
                        new
                        {
                            Id = 4,
                            Name = "5-6 miesiąc życia"
                        },
                        new
                        {
                            Id = 5,
                            Name = "7 miesiąc życia"
                        },
                        new
                        {
                            Id = 6,
                            Name = "13-14 miesiąc życia"
                        },
                        new
                        {
                            Id = 7,
                            Name = "16-18 miesiąc życia"
                        },
                        new
                        {
                            Id = 8,
                            Name = "6 rok życia"
                        },
                        new
                        {
                            Id = 9,
                            Name = "10 rok życia"
                        },
                        new
                        {
                            Id = 10,
                            Name = "14 rok życia"
                        },
                        new
                        {
                            Id = 11,
                            Name = "19 rok życia"
                        });
                });

            modelBuilder.Entity("backend.Entities.Babysitter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kinship")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PESEL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Babysitters");
                });

            modelBuilder.Entity("backend.Entities.OtherVaccination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Appointment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostVaccinationReaction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostponementOfVaccination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeVaccination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VaccinationCardId")
                        .HasColumnType("int");

                    b.Property<int>("VaccinationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VaccinationCardId");

                    b.HasIndex("VaccinationId");

                    b.ToTable("OtherVaccination");
                });

            modelBuilder.Entity("backend.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfAbandonment")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfDeclaration")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PESEL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeOfVaccination")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("backend.Entities.PatientBabysitter", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("BabysitterId")
                        .HasColumnType("int");

                    b.HasKey("PatientId", "BabysitterId");

                    b.HasIndex("BabysitterId");

                    b.ToTable("PatientBabysitter");
                });

            modelBuilder.Entity("backend.Entities.Summons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Avoid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Send")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Summons");
                });

            modelBuilder.Entity("backend.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("backend.Entities.VaccinationCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Archive")
                        .HasColumnType("bit");

                    b.Property<bool>("Emigration")
                        .HasColumnType("bit");

                    b.Property<bool>("Lack")
                        .HasColumnType("bit");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Received")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReceivedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Send")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("VaccinationCard");
                });

            modelBuilder.Entity("backend.Entities.VaccinationInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgeGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Appointment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostVaccinationReaction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostponementOfVaccination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeVaccinationId")
                        .HasColumnType("int");

                    b.Property<int>("VaccinationCardId")
                        .HasColumnType("int");

                    b.Property<int>("VaccinationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgeGroupId");

                    b.HasIndex("TypeVaccinationId");

                    b.HasIndex("VaccinationCardId");

                    b.HasIndex("VaccinationId");

                    b.ToTable("VaccinationInfo");
                });

            modelBuilder.Entity("backend.Entities.VaccinationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypesVaccines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Gruźlica BCG"
                        },
                        new
                        {
                            Id = 2,
                            Name = "wzw B"
                        },
                        new
                        {
                            Id = 3,
                            Name = "DTP"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Hib"
                        },
                        new
                        {
                            Id = 5,
                            Name = "polio IPV"
                        },
                        new
                        {
                            Id = 6,
                            Name = "odra, świnka, różyczka"
                        },
                        new
                        {
                            Id = 7,
                            Name = "DTaP"
                        },
                        new
                        {
                            Id = 8,
                            Name = "polio OPV"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Td"
                        });
                });

            modelBuilder.Entity("backend.Entities.Vaccinations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfProduction")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vaccinations");
                });

            modelBuilder.Entity("backend.Entities.OtherVaccination", b =>
                {
                    b.HasOne("backend.Entities.VaccinationCard", "VaccinationCard")
                        .WithMany("OtherVaccination")
                        .HasForeignKey("VaccinationCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Entities.Vaccinations", "Vaccinations")
                        .WithMany("OtherVaccination")
                        .HasForeignKey("VaccinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VaccinationCard");

                    b.Navigation("Vaccinations");
                });

            modelBuilder.Entity("backend.Entities.PatientBabysitter", b =>
                {
                    b.HasOne("backend.Entities.Babysitter", "Babysitter")
                        .WithMany("PatientBabysitter")
                        .HasForeignKey("BabysitterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Entities.Patient", "Patient")
                        .WithMany("PatientBabysitter")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Babysitter");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("backend.Entities.Summons", b =>
                {
                    b.HasOne("backend.Entities.Patient", "Patient")
                        .WithMany("Summons")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("backend.Entities.VaccinationCard", b =>
                {
                    b.HasOne("backend.Entities.Patient", "Patient")
                        .WithOne("VaccinationCard")
                        .HasForeignKey("backend.Entities.VaccinationCard", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("backend.Entities.VaccinationInfo", b =>
                {
                    b.HasOne("backend.Entities.AgeGroups", "AgeGroups")
                        .WithMany("VaccinationInfo")
                        .HasForeignKey("AgeGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Entities.VaccinationType", "TypeVaccinations")
                        .WithMany("VaccinationInfo")
                        .HasForeignKey("TypeVaccinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Entities.VaccinationCard", "VaccinationCard")
                        .WithMany("VaccinationInfo")
                        .HasForeignKey("VaccinationCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Entities.Vaccinations", "Vaccinations")
                        .WithMany("VaccinationInfo")
                        .HasForeignKey("VaccinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgeGroups");

                    b.Navigation("TypeVaccinations");

                    b.Navigation("VaccinationCard");

                    b.Navigation("Vaccinations");
                });

            modelBuilder.Entity("backend.Entities.AgeGroups", b =>
                {
                    b.Navigation("VaccinationInfo");
                });

            modelBuilder.Entity("backend.Entities.Babysitter", b =>
                {
                    b.Navigation("PatientBabysitter");
                });

            modelBuilder.Entity("backend.Entities.Patient", b =>
                {
                    b.Navigation("PatientBabysitter");

                    b.Navigation("Summons");

                    b.Navigation("VaccinationCard");
                });

            modelBuilder.Entity("backend.Entities.VaccinationCard", b =>
                {
                    b.Navigation("OtherVaccination");

                    b.Navigation("VaccinationInfo");
                });

            modelBuilder.Entity("backend.Entities.VaccinationType", b =>
                {
                    b.Navigation("VaccinationInfo");
                });

            modelBuilder.Entity("backend.Entities.Vaccinations", b =>
                {
                    b.Navigation("OtherVaccination");

                    b.Navigation("VaccinationInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
