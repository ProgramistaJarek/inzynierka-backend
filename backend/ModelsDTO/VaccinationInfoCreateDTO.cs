﻿namespace backend.ModelsDTO
{
    public class VaccinationInfoCreateDTO
    {
        public string PostponementOfVaccination { get; set; } = string.Empty;
        public string PostVaccinationReaction { get; set; } = string.Empty;
        public string Appointment { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public int VaccinationId { get; set; }
        public int AgeGroupId { get; set; }
        public int TypeVaccinationId { get; set; }
    }
}
