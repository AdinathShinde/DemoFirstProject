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
    public class SP_DeleteCaretController : ControllerBase
    {
        private readonly ISP_DeleteCaretRepository repository;
        private readonly IMapper mapper;

        public SP_DeleteCaretController(ISP_DeleteCaretRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpPost]

        public async Task<IActionResult> get(SP_DeleteCaret input)
        {
            var domain = await repository.getasync(input);
            var dto = mapper.Map<List<ApiResponesDto>>(domain);

            return Ok(dto);
        }

    }
}
