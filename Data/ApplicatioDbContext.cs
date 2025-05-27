using System;
using DemoFirstProject.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoFirstProject.Data
{
    public class ApplicatioDbContext : DbContext
    {
        public ApplicatioDbContext (DbContextOptions<ApplicatioDbContext> options):base(options) { }
       
       
        public DbSet<Notification> Notifications { get; set; }
    }
}
