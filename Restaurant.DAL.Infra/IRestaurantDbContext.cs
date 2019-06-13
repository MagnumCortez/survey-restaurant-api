using System.Linq;
using Restaurant.Entities;

namespace Restaurant.DAL.Infra
{
    public interface IRestaurantDbContext : IDataBaseContext
    {
        IQueryable<Student> QueryStudent { get; }
        IQueryable<Entities.Restaurant> QueryRestaurant { get; }
        IQueryable<Survey> QuerySurvey { get; }
        IQueryable<SurveyWinners> QuerySurveyWinners { get; }
    }
}
