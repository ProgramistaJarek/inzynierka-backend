namespace backend.ModelsDTO
{
    public class VaccinationsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Series { get; set; } = string.Empty;
        public DateTime DateOfProduction { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Amount { get; set; }
    }
}
