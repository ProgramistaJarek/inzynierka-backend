namespace backend.Models
{
    public class Vaccinations
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime DateOfProduction { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Amount { get; set; }
    }
}
