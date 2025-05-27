using System.Data;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoFirstProject.Repository
{
    public class SqlSP_AddUpdOTPRepository :ISP_AddUpdOTPRepository
    {
        private readonly ApplicatioDbContext dbContext;
        public SqlSP_AddUpdOTPRepository(ApplicatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<ApiRespones>> getasync(SP_AddUpdOTP input)
        {
            List<ApiRespones> result = new List<ApiRespones>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "[SP_AddUpdOTP]";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var parameter = command.CreateParameter();
                parameter.ParameterName = "@PKOID";
                parameter.Value = input.PKOID;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@VPAID";
                parameter.Value = input.VPAID;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@MOBILE";
                parameter.Value = input.MOBILE;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@OTP";
                parameter.Value = input.OTP;
                command.Parameters.Add(parameter);
                
                parameter = command.CreateParameter();
                parameter.ParameterName = "@VNAME";
                parameter.Value = input.VNAME;
                command.Parameters.Add(parameter);


                parameter = command.CreateParameter();
                parameter.ParameterName = "@COMPANYID";
                parameter.Value = input.COMPANYID;
                command.Parameters.Add(parameter);

                

                parameter = command.CreateParameter();
                parameter.ParameterName = "@DEPTID";
                parameter.Value = input.DEPTID;
                command.Parameters.Add(parameter);

                dbContext.Database.OpenConnection();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        result.Add(new ApiRespones
                        {

                            IsSuccessful = reader.GetInt32("IsSuccessful"),
                            ResponseCode = reader.GetString("ResponseCode"),
                            ResponseMessage = reader.GetString("ResponseMessage"),
                            ResponseValues = reader.GetString("ResponseValues")

                        });
                    }
                }


            }
            return result;
        }

       
    }
}
