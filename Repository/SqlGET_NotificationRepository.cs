using System.Collections.Generic;
using System.Data;
using DemoFirstProject.Data;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DemoFirstProject.Repository
{
    public class SqlGET_NotificationRepository : IGET_NotificationRepository
    {
        private readonly ApplicatioDbContext dbContext;
        public SqlGET_NotificationRepository(ApplicatioDbContext dbContext)

        {
            this.dbContext = dbContext;
        }

        public async Task<List<GET_Notification>> getasync(GET_NotificationDomain input)
        {

            List<GET_Notification> list = new List<GET_Notification>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT TOP 20 * FROM [GET_Notification]('" + input.NotiID + "' , '" + input.KEYWORD + "' , '" + input.COMPANYID + "' , '" + input.DEPTID + "')ORDER BY DATE DESC";
                dbContext.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new GET_Notification
                        {
                            NotiID = reader.GetString("NotiID"),
                            NotiDescription = reader.GetString("NotiDescription"),
                            NotiEDate = reader.GetString("NotiEDate"),
                            NotiSDate = reader.GetString("NotiSDate"),
                            NotiTitle = reader.GetString("NotiTitle"),
                            ISACTIVE = reader.GetString("ISACTIVE"),
                            LOGTYPE = reader.GetString("LOGTYPE"),
                            DATE = reader.GetString("DATE"),
                        });
                    }
                }
            }
            return list;
        }
    }
}

