using DemoFirstProject.Model.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DemoFirstProject.Repository
{
    public interface IGET_CropMonthDataRepository
    {
        Task<List<GET_CropMonthData>> getasync(GET_CropMonthDataDomain input);
    }
}
