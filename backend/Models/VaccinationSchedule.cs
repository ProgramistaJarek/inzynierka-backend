namespace backend.Models
{
    public class VaccinationSchedule
    {
        public int Id { get; set; }
        public int IdAgeGroups { get; set; }
        public int IdTypesVaccines { get; set; }
        public string Dose { get; set; } = String.Empty;

        public AgeGroups AgeGroups { get; set; }
        public TypesVaccines TypesVaccines { get; set; }

    }
}
