using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IPatientBabysitterRepository : IRepositoryBase<PatientBabysitter>
    {
        Task<PatientBabysitter> DoesPatientBabysitterExist(int babysitterId, int patientId);
        Task RemovePatientBabysitter(PatientBabysitter patientBabysitter);
    }
}
