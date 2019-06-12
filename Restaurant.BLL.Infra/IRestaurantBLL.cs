using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.BLL.Infra
{
    public interface IRestaurantBLL
    {
        Task<List<Entities.Restaurant>> GetAllRestaurantAsync();
        Task<Entities.Restaurant> GetRestaurantAsync(long id);
        Task<Entities.Restaurant> PostRestaurantAsync(Entities.Restaurant restaurant);
        Task<Entities.Restaurant> PutRestaurantAsync(Entities.Restaurant restaurant);
    }
}
