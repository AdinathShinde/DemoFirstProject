using AutoMapper;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using DemoFirstProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoFirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GET_DashCountController : ControllerBase
    {
        private readonly IGET_DashCountRepository repository;
        private readonly IMapper mapper;
        public GET_DashCountController(IGET_DashCountRepository repository, IMapper mapper)

        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult>getasync()
        {
            try
            {
                var domain = await repository.getasync();
                var dto = mapper.Map<List<GET_DashCount>>(domain);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");

            }
        }
    }

}
