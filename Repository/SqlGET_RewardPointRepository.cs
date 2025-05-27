using System.Data;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoFirstProject.Repository
{
    public class SqlGET_RewardPointRepository : IGET_RewardPointRepository
    {
        private readonly ApplicatioDbContext dbContext;
        public SqlGET_RewardPointRepository(ApplicatioDbContext dbContext)
        {

            this.dbContext = dbContext;
        }
        public async Task<List<GET_RewardPoint>> getasync(GET_RewardPointdtoDomain input)
        {
            List<GET_RewardPoint> list = new List<GET_RewardPoint>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT TOP 20 * FROM[GET_RewardPoint](   '" + input.RPID + "','"+input.KEYWORD+"', '" + input.COMPANYID + "' , '" + input.DEPTID + "')ORDER BY RPID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_RewardPoint
                        {
                            RPID  = reader.GetString("RPID"),
                            DATE = reader.GetString("DATE"),
                            PPTYPE = reader.GetString("PPTYPE"),
                            REWARDPOINTS = reader.GetString("REWARDPOINTS"),
                            STATUS = reader.GetBoolean("STATUS"),
                            UAID = reader.GetString("UAID"),
                            DEPTID = reader.GetString("DEPTID"),
                            ISDELETED = reader.GetBoolean("ISDELETED"),
                            ASID = reader.GetString("ASID"),
                            SYSDT = reader.GetString("SYSDT"),
                            PERSONTYPE = reader.GetString("PERSONTYPE"),





                        });
                    }
                }
            }
            return list;
        }
    }
}

