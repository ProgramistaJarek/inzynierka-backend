namespace backend.Entities
{
    public class VaccinationSchedule
    {
        public int Id { get; set; }
        public string Dose { get; set; } = string.Empty;

        public int AgeGroupsId { get; set; }
        public AgeGroups AgeGroups { get; set; } = null!;
        public int TypesVaccinesId { get; set; }
        public TypesVaccines TypesVaccines { get; set; } = null!;

    }
}
