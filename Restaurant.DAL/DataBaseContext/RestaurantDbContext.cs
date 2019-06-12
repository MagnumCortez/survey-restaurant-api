using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurant.DAL.Infra;
using Restaurant.Entities;
using System.Linq;

namespace Restaurant.DAL.DataBaseContext
{
    public class RestaurantDbContext : DbContext, IRestaurantDbContext
    {
        private IConfiguration configuration;

        public RestaurantDbContext(IConfiguration config)
        {
            configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = configuration.GetConnectionString("RestaurantDbBase");
            optionsBuilder.UseSqlServer(connection);
            base.OnConfiguring(optionsBuilder);
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public DbSet<Student> Student { get; set; }
        public IQueryable<Student> QueryStudent { get { return Student; } }

        public DbSet<Entities.Restaurant> Restaurant { get; set; }
        public IQueryable<Entities.Restaurant> QueryRestaurant { get { return Restaurant; } }

        public DbSet<Survey> Survey { get; set; }
        public IQueryable<Survey> QuerySurvey { get { return Survey; } }
    }
}
