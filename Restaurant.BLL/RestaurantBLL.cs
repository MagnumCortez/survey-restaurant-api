using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.BLL.Infra;
using Restaurant.DAL.Infra;

namespace Restaurant.BLL
{
    public class RestaurantBLL : IRestaurantBLL
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantBLL(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        /// <summary>
        /// MÉTDODO RESPONSÁVEL PELA VALIDAÇÃO DOS DADOS UTILIZADOS PARA RETORNO DE TODOS RESTAURANTE
        /// </summary>
        /// <param name=""></param>
        /// <returns>LIST RESTAURANT</returns>
        public async Task<List<Entities.Restaurant>> GetAllRestaurantAsync()
        {
            try
            {
                return await _restaurantRepository.GetAllRestaurantAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// MÉTDODO RESPONSÁVEL PELA VALIDAÇÃO DOS DADOS UTILIZADOS PARA CONSULTA DE RESTAURANTE
        /// </summary>
        /// <param name="ID">ID RESTAURANT</param>
        /// <returns>OBJETO RESTAURANT</returns>
        public async Task<Entities.Restaurant> GetRestaurantAsync(long id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Preencha o ID do restaurante");
                }

                return await _restaurantRepository.GetRestaurantAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL PELA VALIDAÇÃO DOS DADOS UTILIZADOS PARA A INCLUSÃO DE RESTAURANTE
        /// </summary>
        /// <param name="student">OBJETO RESTAURANT</param>
        /// <returns>OBJETO RESTAURANTE</returns>
        public async Task<Entities.Restaurant> PostRestaurantAsync(Entities.Restaurant restaurant)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(restaurant.RES_NAME))
                {
                    throw new Exception("Preencha o nome do restaurante");
                }

                if (string.IsNullOrWhiteSpace(restaurant.RES_MENU))
                {
                    throw new Exception("Preencha o cardárpio do restaurante");
                }

                if (restaurant.RES_PRICE <= 0)
                {
                    throw new Exception("Preencha o preço do restaurante com um valor superior a zero");
                }

                return await _restaurantRepository.PostRestaurantAsync(restaurant);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL PELA VALIDAÇÃO DOS DADOS UTILIZADOS PARA ALTERAÇÃO DO RESTAURANTE
        /// </summary>
        /// <param name="student">OBJETO RESTAURANTE</param>
        /// <returns>OBJETO RESTAURANTE</returns>
        public async Task<Entities.Restaurant> PutRestaurantAsync(Entities.Restaurant restaurant)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(restaurant.RES_NAME))
                {
                    throw new Exception("Preencha o nome do restaurante");
                }

                if (string.IsNullOrWhiteSpace(restaurant.RES_MENU))
                {
                    throw new Exception("Preencha o cardárpio do restaurante");
                }

                if (restaurant.RES_PRICE <= 0)
                {
                    throw new Exception("Preencha o preço do restaurante com um valor superior a zero");
                }

                return await _restaurantRepository.PutRestaurantAsync(restaurant);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
