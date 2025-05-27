using System.Data;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoFirstProject.Repository
{
    public class SqlGET_MainGroupRepository : IGET_MainGroupRepository
    {
        private readonly ApplicatioDbContext dbContext;
        public SqlGET_MainGroupRepository(ApplicatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<GET_MainGroup>> getasync()
        {
            List<GET_MainGroup> list = new List<GET_MainGroup>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT TOP 20 * FROM[GET_MainGroup]( )";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_MainGroup
                        {
                            MGRPID = reader.GetString("MGRPID"),
                            ACCTM = reader.GetString("ACCTM"),


                        });
                    }
                }
            }
            return list;
        }
    }
}
