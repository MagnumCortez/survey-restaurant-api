using Restaurant.Api.UoW.Infra;
using Restaurant.BLL.Infra;

namespace Restaurant.Api.UoW
{
    public class RestaurantUoW : IRestaurantUoW
    {
        public IRestaurantBLL restaurantBLL { get; }

        public RestaurantUoW(IRestaurantBLL restaurantBLL)
        {
            this.restaurantBLL = restaurantBLL;
        }
    }
}
