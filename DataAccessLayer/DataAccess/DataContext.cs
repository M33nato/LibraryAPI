using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.DataAccess
{
    public class DataContext: DbContext
    {

        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Books;Trusted_Connection=True;MultipleActiveResultSets=true",
                    b => b.MigrationsAssembly("DataAccessLayer"));
            }
        }



        //"Server=.\\SQLExpress;Database=bookdb;Trusted_Connection=true;TrsutServerCertificate=true;");


        public DbSet<Book> books { get; set; }
    }
}
