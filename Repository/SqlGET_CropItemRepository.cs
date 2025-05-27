using System.Data;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoFirstProject.Repository
{
    public class SqlGET_CropItemRepository : IGET_CropItemRepository
    {

        private readonly ApplicatioDbContext dbContext;
        public SqlGET_CropItemRepository (ApplicatioDbContext dbContext)

        {
            this.dbContext = dbContext;
        }

        public async Task<List<GET_CropItem>> getasync(GET_CropItemDomain input)
        {
            List<GET_CropItem> list = new List<GET_CropItem>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT TOP 20 * FROM[GET_CropItem]('" + input.ITEMAID +"','" + input.KEYWORD + "', '" + input.COMPANYID + "' , '" + input.DEPTID + "')ORDER BY ITEMAID DESC";
                dbContext.Database.OpenConnection();
               using (var reader = await  command.ExecuteReaderAsync()) {
                    while (await reader.ReadAsync()) {
                        list.Add(new GET_CropItem
                        {
                            ITEMAID = reader.GetString("ITEMAID"),
                            ITEMPHOTO = reader.GetString("ITEMPHOTO"),
                            ITEMID = reader.GetString("ITEMID"),
                            ITEMNM = reader.GetString("ITEMNM"),
                            ITEMNE = reader.GetString("ITEMNE"),
                            STATUS = reader.GetString("STATUS"),



                        });
                    }
                }
            }
            return list;
        }
        public async Task<List<GET_CropItem>> Searchasync(GET_CropItemDomain input)
        {
            List<GET_CropItem> list = new List<GET_CropItem>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT  * FROM[GET_CropItem]('" + input.ITEMAID + "','" + input.KEYWORD + "', '" + input.COMPANYID + "' , '" + input.DEPTID + "')ORDER BY ITEMAID DESC";

                dbContext.Database.OpenConnection();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_CropItem
                        {
                            ITEMAID = reader.GetString("ITEMAID"),
                            ITEMPHOTO = reader.GetString("ITEMPHOTO"),
                            ITEMID = reader.GetString("ITEMID"),
                            ITEMNM = reader.GetString("ITEMNM"),
                            ITEMNE = reader.GetString("ITEMNE"),
                            STATUS = reader.GetString("STATUS"),
                        });
                    }
                }
            }
            return list;
        }
    }
}
