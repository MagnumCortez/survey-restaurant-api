using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Infra;
using Restaurant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.DAL
{
    public class SurveryRepository : RepositoryBase<IRestaurantDbContext>, ISurveyRepository
    {
        public SurveryRepository(IRestaurantDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// METODO RESPONSÁVEL POR RETORNAR OS DADOS DE ENQUETE
        /// </summary>
        /// <param name="ID">ID STUDENT</param>
        /// <returns>OBJETO ENQUETE</returns>
        public async Task<Survey> GetSurveyAsync(long student_id)
        {
            try
            {
                return await _dbContext.QuerySurvey.Where(x => x.SRV_STUDENT_ID.Equals(student_id) 
                                                            && x.SRV_DATE.Date == DateTime.Now.Date).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO RESPONSÁVEL POR PERSISTIR OS DADOS DE ENQUETE
        /// </summary>
        /// <param name="Survey">INSTANCIA DE ENQUETE</param>
        /// <returns>EM CASO DE SUCESSO RETORNA O OBJETO ENQUETE</returns>
        public async Task<Survey> PostSurveyAsync(Survey survey)
        {
            try
            {
                _dbContext.Add(survey);
                await _dbContext.SaveChangesAsync();

                return survey;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO RESPONSÁVEL POR ATUALIZAR O DADOS DE ENQUETE
        /// </summary>
        /// <param name="Survey">INSTANCIA DE ENQUETE</param>
        /// <returns>EM CASO DE SUCESSO RETORNA O OBJETO ENQUETE</returns>
        public async Task<Survey> PutSurveyAsync(Survey survey)
        {
            try
            {
                _dbContext.SetModified(survey);
                await _dbContext.SaveChangesAsync();

                return survey;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO RESPONSAVEL POR RETORNAR UMA LISTA COM O RESULTADO PARCIAL DA ENQUETE
        /// </summary>
        /// <param name=""></param>
        /// <returns>RETORNA UMA LISTA DE VOTO</returns>
        public async Task<List<Object>> GetSurveyResultPartialAsync()
        {
            try
            {
                int totalVotes = await _dbContext.QuerySurvey.Where(x => x.SRV_DATE.Date == DateTime.Now.Date).CountAsync();

                return await _dbContext.QuerySurvey.Where(x => x.SRV_DATE.Date == DateTime.Now.Date).GroupBy(x => x.SRV_RESTAURANT_ID).Select(x => new { SRV_RESTAURANT_ID = x.Key, VOTES = x.Count(), total = totalVotes }).AsNoTracking().ToListAsync<Object>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
