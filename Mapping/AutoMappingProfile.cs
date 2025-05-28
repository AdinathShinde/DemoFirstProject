using AutoMapper;
using DemoFirstProject.Model.Domain;
using DemoFirstProject.Model.DTO;

namespace DemoFirstProject.Mapping
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<ApiRespones, ApiResponesDto>().ReverseMap();
            CreateMap<GET_Notification , GET_Notificationdto>().ReverseMap();
            CreateMap<GET_BankName, GET_BankNamedto>().ReverseMap();
            CreateMap<GET_CategoryMaster, GET_CategoryMasterdto>().ReverseMap();
            CreateMap<GET_VyapariLimit, GET_VyapariLimitdto>().ReverseMap();
            CreateMap<GET_TopFarmer, GET_TopFarmerdto>().ReverseMap();
            CreateMap<GET_RewardPoint, GET_RewardPointdto>().ReverseMap();
            CreateMap<GET_CropItem, GET_CropItemdto>().ReverseMap();    
            CreateMap<GET_MarketStore, GET_MarketStoredto>().ReverseMap();
            CreateMap<GET_GateCashInvert, GET_GateCashInvertdto>().ReverseMap();
            CreateMap<GET_OTP, GET_OTPdto>().ReverseMap();
            CreateMap<GET_FamilyDetailsById, GET_FamilyDetailsByIddto>().ReverseMap();
            CreateMap<Notification, Notificationdto>().ReverseMap();
            CreateMap<GET_MainGroup,GET_MainGroupDto>().ReverseMap();
            CreateMap<GET_DashCount,GET_DashCountDto>().ReverseMap();
            CreateMap<GET_DashCount, GET_CropItemdto>().ReverseMap();
            CreateMap<GET_BillNoSearch, GET_BillNoSearchDto>().ReverseMap();
        }
    }
}
