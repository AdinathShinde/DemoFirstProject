using System.Data;
using System.Reflection;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoFirstProject.Repository
{
    public class SqlGET_OTPRepository : IGET_OTPRepository
    {

        private readonly ApplicatioDbContext dbContext;
        public SqlGET_OTPRepository(ApplicatioDbContext dbContext)

        {
            this.dbContext = dbContext;
        }

        public async Task<List<GET_OTP>> getasync(GET_OTPDomain input)
        {

            List<GET_OTP> list = new List<GET_OTP>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT TOP 20 * FROM[GET_OTP]('"+ input.PKOID +"', '" + input.COMPANYID + "' , '" + input.DEPTID + "')ORDER BY PKOID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_OTP
                        {
                            PKOID = reader.GetString("PKOID"),
                            MOBILE = reader.GetString("MOBILE"),
                            OTP = reader.GetInt32("OTP"),
                            VNAME = reader.GetString("VNAME"),

                        });
                    }
                }
            }
            return list;
        }
    }
}

