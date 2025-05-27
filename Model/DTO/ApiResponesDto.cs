using System.ComponentModel.DataAnnotations;

namespace DemoFirstProject.Model.DTO
{
    public class ApiResponesDto
    {
        [Key]
        public string ResponseCode { get; set; }

        public string ResponseMessage { get; set; }

        public string ResponseValues { get; set; }

        public int IsSuccessful { get; set; }
    }
}
