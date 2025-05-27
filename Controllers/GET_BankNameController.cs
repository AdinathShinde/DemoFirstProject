using AutoMapper;
using DemoFirstProject.Model.Domain;
using DemoFirstProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoFirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GET_BankNameController : ControllerBase
    {
        private readonly IGET_BankNameRepository repository;
        private readonly IMapper mapper;
        public GET_BankNameController(IGET_BankNameRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult>getasync(GET_BankNameDomain input)
        { 
            try
            {
                var domain = await repository.getasync(input);
                var dto = mapper.Map<List<GET_BankName>>(domain);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

