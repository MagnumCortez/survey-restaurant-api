using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.UoW.Infra;
using Restaurant.Helpers;

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private IRestaurantUoW _restaurantUoW;

        public RestaurantController(IRestaurantUoW restaurantUoW)
        {
            _restaurantUoW = restaurantUoW;
        }

        /// <summary>
        /// RETORNA LISTA COM TODOS RESTAURANTES
        /// </summary>
        /// <param name=""></param>
        /// <returns>OBJETO RESPONSE</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllRestaurant()
        {
            var response = new ResponseContent();
            try
            {
                response.Object = await _restaurantUoW.restaurantBLL.GetAllRestaurantAsync();
                response.Message = "Requisição realizada com sucesso.";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }

            return Ok(response);
        }

        /// <summary>
        /// CONSULTAR DADOS DE RESTAURANTE
        /// </summary>
        /// <param name="id">ID RESTAURANTE</param>
        /// <returns>OBJETO RESPONSE</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurant(long id)
        {
            var response = new ResponseContent();
            try
            {
                response.Object = await _restaurantUoW.restaurantBLL.GetRestaurantAsync(id);
                response.Message = "Requisição realizada com sucesso.";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }

            return Ok(response);
        }

        /// <summary>
        /// SALVAR DADOS DE CADASTRO DO RESTAURANTE
        /// </summary>
        /// <param name="student">OBJETO RESTAURANTE</param>
        /// <returns>OBJETO RESPONSE</returns>
        [HttpPost]
        public async Task<IActionResult> PostRestaurant([FromBody]Entities.Restaurant restaurant)
        {
            var response = new ResponseContent();
            try
            {
                response.Object = await _restaurantUoW.restaurantBLL.PostRestaurantAsync(restaurant);
                response.Message = "Requisição realizada com sucesso.";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }

            return Ok(response);
        }

        /// <summary>
        /// ATUALIZAR DADOS DE CADASTRO DE RESTAURANTE
        /// </summary>
        /// <param name="student">OBJETO RESTAURANTE</param>
        /// <returns>OBJETO RESPONSE</returns>
        [HttpPut]
        public async Task<IActionResult> PutRestaurant([FromBody]Entities.Restaurant restaurant)
        {
            var response = new ResponseContent();
            try
            {
                response.Object = await _restaurantUoW.restaurantBLL.PutRestaurantAsync(restaurant);
                response.Message = "Requisição realizada com sucesso.";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }

            return Ok(response);
        }
    }
}