using System.Data;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoFirstProject.Repository
{
    public class SqlGET_PARKINGRepository : IGET_PARKINGRepository
    {
        private readonly ApplicatioDbContext dbContext;
        public SqlGET_PARKINGRepository(ApplicatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<GET_PARKING>> getasync(GET_PARKINGDomain input)
        {
            List<GET_PARKING> list = new List<GET_PARKING>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand()) {
                command.CommandText = "SELECT  * FROM [GET_PARKING]('" + input.PAID + "','" + input.KEYWORD + "','" + input.COMPANYID + "','" + input.DEPTID + "') ORDER BY PAID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {

                        list.Add(new GET_PARKING
                        {
                            PAID = reader.GetString("PAID"),
                            AUTOID = reader.GetString("AUTOID"),
                            DATE = reader.GetString("DATE"),
                            TYPE = reader.GetString("TYPE"),
                            TOTALJALI = reader.GetInt32("TOTALJALI"),
                            VNUMBER = reader.GetString("VNUMBER"),
                            VOWNERNAME = reader.GetString("VOWNERNAME"),
                            VTYPE = reader.GetString("VTYPE"),
                            VCHARGE = reader.GetDouble("VCHARGE"),
                            STATUS = reader.GetBoolean("STATUS"),
                            PARKTYPE = reader.GetString("PARKTYPE"),
                            TRANSACTIONMODE = reader.GetString("TRANSACTIONMODE"),
                            NAVEKHATE = reader.GetString("NAVEKHATE"),






                        });
                    }
                }
            }
            return list;
        }
    

        public async Task<List<GET_PARKING>> Searchasync(GET_PARKINGDomain input)
        {
            List<GET_PARKING> list = new List<GET_PARKING>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT TOP 20 * FROM [GET_PARKING]('" + input.PAID + "','" + input.KEYWORD + "','" + input.COMPANYID + "','" + input.DEPTID + "') ORDER BY PAID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {

                        list.Add(new GET_PARKING
                        {
                            PAID = reader.GetString("PAID"),
                            AUTOID = reader.GetString("AUTOID"),
                            DATE = reader.GetString("DATE"),
                            TYPE = reader.GetString("TYPE"),
                            TOTALJALI = reader.GetInt32("TOTALJALI"),
                            VNUMBER = reader.GetString("VNUMBER"),
                            VOWNERNAME = reader.GetString("VOWNERNAME"),
                            VTYPE = reader.GetString("VTYPE"),
                            VCHARGE = reader.GetDouble("VCHARGE"),
                            STATUS = reader.GetBoolean("STATUS"),
                            PARKTYPE = reader.GetString("PARKTYPE"),
                            TRANSACTIONMODE = reader.GetString("TRANSACTIONMODE"),
                            NAVEKHATE = reader.GetString("NAVEKHATE"),






                        });
                    }
                }
            }
            return list;
        }
    }
}
