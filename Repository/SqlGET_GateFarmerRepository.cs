using System.Data;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoFirstProject.Repository
{
    public class SqlGET_GateFarmerRepository : IGET_GateFarmerRepository
    {
        private readonly ApplicatioDbContext dbContext;
        public SqlGET_GateFarmerRepository (ApplicatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<GET_GateFarmer>> getasync(GET_GateFarmerDomain input)
        {
            List<GET_GateFarmer> list = new List<GET_GateFarmer>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT TOP 20 * FROM[GET_GateFarmer]( '"+input.FAID + "','"+input.KEYWORD + "','" + input.COMPANYID + "' , '" + input.DEPTID + "')ORDER BY FAID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_GateFarmer
                        {
                            FAID	 = reader.GetString("FAID"),
                            UID	 = reader.GetString("UID"),
                            FCMTOKEN	 = reader.GetString("FCMTOKEN"),
                            REFID = reader.GetString("REFID"),
                            FNAME	 = reader.GetString("FNAME"),
                            FCONTACTNO	 = reader.GetString("FCONTACTNO"),
                            FBIRTHDATE	 = reader.GetString("FBIRTHDATE"),
                            FPANNO		 = reader.GetString("FPANNO"),
                            FADDHARNO = reader.GetString("FADDHARNO"),
                            FBANKNAME	 = reader.GetString("FBANKNAME"),
                            FACCONAME = reader.GetString("FACCONAME"),
                            FBRANCHNAME = reader.GetString("FBRANCHNAME"),
                            FACCOUNTNO	 = reader.GetString("FACCOUNTNO"),
                            FIFSCCODE = reader.GetString("FIFSCCODE"),
                            FAddress = reader.GetString("FAddress"),
                            FPINCODE = reader.GetString("FPINCODE"),
                            FSTATE	 = reader.GetString("FSTATE"),
                            FCITY		 = reader.GetString("FCITY"),
                            FCROPAREA	 = reader.GetString("FCROPAREA"),
                            FCROPTYPE	 = reader.GetString("FCROPTYPE"),
                            FSTATUS	 = reader.GetString("FSTATUS"),
                            FPROFILE = reader.GetString("FPROFILE"),
                            DATE = reader.GetString("DATE"),
                           


                        });
                    }
                }
            }
            return list;
        }
        public async Task<List<GET_GateFarmer>> Searchasync(GET_GateFarmerDomain input)
        {
            List<GET_GateFarmer> list = new List<GET_GateFarmer>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {

                command.CommandText = "SELECT  * FROM [GET_GateFarmer]('" + input.FAID + "','" + input.KEYWORD + "','" + input.COMPANYID + "' , '" + input.DEPTID + "')ORDER BY FAID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    {
                        while (await reader.ReadAsync())
                        {
                            list.Add(new GET_GateFarmer
                            {
                                FAID = reader.GetString("FAID"),
                                UID = reader.GetString("UID"),
                                FCMTOKEN = reader.GetString("FCMTOKEN"),
                                REFID = reader.GetString("REFID"),
                                FNAME = reader.GetString("FNAME"),
                                FCONTACTNO = reader.GetString("FCONTACTNO"),
                                FBIRTHDATE = reader.GetString("FBIRTHDATE"),
                                FPANNO = reader.GetString("FPANNO"),
                                FADDHARNO = reader.GetString("FADDHARNO"),
                                FBANKNAME = reader.GetString("FBANKNAME"),
                                FACCONAME = reader.GetString("FACCONAME"),
                                FBRANCHNAME = reader.GetString("FBRANCHNAME"),
                                FACCOUNTNO = reader.GetString("FACCOUNTNO"),
                                FIFSCCODE = reader.GetString("FIFSCCODE"),
                                FAddress = reader.GetString("FAddress"),
                                FPINCODE = reader.GetString("FPINCODE"),
                                FSTATE = reader.GetString("FSTATE"),
                                FCITY = reader.GetString("FCITY"),
                                FCROPAREA = reader.GetString("FCROPAREA"),
                                FCROPTYPE = reader.GetString("FCROPTYPE"),
                                FSTATUS = reader.GetString("FSTATUS"),
                                FPROFILE = reader.GetString("FPROFILE"),
                                DATE = reader.GetString("DATE"),
                            });
                        }
                    }
                }
                return list;
            }
        }
    }
}

