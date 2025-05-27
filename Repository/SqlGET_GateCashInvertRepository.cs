using System.Data;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoFirstProject.Repository
{
    public class SqlGET_GateCashInvertRepository : IGET_GateCashInvertRepository
    {

        private readonly ApplicatioDbContext dbContext;
        public SqlGET_GateCashInvertRepository(ApplicatioDbContext dbContext)

        {
            this.dbContext = dbContext;
        }
        public async Task<List<GET_GateCashInvert>> getasync(GET_GateCashInvertDomain input)
        {
            List<GET_GateCashInvert> list = new List<GET_GateCashInvert>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT TOP 20 * FROM[GET_GateCashInvert]('" + input.CASID + "','" + input.KEYWORD + "', '" + input.COMPANYID + "' , '" + input.DEPTID + "')ORDER BY CASID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {

                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_GateCashInvert
                        {
                            CASID = reader.GetString("CASID"),
                            CASDATE = reader.GetString("CASDATE"),
                            CASBANKNAME = reader.GetString("CASBANKNAME"),
                            CASINVERTCASH = reader.GetInt32("CASINVERTCASH"),
                            CAS2000 = reader.GetInt32("CAS2000"),
                            CAS500 = reader.GetInt32("CAS500"),
                            CAS200 = reader.GetInt32("CAS200"),
                            CAS100 = reader.GetInt32("CAS100"),
                            CAS50 = reader.GetInt32("CAS50"),
                            CAS20 = reader.GetInt32("CAS20"),
                            CAS10 = reader.GetInt32("CAS10"),
                            CASCOINS = reader.GetInt32("CASCOINS"),
                            CASTOTAL = reader.GetInt32("CASTOTAL"),
                            CBANKNAME = reader.GetString("CBANKNAME"),
                        });
                    }
                }
            }
            return list;
        }
        public async Task<List<GET_GateCashInvert>> Searchasync(GET_GateCashInvertDomain input)
       
        {
            List<GET_GateCashInvert> list = new List<GET_GateCashInvert>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT TOP 20 * FROM[GET_GateCashInvert]('" + input.CASID + "','" + input.KEYWORD + "', '" + input.COMPANYID + "' , '" + input.DEPTID + "')ORDER BY CASID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {

                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_GateCashInvert
                        {
                            CASID = reader.GetString("CASID"),
                            CASDATE = reader.GetString("CASDATE"),
                            CASBANKNAME = reader.GetString("CASBANKNAME"),
                            CASINVERTCASH = reader.GetInt32("CASINVERTCASH"),
                            CAS2000 = reader.GetInt32("CAS2000"),
                            CAS500 = reader.GetInt32("CAS500"),
                            CAS200 = reader.GetInt32("CAS200"),
                            CAS100 = reader.GetInt32("CAS100"),
                            CAS50 = reader.GetInt32("CAS50"),
                            CAS20 = reader.GetInt32("CAS20"),
                            CAS10 = reader.GetInt32("CAS10"),
                            CASCOINS = reader.GetInt32("CASCOINS"),
                            CASTOTAL = reader.GetInt32("CASTOTAL"),
                            CBANKNAME = reader.GetString("CBANKNAME"),
                        });
                    }
                }
            }
            return list;
        }

       
        
    }
}