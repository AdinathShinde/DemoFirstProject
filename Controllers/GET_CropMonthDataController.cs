using AutoMapper;
using DemoFirstProject.Model.Domain;
using DemoFirstProject.Model.DTO;
using DemoFirstProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DemoFirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GET_CropMonthDataController : ControllerBase
    {
        private readonly IGET_CropMonthDataRepository repository;
        private readonly IMapper mapper;
        public GET_CropMonthDataController(IGET_CropMonthDataRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> getasync(GET_CropMonthDataDomain input)
        {
            try
            {
                var domain = await repository.getasync(input);
                var dto = mapper.Map<List<GET_CropMonthDataDto>>(domain);
                 return Ok(dto);
               
            }
            catch (Exception ex)
            {
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        }
    }
}
