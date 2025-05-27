using System.Data;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoFirstProject.Repository
{
    public class SqlSP_CashCounterVoucherRepository : ISP_CashCounterVoucherRepository
    {
        private readonly ApplicatioDbContext dbContext;
        public SqlSP_CashCounterVoucherRepository(ApplicatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<ApiRespones>> getasync(SP_CashCounterVoucher input)
        {
            List<ApiRespones> result = new List<ApiRespones>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "[SP_CashCounterVoucher]";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var parameter = command.CreateParameter();
                parameter.ParameterName = "@UAID";
                parameter.Value = input.UAID;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@OrganizationID";
                parameter.Value = input.OrganizationID;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@DivisionID";
                parameter.Value = input.DivisionID;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@VoucherDate";
                parameter.Value = input.VoucherDate;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@FARMERACC";
                parameter.Value = input.FARMERACC;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@CASHACC";
                parameter.Value = input.CASHACC;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@VoucherAmount";
                parameter.Value = input.VoucherAmount;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@ReferenceKey";
                parameter.Value = input.ReferenceKey;
                command.Parameters.Add(parameter);


                parameter = command.CreateParameter();
                parameter.ParameterName = "@VREFF";
                parameter.Value = input.VREFF;
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
