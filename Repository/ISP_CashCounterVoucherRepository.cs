using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface ISP_CashCounterVoucherRepository
    {
        Task<List<ApiRespones>> getasync(SP_CashCounterVoucher input);
    }
}
