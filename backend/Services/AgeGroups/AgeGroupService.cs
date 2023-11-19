using AutoMapper;
using backend.ModelsDTO;
using backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.AgeGroups
{
    public class AgeGroupService : IAgeGroupService
    {
        private readonly IAgeGroupsRepository _ageGroupsRepository;

        private readonly IMapper _mapper;

        public AgeGroupService(IAgeGroupsRepository ageGroupsRepository, IMapper mapper)
        {
            _ageGroupsRepository = ageGroupsRepository;
            _mapper = mapper;
        }

        // <summary>
        /// Return all age groups from database
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<AgeGroupsDTO>>> GetAgeGroups()
        {
            var list = await _ageGroupsRepository.GetAll();

            if (list == null)
            {
                return new NotFoundResult();
            }

            var ageGroupsDTO = list.Select(ageGroup => _mapper.Map<AgeGroupsDTO>(ageGroup)).ToList();

            return ageGroupsDTO;
        }
    }
}
