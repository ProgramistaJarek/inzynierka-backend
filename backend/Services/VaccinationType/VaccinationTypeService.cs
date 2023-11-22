using AutoMapper;
using backend.ModelsDTO;
using backend.Repositories;
using backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.VaccinationType
{
    public class VaccinationTypeService : IVaccinationTypeService
    {
        private readonly IVaccinationTypeRepository _repository;
        private readonly IMapper _mapper;

        public VaccinationTypeService(IVaccinationTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<VaccinationTypeDTO>>> GetVaccinationTypes()
        {
            var list = await _repository.GetAll();

            if (list == null)
            {
                return new NotFoundResult();
            }

            var vaccinationTypeDTO = list.Select(type => _mapper.Map<VaccinationTypeDTO>(type)).ToList();

            return vaccinationTypeDTO;
        }
    }
}
