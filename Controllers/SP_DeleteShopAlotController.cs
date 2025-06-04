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
    public class SP_DeleteShopAlotController : ControllerBase
    {
        private readonly ISP_DeleteShopAlotRepository repository;
        private readonly IMapper mapper;

        public SP_DeleteShopAlotController (ISP_DeleteShopAlotRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpPost]

        public async Task<IActionResult> get(SP_DeleteShopAlot input)
        {
            var domain = await repository.getasync(input);
            var dto = mapper.Map<List<ApiResponesDto>>(domain);

            return Ok(dto);
        }

    }
}