using System.Data;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoFirstProject.Repository
{
    public class SqlGET_ShopAlotRepository : IGET_ShopAlotRepository
    {
        private readonly ApplicatioDbContext dbContext;
        public SqlGET_ShopAlotRepository(ApplicatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<GET_ShopAlot>> getasync (GET_ShopAlotDomain input)
        {
            List<GET_ShopAlot> list = new List<GET_ShopAlot>();
            using (var commond = dbContext.Database.GetDbConnection().CreateCommand())
            {
                commond.CommandText = "SELECT TOP 20 *FROM[GET_ShopAlot]('" + input.SHID + "','" + input.KEYWORD + "','" + input.COMPANYID + "','" + input.DEPTID + "')ORDER BY SHID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await commond.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_ShopAlot
                        {
                            SHID = reader.GetString("SHID"),
                            VYAPARINAME = reader.GetString("VYAPARINAME"),
                            SHOPNAME = reader.GetString("SHOPNAME"),
                            SHOPID = reader.GetString("SHOPID"),
                            SDATE = reader.GetString("SDATE"),
                            EDATE = reader.GetString("EDATE"),
                            DEPOSIT = reader.GetDouble("DEPOSIT"),
                            RENT = reader.GetDouble("RENT"),
                            VNAME = reader.GetString("VNAME"),
                            VAPNAME = reader.GetString("VAPNAME"),
                            STORENAME = reader.GetString("STORENAME"),
                            SHOPN = reader.GetString("SHOPN"),

                        });
                    }
                }
            }
            return list;

        }

      

        public async Task<List<GET_ShopAlot>> Searchasync(GET_ShopAlotDomain input)
        {
            List<GET_ShopAlot> list = new List<GET_ShopAlot>();
            using (var commond = dbContext.Database.GetDbConnection().CreateCommand())
            {
                commond.CommandText = "SELECT TOP 20 *FROM[GET_ShopAlot]('" + input.SHID + "','" + input.KEYWORD + "','" + input.COMPANYID + "','" + input.DEPTID + "')ORDER BY SHID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await commond.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_ShopAlot
                        {
                            SHID = reader.GetString("SHID"),
                            VYAPARINAME = reader.GetString("VYAPARINAME"),
                            SHOPNAME = reader.GetString("SHOPNAME"),
                            SHOPID = reader.GetString("SHOPID"),
                            SDATE = reader.GetString("SDATE"),
                            EDATE = reader.GetString("EDATE"),
                            DEPOSIT = reader.GetDouble("DEPOSIT"),
                            RENT = reader.GetDouble("RENT"),
                            VNAME = reader.GetString("VNAME"),
                            VAPNAME = reader.GetString("VAPNAME"),
                            STORENAME = reader.GetString("STORENAME"),
                            SHOPN = reader.GetString("SHOPN"),

                        });
                    }
                }
            }
            return list;

        }

        
    }
}

