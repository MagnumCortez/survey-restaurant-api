using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Infra;
using Restaurant.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.DAL
{
    public class LoginRepository : RepositoryBase<IRestaurantDbContext>, ILoginRepository
    {
        public LoginRepository(IRestaurantDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// METODO RESPONSAVEL POR PERSISTIR OS DADOS DE ESTUDANDE
        /// </summary>
        /// <param name="student">INSTANCIA DE ESTUDANTE</param>
        /// <returns>EM CASO DE SUCESSO RETORNA O OBJETO ESTUDANTE</returns>
        public async Task<Student> PostLoginAsync(long ra, string password)
        {
            try
            {
                return await _dbContext.QueryStudent
                    .Where(x => x.STD_RA.Equals(ra))
                    .Where(y => y.STD_PASSWORD.Equals(password))
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
