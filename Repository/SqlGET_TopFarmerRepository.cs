using System.Data;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoFirstProject.Repository
{
    public class SqlGET_TopFarmerRepository : IGET_TopFarmerRepository
    {
        private readonly ApplicatioDbContext dbContext;
        public  SqlGET_TopFarmerRepository (ApplicatioDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task<List<GET_TopFarmer>> getasync(GET_TopFarmerDomain input)
        {
         List <GET_TopFarmer> list=new List<GET_TopFarmer> ();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = " SELECT * FROM [GET_TopFarmer]( '" + input.COMPANYID + "' , '" + input.DEPTID + "')";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_TopFarmer
                        {
                            TotalJali = reader.GetInt32("TotalJali"),
                            TotalFarmer = reader.GetInt32("TotalFarmer"),
                        });
                    }
                }
            }
            return list;

                        }
    }
}
