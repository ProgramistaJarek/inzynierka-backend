namespace backend.Entities
{
    public class Summons
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Evades { get; set; } = string.Empty;
        public DateTime Send { get; set; }
    }
}
