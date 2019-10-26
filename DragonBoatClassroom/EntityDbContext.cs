using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DragonBoatClassroom
{
    public class EntityDbContext:DbContext
    {
        public EntityDbContext() { }
        public EntityDbContext(DbContextOptions options):base(options) { }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            string connetionString = configuration["ConnectionStrings:Default"];
            optionsBuilder.UseSqlServer(connetionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
