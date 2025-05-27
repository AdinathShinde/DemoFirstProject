using System.Data;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoFirstProject.Repository
{
    public class SqlGET_DashCountRepository : IGET_DashCountRepository
    {
        private readonly ApplicatioDbContext dbContext;
        public SqlGET_DashCountRepository(ApplicatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<GET_DashCount>> getasync()
        {
            List<GET_DashCount> list = new List<GET_DashCount>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand()) 
            {
                command.CommandText = "SELECT * FROM [GET_DashCount]()";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_DashCount
                        {

                            FarmerCount = reader.GetInt32("FarmerCount"),
                            TransporterCount = reader.GetInt32("TransporterCount"),
                            VyapariCount = reader.GetInt32("VyapariCount"),


                        });
                }
            }
        }
            return list;
        }
}
}