namespace backend.Entities
{
    public class TypesVaccines
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<VaccinationSchedule> VaccinationSchedules { get; set; } = null!;
    }
}
