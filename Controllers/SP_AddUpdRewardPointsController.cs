using AutoMapper;
using DemoFirstProject.Model.Domain;
using DemoFirstProject.Model.DTO;
using DemoFirstProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoFirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SP_AddUpdRewardPointsController : ControllerBase
    {
        private readonly ISP_AddUpdRewardPointsRepository repository;
        private readonly IMapper mapper;

        public SP_AddUpdRewardPointsController(ISP_AddUpdRewardPointsRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpPost]

        public async Task<IActionResult> get(SP_AddUpdRewardPoints input)
        {
            var domain = await repository.getasync(input);
            var dto = mapper.Map<List<ApiResponesDto>>(domain);

            return Ok(dto);
        }

    }
}

