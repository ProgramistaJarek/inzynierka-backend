namespace backend.Models
{
    public class AgeGroups
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public ICollection<VaccinationSchedule> VaccinationSchedules { get; set; }
    }
}
