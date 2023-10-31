using System.ComponentModel.DataAnnotations;

namespace backend.ModelsDTO
{
    public class BabysitterCreateDTO
    {
        [Required] public string FirstName { get; set; } = string.Empty;
        [Required] public string LastName { get; set; } = string.Empty;
        [Required] public string PESEL { get; set; } = string.Empty;
        [Required] public string PhoneNumber { get; set; } = string.Empty;
        [Required] public string Adress { get; set; } = string.Empty;
        [Required] public string Kinship { get; set; } = string.Empty;
    }
}
