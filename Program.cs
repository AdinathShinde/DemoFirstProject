using DemoFirstProject.Data;
using DemoFirstProject.Mapping;
using DemoFirstProject.Repository;
using Microsoft.EntityFrameworkCore;

using OfficeOpenXml;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicatioDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("shadimuharathConStr")));

builder.Services.AddAutoMapper(typeof(AutoMappingProfile));

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
builder.Services.AddScoped<ExcelExporter>();
builder.Services.AddScoped<SqlFunctionExecutor>();
builder.Services.AddScoped<ISP_AddUpdCaretRepository , SqlSP_AddUpdCaretRepository>();
builder.Services.AddScoped<ISP_AddUpdRewardPointsRepository, SqlSP_AddUpdRewardPointsRepository>();
builder.Services.AddScoped<ISP_AddUpdCropItemRepository, SqlSP_AddUpdCropItemRepository > ();
builder.Services.AddScoped<IGET_NotificationRepository, SqlGET_NotificationRepository>();
builder.Services.AddScoped<IGET_BankNameRepository, SqlGET_BankNameRepository>();
builder.Services.AddScoped<IGET_CategoryMasterRepository, SqlGET_CategoryMasterRepository>();
builder.Services.AddScoped<ISP_AddUpdFarmerdtRepository, SqlSP_AddUpdFarmerRepository>();
builder.Services.AddScoped<IGET_VyapariLimitRepository, SqlGET_VyapariLimitRepository>();
builder.Services.AddScoped<IGET_TopFarmerRepository, SqlGET_TopFarmerRepository> ();
builder.Services.AddScoped<ISP_CashCounterVoucherRepository, SqlSP_CashCounterVoucherRepository> ();
builder.Services.AddScoped<IGET_RewardPointRepository, SqlGET_RewardPointRepository> ();
builder.Services.AddScoped<ISP_DeleteRewardRepository, SqlSP_DeleteRewardRepository> ();
builder.Services.AddScoped<ISP_DeleteCaretRepository, SqlSP_DeleteCareRepository> ();
builder.Services.AddScoped<IGET_CropItemRepository, SqlGET_CropItemRepository> ();  
builder.Services.AddScoped<IGET_MarketStoreRepository, SqlGET_MarketStoreRepository> ();
builder.Services.AddScoped<IGET_GateCashInvertRepository,SqlGET_GateCashInvertRepository> ();
builder.Services.AddScoped<IGET_OTPRepository, SqlGET_OTPRepository> ();
builder.Services.AddScoped<ISP_AddUpdOTPRepository,SqlSP_AddUpdOTPRepository> ();
builder.Services.AddScoped<ISP_DeletFamilyRepository, SqlSP_DeletFamilyRepository> ();
builder.Services.AddScoped<IGET_FamilyDetailsByIdRepository, SqlGET_FamilyDetailsByIdRepository> ();
builder.Services.AddScoped<INotificationRepository,SqlNotificationRepository> ();
builder.Services.AddScoped<IGET_MainGroupRepository,SqlGET_MainGroupRepository> ();
builder.Services.AddScoped<IGET_DashCountRepository,SqlGET_DashCountRepository> ();
builder.Services.AddScoped<IGET_BillNoSearchRepository,SqlGET_BillNoSearchRepository> ();
builder.Services.AddScoped<IDocumentUploadRepository,SqlDocumentUploadRepository> ();
builder.Services.AddScoped<IGET_CropMonthDataRepository,SqlGET_CropMonthDataRepository> ();
builder.Services.AddScoped<IGET_PARKINGRepository,SqlGET_PARKINGRepository> ();
builder.Services.AddScoped<IGET_ShopAlotRepository,SqlGET_ShopAlotRepository> ();
builder.Services.AddScoped<ISP_DeleteShopAlotRepository, SqlSP_DeleteShopAlotRepository> ();
builder.Services.AddScoped<IGET_ProductMasterRepository, SqlGET_ProductMasterRepository> ();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
                                                            
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
