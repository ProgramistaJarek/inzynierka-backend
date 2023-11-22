namespace backend.Entities
{
    public class VaccinationType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public IEnumerable<VaccinationInfo> VaccinationInfo { get; set; } = null!;
    }
}
