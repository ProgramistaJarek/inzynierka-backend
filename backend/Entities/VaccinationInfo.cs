using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class VaccinationInfo
    {
        public int Id { get; set; }
        public string PostponementOfVaccination { get; set; } = string.Empty;
        public string PostVaccinationReaction { get; set; } = string.Empty;
        public string Appointment { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public DateTime ScheduledVaccination { get; set; }
        public int Dose { get; set; }
        public string Comments { get; set; } = string.Empty;

        public int VaccinationCardId { get; set; }
        public VaccinationCard VaccinationCard { get; set; } = null!;
        public int VaccinationId { get; set; }
        public Vaccinations Vaccinations { get; set; } = null!;
        public int AgeGroupId { get; set; }
        public AgeGroups AgeGroups { get; set; } = null!;
        public int TypeVaccinationId { get; set; }
        public VaccinationType TypeVaccinations { get; set; } = null!;
    }
}
