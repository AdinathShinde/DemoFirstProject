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
    public class GET_ShopAlotController : ControllerBase
    {
        private readonly IGET_ShopAlotRepository repository;
        private readonly IMapper mapper;
        public GET_ShopAlotController(IGET_ShopAlotRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> getasync(GET_ShopAlotDomain input)
        {
            try
            {
                var domain = await repository.getasync(input);
                var dto = mapper.Map<List<GET_ShopAlot>>(domain);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("_Search")]
        public async Task<IActionResult> Searchasync(GET_ShopAlotDomain input)
        {
            try
            {
                var domain = await repository.Searchasync(input);
                var dto = mapper.Map<List<GET_ShopAlotDto>>(domain);
                return Ok(dto);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
    }

}