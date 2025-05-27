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
    public class GET_MarketStoreController : ControllerBase
    {
        private readonly IGET_MarketStoreRepository repository;
        private readonly  IMapper mapper;
        public GET_MarketStoreController(IGET_MarketStoreRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpPost]
        public async  Task<ActionResult> getasync (GET_MarketStoreDomain input)
        {
            try
            {
                var domain = await repository.getasync(input);
                var dto = mapper.Map<List<GET_MarketStoredto>>(domain);
            return Ok(dto);
            }
            catch (Exception ex) {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
    }
        [HttpPost("_Search")]
        public async Task<IActionResult> Search([FromBody] GET_MarketStoreDomain input)
        {
            try
            {

                var domain = await repository.Searchasync(input);

                var dto = mapper.Map<List<GET_MarketStoredto>>(domain);
                return Ok(dto);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
    }
}
    
