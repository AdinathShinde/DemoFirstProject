using System.Data;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoFirstProject.Repository
{
    public class SqlGET_ProductMasterRepository : IGET_ProductMasterRepository
    {
        private readonly ApplicatioDbContext dbContext;
        public SqlGET_ProductMasterRepository(ApplicatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<GET_ProductMaster>> getasync(GET_ProductMasterDomain input)
        {
            List<GET_ProductMaster> list = new List<GET_ProductMaster>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT TOP 20 * FROM[GET_ProductMaster]('" + input.PAID + "','" + input.KEYWORD + "', '" + input.COMPANYID + "' , '" + input.DEPTID + "')ORDER BY PAID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {

                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_ProductMaster
                        {
                            PAID = reader.GetString("PAID"),
                            PCODE = reader.GetString("PCODE"),
                            PNAME = reader.GetString("PNAME"),
                            PTYPE = reader.GetString("PTYPE"),
                            PCATEGORY = reader.GetString("PCATEGORY"),
                            PSUBCATEGORY = reader.GetString("PSUBCATEGORY"),
                            PDESCRIPTION = reader.GetString("PDESCRIPTION"),
                            PSALES = reader.GetString("PSALES"),
                            PTYPESOFSALES = reader.GetString("PTYPESOFSALES"),
                            PPURCHASEUOM = reader.GetString("PPURCHASEUOM"),
                            PHSN = reader.GetString("PHSN"),
                            PREORDERLEVEL = reader.GetString("PREORDERLEVEL"),
                            PFROMOFPRODUCT = reader.GetString("PFROMOFPRODUCT"),
                            PRETURNPOLICY = reader.GetString("PRETURNPOLICY"),
                           PPRODUCTUSE		 = reader.GetString("PPRODUCTUSE"),
                           PIMAGES = reader.GetString("PIMAGES"),
                           PIGST = reader.GetDouble("PIGST"),
                           PSGST = reader.GetDouble("PSGST"),
                           PCGST = reader.GetDouble("PCGST"),
                           PCESS = reader.GetDouble("PCESS"),
                           CTNAME = reader.GetString("CTNAME"),
                           SCTNAME = reader.GetString("SCTNAME"),
                           PRODUCTID    = reader.GetString("PRODUCTID"),
                           PRODUCTNAME	 = reader.GetString("PRODUCTNAME"),
                           BRANDNAME  	 = reader.GetString("BRANDNAME"),
                           RETAILP    	 = reader.GetDouble("RETAILP"),
                           DEALERP    	 = reader.GetDouble("DEALERP"),
                           RATE    	 = reader.GetString("RATE"),
                           RANGE      	 = reader.GetString("RANGE"),
                           DISCOUNTTYPE  = reader.GetString("DISCOUNTTYPE"),
                           SUBCATEGORY = reader.GetString("SUBCATEGORY"),
                           CATEGORY    = reader.GetString("CATEGORY"),
                           SALETYPE    = reader.GetString("SALETYPE"),
                            PRODUCTTYPE = reader.GetString("PRODUCTTYPE"),
                        });
                    }
                }
            }
            return list;
        }
        

        public async Task<List<GET_ProductMaster>> Searchasync(GET_ProductMasterDomain input)
        {
            List<GET_ProductMaster> list = new List<GET_ProductMaster>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT * FROM[GET_ProductMaster]('" + input.PAID + "','" + input.KEYWORD + "', '" + input.COMPANYID + "' , '" + input.DEPTID + "')ORDER BY PAID DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {

                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_ProductMaster
                        {
                            PAID = reader.GetString("PAID"),
                            PCODE = reader.GetString("PCODE"),
                            PNAME = reader.GetString("PNAME"),
                            PTYPE = reader.GetString("PTYPE"),
                            PCATEGORY = reader.GetString("PCATEGORY"),
                            PSUBCATEGORY = reader.GetString("PSUBCATEGORY"),
                            PDESCRIPTION = reader.GetString("PDESCRIPTION"),
                            PSALES = reader.GetString("PSALES"),
                            PTYPESOFSALES = reader.GetString("PTYPESOFSALES"),
                            PPURCHASEUOM = reader.GetString("PPURCHASEUOM"),
                            PHSN = reader.GetString("PHSN"),
                            PREORDERLEVEL = reader.GetString("PREORDERLEVEL"),
                            PFROMOFPRODUCT = reader.GetString("PFROMOFPRODUCT"),
                            PRETURNPOLICY = reader.GetString("PRETURNPOLICY"),
                            PPRODUCTUSE = reader.GetString("PPRODUCTUSE"),
                            PIMAGES = reader.GetString("PIMAGES"),
                            PIGST = reader.GetDouble("PIGST"),
                            PSGST = reader.GetDouble("PSGST"),
                            PCGST = reader.GetDouble("PCGST"),
                            PCESS = reader.GetDouble("PCESS"),
                            CTNAME = reader.GetString("CTNAME"),
                            SCTNAME = reader.GetString("SCTNAME"),
                            PRODUCTID = reader.GetString("PRODUCTID"),
                            PRODUCTNAME = reader.GetString("PRODUCTNAME"),
                            BRANDNAME = reader.GetString("BRANDNAME"),
                            RETAILP = reader.GetDouble("RETAILP"),
                            DEALERP = reader.GetDouble("DEALERP"),
                            RATE = reader.GetString("RATE"),
                            RANGE = reader.GetString("RANGE"),
                            DISCOUNTTYPE = reader.GetString("DISCOUNTTYPE"),
                            SUBCATEGORY = reader.GetString("SUBCATEGORY"),
                            CATEGORY = reader.GetString("CATEGORY"),
                            SALETYPE = reader.GetString("SALETYPE"),
                            PRODUCTTYPE = reader.GetString("PRODUCTTYPE"),
                        });
                    }
                }
            }
            return list;
        }
    }
    }

