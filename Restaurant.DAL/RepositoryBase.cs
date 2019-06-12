
using Restaurant.DAL.Infra;

namespace Restaurant.DAL
{
    public abstract class RepositoryBase<TContext> where TContext : IRestaurantDbContext
    {
        protected TContext _dbContext;

        public RepositoryBase(TContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
