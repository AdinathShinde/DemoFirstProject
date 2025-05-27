using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoFirstProject.Repository
{
    public class SqlGET_BankNameRepository : IGET_BankNameRepository
    {

        private readonly ApplicatioDbContext dbContext;
        public SqlGET_BankNameRepository(ApplicatioDbContext dbContext)

        {
            this.dbContext = dbContext;
        }

        public async Task<List<GET_BankName>> getasync(GET_BankNameDomain input)
        {

            List<GET_BankName> list = new List<GET_BankName>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT TOP 20 * FROM[GET_BankName]( '" +  input.COMPANYID + "' , '" +  input.DEPTID + "')ORDER BY BANKID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_BankName
                        {
                            BANKID = reader.GetString(reader.GetOrdinal("BANKID")),
                            BANKNAME = reader.GetString(reader.GetOrdinal("BANKNAME")),


                        });
                    }
                }
            }
            return list;
        }
    }
}
