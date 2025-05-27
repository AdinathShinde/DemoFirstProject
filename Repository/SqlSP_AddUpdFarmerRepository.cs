using System.Data;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoFirstProject.Repository
{
    public class SqlSP_AddUpdFarmerRepository : ISP_AddUpdFarmerdtRepository
    {
        private readonly ApplicatioDbContext dbContext;
        public SqlSP_AddUpdFarmerRepository(ApplicatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<ApiRespones>> getasync(List<SP_AddUpdFarmer> input)
        {


                List<ApiRespones> result = new List<ApiRespones>();
            {
                foreach (var SP_AddUpdFarmer in input)

                
                    using (var command = dbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "[SP_AddUpdFarmer]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@FAID ";
                    parameter.Value = SP_AddUpdFarmer.FAID;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@UID";
                    parameter.Value = SP_AddUpdFarmer.UID;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@FCMTOKEN";
                    parameter.Value = SP_AddUpdFarmer.FCMTOKEN;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@REFID";
                    parameter.Value = SP_AddUpdFarmer.REFID;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@UAID";
                    parameter.Value = SP_AddUpdFarmer.UAID;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@FNAME";
                    parameter.Value = SP_AddUpdFarmer.FNAME;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@FCONTACTNO";
                    parameter.Value = SP_AddUpdFarmer.FCONTACTNO;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@FBIRTHDATE";
                    parameter.Value = SP_AddUpdFarmer.FBIRTHDATE;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@FPANNO";
                    parameter.Value = SP_AddUpdFarmer.FPANNO;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@FADDHARNO";
                    parameter.Value = SP_AddUpdFarmer.FADDHARNO;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@FBANKNAME";
                    parameter.Value = SP_AddUpdFarmer.FBANKNAME;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@FACCONAME";
                    parameter.Value = SP_AddUpdFarmer.FACCONAME;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@FBRANCHNAME";
                    parameter.Value = SP_AddUpdFarmer.FBRANCHNAME;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@FACCOUNTNO";
                    parameter.Value = SP_AddUpdFarmer.FACCOUNTNO;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@FIFSCCODE";
                    parameter.Value = SP_AddUpdFarmer.FIFSCCODE;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@FAddress";
                    parameter.Value = SP_AddUpdFarmer.FAddress;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@FPINCODE";
                    parameter.Value = SP_AddUpdFarmer.FPINCODE;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@FSTATE";
                    parameter.Value = SP_AddUpdFarmer.FSTATE;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@FCITY";
                    parameter.Value = SP_AddUpdFarmer.FCITY;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@FCROPAREA";
                    parameter.Value = SP_AddUpdFarmer.FCROPAREA;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@FCROPTYPE";
                    parameter.Value = SP_AddUpdFarmer.FCROPTYPE;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@FSTATUS";
                    parameter.Value = SP_AddUpdFarmer.FSTATUS;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@FPROFILE";
                    parameter.Value = SP_AddUpdFarmer.FPROFILE;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@DATE";
                    parameter.Value = SP_AddUpdFarmer.DATE;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@COMPANYID";
                    parameter.Value = SP_AddUpdFarmer.COMPANYID;
                    command.Parameters.Add(parameter);


                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@DEPTID";
                    parameter.Value = SP_AddUpdFarmer.DEPTID;
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
}