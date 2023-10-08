namespace backend.Entities
{
    public class VaccinationSchedule
    {
        public int Id { get; set; }
        public int IdAgeGroups { get; set; }
        public int IdTypesVaccines { get; set; }
        public string Dose { get; set; } = string.Empty;

        public AgeGroups AgeGroups { get; set; }
        public TypesVaccines TypesVaccines { get; set; }

    }
}
