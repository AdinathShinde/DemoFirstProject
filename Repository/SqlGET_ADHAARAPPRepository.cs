using System.Data;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoFirstProject.Repository
{
    public class SqlGET_ADHAARAPPRepository : IGET_ADHAARAPPRepository
    {
        private readonly ApplicatioDbContext dbContext;
        public SqlGET_ADHAARAPPRepository(ApplicatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<GET_ADHAARAPP>> getasync(GET_ADHAARAPPDomain input)
        {
            List<GET_ADHAARAPP> list = new List<GET_ADHAARAPP>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT TOP 20 * FROM[GET_ADHAARAPP]( '" + input.FADDHARNO + "')";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_ADHAARAPP
                        {
                            FAID = reader.GetString("FAID"),
                            FNAME		 = reader.GetString("FNAME"),
                            FADDHARNO	 = reader.GetString("FADDHARNO"),
                            FBIRTHDATE = reader.GetString("FBIRTHDATE"),
                            


                        });
                    }
                }
            }
            return list;
        }

        public async Task<List<GET_ADHAARAPP>> searchasync(GET_ADHAARAPPDomain input)
        {
            List<GET_ADHAARAPP> list = new List<GET_ADHAARAPP>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT  * FROM[GET_ADHAARAPP]( '" + input.FADDHARNO + "')";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_ADHAARAPP
                        {
                            FAID = reader.GetString("FAID"),
                            FNAME = reader.GetString("FNAME"),
                            FADDHARNO = reader.GetString("FADDHARNO"),
                            FBIRTHDATE = reader.GetString("FBIRTHDATE"),



                        });
                    }
                }
            }
            return list;
        
    }
    }
}

