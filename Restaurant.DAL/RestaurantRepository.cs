using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Infra;

namespace Restaurant.DAL
{
    public class RestaurantRepository : RepositoryBase<IRestaurantDbContext>, IRestaurantRepository
    {
        public RestaurantRepository(IRestaurantDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// METODO RESPONSAVEL POR RETORNAR UMA LISTA COM TODOS RESTAURANTE
        /// </summary>
        /// <param name=""></param>
        /// <returns>RETORNA UMA LISTA COM TODOS RESTAURANTE</returns>
        public async Task<List<Entities.Restaurant>> GetAllRestaurantAsync()
        {
            try
            {
                return await _dbContext.QueryRestaurant.ToListAsync<Entities.Restaurant>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO RESPONSAVEL POR RETORNAR OS DADOS DO RESTAURANTE
        /// </summary>
        /// <param name="ID">ID DO RESTAURANTE</param>
        /// <returns>OBJETO RESTAURANTE</returns>
        public async Task<Entities.Restaurant> GetRestaurantAsync(long id)
        {
            try
            {
                return await _dbContext.QueryRestaurant.Where(x => x.RES_IDENTI.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO RESPONSAVEL POR PERSISTIR OS DADOS DO RESTAURANTE
        /// </summary>
        /// <param name="restaurant">INSTANCIA DE RESTAURANTE</param>
        /// <returns>EM CASO DE SUCESSO RETORNA O OBJETO RESTAURANTE</returns>
        public async Task<Entities.Restaurant> PostRestaurantAsync(Entities.Restaurant restaurant)
        {
            try
            {
                _dbContext.Add(restaurant);
                await _dbContext.SaveChangesAsync();

                return restaurant;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO RESPONSAVEL POR ATUALIZAR O DADOS DO RESTAURANTE
        /// </summary>
        /// <param name="restaurant">INSTANCIA DE RESTAURANTE</param>
        /// <returns>EM CASO DE SUCESSO RETORNA O OBJETO RESTAURANTE</returns>
        public async Task<Entities.Restaurant> PutRestaurantAsync(Entities.Restaurant restaurant)
        {
            try
            {
                _dbContext.SetModified(restaurant);
                await _dbContext.SaveChangesAsync();

                return restaurant;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
