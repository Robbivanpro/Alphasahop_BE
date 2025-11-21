using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticoliWebService.Services;
using Microsoft.EntityFrameworkCore;

namespace ArticoliWebService.test
{
    public class DbContextMocker
    {
        public static AlphaShopDbContext alphaShopDbContext()
        {
            var connectionString =  "Data Source=WIN10NIK\\MSSQLSERVER19;Initial Catalog=AlphaShop;Integrated Security=False;User ID=ApiClient;Password=123_Stella";

             // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<AlphaShopDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            // Create instance of DbContext
            var dbContext = new AlphaShopDbContext(options);

            return dbContext;
        }
    }
}