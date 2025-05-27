using System.Data;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DemoFirstProject.Repository
{
    public class SqlGET_CategoryMasterRepository : IGET_CategoryMasterRepository
    {

        private readonly ApplicatioDbContext dbContext;
        public SqlGET_CategoryMasterRepository(ApplicatioDbContext dbContext)

        {
            this.dbContext = dbContext;
            
        }
        public async Task<List<GET_CategoryMaster>> getasync(GET_CategoryMasterDomain input)
        {
        List<GET_CategoryMaster> list = new List<GET_CategoryMaster>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT TOP 20 * FROM [GET_CategoryMaster]('" + input.CTAID + "' , '" + input.COMPANYID + "' ,  '" + input.DEPTID + "')ORDER BY CTAID DESC";
              
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_CategoryMaster
                        {                     
                            CTAID = reader.GetString("CTAID"),
                            CTNAME = reader.GetString("CTNAME"),
                            CTID = reader.GetString("CTID"),
                            CTSUBCATGORYID = reader.GetString("CTSUBCATGORYID"),
                            CTTYPE = reader.GetString("CTTYPE"),

                        });               
                    }
                }
            }
            return list;
        }
}

}

