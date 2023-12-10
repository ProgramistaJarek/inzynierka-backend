namespace backend.Entities
{
    public class Vaccinations
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Series { get; set; } = string.Empty;
        public DateTime DateOfProduction { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Amount { get; set; }

        public IEnumerable<VaccinationInfo> VaccinationInfo { get; set; } = null!;
        public IEnumerable<OtherVaccination> OtherVaccination { get; set; } = null!;
    }
}
