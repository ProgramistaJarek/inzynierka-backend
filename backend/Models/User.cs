namespace backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string PasswordSalt { get; set; } = String.Empty;
    }
}
