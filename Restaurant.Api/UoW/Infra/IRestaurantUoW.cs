using Restaurant.BLL.Infra;

namespace Restaurant.Api.UoW.Infra
{
    public interface IRestaurantUoW
    {
        IRestaurantBLL restaurantBLL { get; }
    }
}
