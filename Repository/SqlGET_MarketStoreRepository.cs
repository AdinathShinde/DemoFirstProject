using System.Data;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoFirstProject.Repository
{
    public class SqlGET_MarketStoreRepository : IGET_MarketStoreRepository
    {
        private readonly ApplicatioDbContext dbContext;
        public SqlGET_MarketStoreRepository(ApplicatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<GET_MarketStore>> getasync(GET_MarketStoreDomain input)
        {
            List<GET_MarketStore> list = new List<GET_MarketStore>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {

                command.CommandText = "SELECT TOP 20 * FROM [GET_MarketStore] ('" + input.STORID + "','" + input.KEYWORD + "','" + input.COMPANYID + "' ,'" + input.DEPTID + "' )ORDER BY STORID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_MarketStore
                        {
                            STORID = reader.GetString("STORID"),
                            STOREID = reader.GetString("STOREID"),
                            SDATE = reader.GetString("SDATE"),
                            STORENAME = reader.GetString("STORENAME"),
                            STORERENT = reader.GetDouble("STORERENT"),
                            STORELOCATION = reader.GetString("STORELOCATION"),
                            STATUS = reader.GetString("STATUS"),
                            STORECAPACITY = reader.GetInt32("STORECAPACITY"),
                            STOREDEPOSIT = reader.GetDouble("STOREDEPOSIT"),
                            VSTATUS = reader.GetString("VSTATUS"),
                            SHOPLOC = reader.GetString("SHOPLOC"),

                        });
                    }
                }
            }
            return list;
        }



        public async Task<List<GET_MarketStore>> Searchasync(GET_MarketStoreDomain input)
        {
            List<GET_MarketStore> list = new List<GET_MarketStore>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {

                command.CommandText = "SELECT  * FROM [GET_MarketStore]('" + input.STORID + "','" + input.KEYWORD + "','" + input.COMPANYID + "' ,'" + input.DEPTID + "' )ORDER BY STORID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    {
                        while (await reader.ReadAsync())
                        {
                            list.Add(new GET_MarketStore
                            {
                                STORID = reader.GetString("STORID"),
                                STOREID = reader.GetString("STOREID"),
                                SDATE = reader.GetString("SDATE"),
                                STORENAME = reader.GetString("STORENAME"),
                                STORERENT = reader.GetDouble("STORERENT"),
                                STORELOCATION = reader.GetString("STORELOCATION"),
                                STATUS = reader.GetString("STATUS"),
                                STORECAPACITY = reader.GetInt32("STORECAPACITY"),
                                STOREDEPOSIT = reader.GetDouble("STOREDEPOSIT"),
                                VSTATUS = reader.GetString("VSTATUS"),
                                SHOPLOC = reader.GetString("SHOPLOC"),

                            });
                        }
                    }
                }
                return list;
            }
        }
    }
}
