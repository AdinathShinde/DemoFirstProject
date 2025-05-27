using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface IGET_OTPRepository
    {
        Task<List<GET_OTP>> getasync(GET_OTPDomain input);
    }
}
