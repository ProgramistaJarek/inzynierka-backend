using AutoMapper;
using backend.ModelsDTO;
using backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.Babysitters
{
    public class BabysittersService : IBabysittersService
    {
        private readonly IBabysitterRepository _babysitterRepository;

        private readonly IMapper _mapper;

        public BabysittersService(IBabysitterRepository babysitterRepository, IMapper mapper)
        {
            _babysitterRepository = babysitterRepository;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<BabysitterDTO>>> GetBabysitters()
        {
            var list = await _babysitterRepository.GetAll();

            if (list == null)
            {
                return new NotFoundResult();
            }

            var babysittersDTO = list.Select(babysitter => _mapper.Map<BabysitterDTO>(babysitter)).ToList();

            return babysittersDTO;
        }
    }
}
