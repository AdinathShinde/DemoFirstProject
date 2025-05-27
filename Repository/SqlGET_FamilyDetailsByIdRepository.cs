using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DemoFirstProject.Repository
{
    public class SqlGET_FamilyDetailsByIdRepository : IGET_FamilyDetailsByIdRepository
    {
        private readonly ApplicatioDbContext dbContext;
        public SqlGET_FamilyDetailsByIdRepository (ApplicatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<GET_FamilyDetailsById>> getasync(GET_FamilyDetailsByIdDomain input)
        {
            List<GET_FamilyDetailsById> list = new List<GET_FamilyDetailsById>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {

                command.CommandText = "SELECT TOP 20 * FROM [GET_FamilyDetailsById]('" + input.MAID + "','" + input.COMPANYID + "','" + input.DEPTID + "')ORDER BY FDAID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_FamilyDetailsById
                        {
                            FDAID = reader.GetString("FDAID"),
                            MAID = reader.GetString("MAID"),
                            FDNAME = reader.GetString("FDNAME"),
                            FDBIRTHDATE = reader.GetString("FDBIRTHDATE"),
                            FDAADHARNO = reader.GetString("FDAADHARNO"),
                            FDCONTACT = reader.GetString("FDCONTACT"),
                            FDRELATION = reader.GetString("FDRELATION"),
                            ISDELETED = reader.GetBoolean("ISDELETED"),


                        });
                    }
                }
            }

                return list;
            }
        
        public async Task<List<GET_FamilyDetailsById>> Searchasync(GET_FamilyDetailsByIdDomain input)


     {
            List<GET_FamilyDetailsById> list = new List<GET_FamilyDetailsById>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {

                command.CommandText = "SELECT  * FROM [GET_FamilyDetailsById]('" + input.MAID + "','" + input.COMPANYID + "','" + input.DEPTID + "')ORDER BY FDAID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_FamilyDetailsById
                        {
                            FDAID = reader.GetString("FDAID"),
                            MAID = reader.GetString("MAID"),
                            FDNAME = reader.GetString("FDNAME"),
                            FDBIRTHDATE = reader.GetString("FDBIRTHDATE"),
                            FDAADHARNO = reader.GetString("FDAADHARNO"),
                            FDCONTACT = reader.GetString("FDCONTACT"),
                            FDRELATION = reader.GetString("FDRELATION"),
                            ISDELETED = reader.GetBoolean("ISDELETED"),


                        });
                    }
                }
            }

                return list;
            }
}

}