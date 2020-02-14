using PaymentGatewayIntegrationApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayIntegrationApp
{
    public class AppDbContext:DbContext
    {


        private readonly IConfiguration _config;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config) : base(options)
        {


            _config = config;
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<RequestParameter> RequestParameters { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DbFinal"));
        }
    }
}
