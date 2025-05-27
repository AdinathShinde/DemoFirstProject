using System.ComponentModel.DataAnnotations;

namespace DemoFirstProject.Model.Domain
{
    public class ApiRespones
    {
        [Key]
        public string ResponseCode { get; set; }

        public string ResponseMessage { get; set; }

        public string ResponseValues { get; set; }

        public int IsSuccessful { get; set; }
    }
}
