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
    public class GET_GateFarmerController : ControllerBase
    {
        private readonly IGET_GateFarmerRepository repository;
        private readonly IMapper mapper;
        public GET_GateFarmerController(IGET_GateFarmerRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> getasync(GET_GateFarmerDomain input)
        {
            try
            {
                var domain = await repository.getasync(input);
                var dto = mapper.Map<List<GET_GateFarmer>>(domain);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("_Search")]
        public async Task<IActionResult> Search([FromBody] GET_GateFarmerDomain input)
        {
            try
            {

                var domain = await repository.Searchasync(input);

                var dto = mapper.Map<List<GET_GateFarmerDto>>(domain);
                return Ok(dto);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
    }
}