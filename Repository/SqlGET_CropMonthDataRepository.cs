using System.Data;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoFirstProject.Repository
{
    public class SqlGET_CropMonthDataRepository : IGET_CropMonthDataRepository
    {
        private readonly ApplicatioDbContext dbContext;
        public SqlGET_CropMonthDataRepository (ApplicatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<GET_CropMonthData>> getasync(GET_CropMonthDataDomain input)
        {
            List<GET_CropMonthData> list = new List<GET_CropMonthData>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand()) {
                command.CommandText = "SELECT * FROM [GET_CropMonthData]('" + input.month + "','" + input.year + "')";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_CropMonthData {
                            month_name = reader.GetString("month_name"),
                            month_value = reader.GetInt32("month_value"),
                            crop_label = reader.GetString("crop_label"),
                            monthly_count = reader.GetInt32("monthly_count"),
                           



                        });
                    }
                }
            }
            return list;


        }
    }
}
