using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface ISP_AddUpdOTPRepository
    {
        Task<List<ApiRespones>>getasync(SP_AddUpdOTP input);
    }
}
