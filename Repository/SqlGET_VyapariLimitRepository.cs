using System.Data;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DemoFirstProject.Repository
{
    public class SqlGET_VyapariLimitRepository : IGET_VyapariLimitRepository
    {
        private readonly ApplicatioDbContext dbContext;
        public SqlGET_VyapariLimitRepository(ApplicatioDbContext dbContext) 
        {
            this.dbContext = dbContext;
            
    }
        public async Task<List<GET_VyapariLimit>> getasync(GET_VyapariLimitDomain input)
        {
            List<GET_VyapariLimit> list = new List<GET_VyapariLimit>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT TOP 20 * FROM[GET_VyapariLimit](   '" +input.VSAID+"', '" + input.COMPANYID + "' , '" + input.DEPTID + "')ORDER BY VSAID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_VyapariLimit
                        {
                            VSAID = reader.GetString("VSAID"),
                            STARTDATE = reader.GetString("STARTDATE"),
                            ENDDATE = reader.GetString("ENDDATE"),
                            DUEDATE = reader.GetString("DUEDATE"),
                            KALAVADHI= reader.GetString("KALAVADHI")



                        });
                    }
                }
            }
            return list;
        }
    }
}
