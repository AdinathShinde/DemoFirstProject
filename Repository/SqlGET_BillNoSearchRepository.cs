using System.Data;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoFirstProject.Repository
{
    public class SqlGET_BillNoSearchRepository : IGET_BillNoSearchRepository
    {
        private readonly ApplicatioDbContext dbContext;
        public SqlGET_BillNoSearchRepository(ApplicatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<GET_BillNoSearch>> getasync(GET_BillNoSearchDomain input)
        {
            
                List<GET_BillNoSearch> list = new List<GET_BillNoSearch>();
                using (var command = dbContext.Database.GetDbConnection().CreateCommand())
                {

                    command.CommandText = "SELECT TOP 20 * FROM [GET_BillNoSearch]('" + input.BTOKANNO + "','" + input.FNAME + "','" + input.VEHICLENO + "','"+input.KEYWORD + "','" +input.COMPANYID + "','" + input.DEPTID + "')";
                    dbContext.Database.OpenConnection();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            list.Add(new GET_BillNoSearch
                            {
                                BTOKANNO = reader.GetString("BTOKANNO"),
                                DATE = reader.GetString("DATE"),
                                MAID = reader.GetString("MAID"),
                                VEHICLENO = reader.GetString("VEHICLENO"),
                                REMAININGAMOUNT = reader.GetDouble("REMAININGAMOUNT"),
                                STATUS = reader.GetString("STATUS"),
                                FNAME = reader.GetString("FNAME"),
                                BAID = reader.GetString("BAID"),
                                SevaValue = reader.GetString("SevaValue"),
                                nSERVICETYPETITLE = reader.GetString("nSERVICETYPETITLE")


                            });
                        }
                    }
                }

                return list;
            }

        public async Task<List<GET_BillNoSearch>> Searchasync(GET_BillNoSearchDomain input)
        {

            List<GET_BillNoSearch> list = new List<GET_BillNoSearch>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {

                command.CommandText = "SELECT  * FROM [GET_BillNoSearch]('" + input.BTOKANNO + "','" + input.FNAME + "','" + input.VEHICLENO + "','" + input.KEYWORD + "','" + input.COMPANYID + "','" + input.DEPTID + "')";
                dbContext.Database.OpenConnection();
                    using( var reader = await  command.ExecuteReaderAsync()) {
                    while (reader.Read()) {
                        list.Add(new GET_BillNoSearch
                        {
                            BTOKANNO = reader.GetString("BTOKANNO"),
                            DATE = reader.GetString("DATE"),
                            MAID = reader.GetString("MAID"),
                            VEHICLENO = reader.GetString("VEHICLENO"),
                            REMAININGAMOUNT = reader.GetDouble("REMAININGAMOUNT"),
                            STATUS = reader.GetString("STATUS"),
                            FNAME = reader.GetString("FNAME"),
                            BAID = reader.GetString("BAID"),
                            SevaValue = reader.GetString("SevaValue"),
                            nSERVICETYPETITLE = reader.GetString("nSERVICETYPETITLE")


                        });
                    }
                }
            }

            return list;
        }
    }
}