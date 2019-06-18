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
                int totalVotes = await GetTotalVotesAsync();

                return await _dbContext.QuerySurvey
                                    .Where(x => x.SRV_DATE.Date == DateTime.Now.Date)
                                    .GroupBy(x => x.SRV_RESTAURANT_ID)
                                    .Select(x => new { SRV_RESTAURANT_ID = x.Key, VOTES = x.Count(), TOTAL = totalVotes })
                                    .Join(_dbContext.QueryRestaurant, x => x.SRV_RESTAURANT_ID, y => y.RES_IDENTI, (VOTING, RESTAURANT) => new { VOTING, RESTAURANT })
                                    .AsNoTracking()
                                    .ToListAsync<Object>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO RESPONSÁVEL POR RETORNAR O RESTAURANTE VENCEDOR DO DIA ATUAL
        /// </summary>
        /// <param name=""></param>
        /// <returns>OBJETO</returns>
        public async Task<Object> GetSurveyWinnerAsync()
        {
            try
            {
                SurveyWinners sw = await _dbContext.QuerySurveyWinners.Where(x => x.SVW_DATE.Date == DateTime.Now.Date).AsNoTracking().FirstOrDefaultAsync();
                Entities.Restaurant rest = await _dbContext.QueryRestaurant.Where(x => x.RES_IDENTI == sw.SVW_RESTAURANT_ID).AsNoTracking().FirstOrDefaultAsync();

                return new
                {
                    RESTAURANT_ID = sw.SVW_RESTAURANT_ID,
                    DATE = sw.SVW_DATE,
                    VOTES = sw.SVW_VOTES,
                    TOTAL_VOTES = sw.SVW_TOTAL_VOTES,
                    RESTAURANT = rest,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO RESPONSÁVEL POR RETORNAR TODOS OS RESTAURANTES VENCEDORES DA SEMANA
        /// </summary>
        /// <param name="ID">ID STUDENT</param>
        /// <returns>OBJETO ENQUETE</returns>
        public async Task<List<Object>> GetWeeklySurveyWinnersAsync()
        {
            try
            {
                //Pegando o começo da semana (Domingo)
                var sunday = DateTime.Now.AddDays(((int) DateTime.Now.DayOfWeek) * (-1));
                    
                return await _dbContext.QuerySurveyWinners.Where(x => x.SVW_DATE.Date >= sunday.Date).AsNoTracking().ToListAsync<Object>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO RESPONSÁVEL POR PERSISTIR OS DADOS DO RESTAURANTE VENCEDOR
        /// </summary>
        /// <param name=""></param>
        /// <returns>BOOLEAN</returns>
        public async Task<SurveyWinners> PostSurveyFinishAsync()
        {
            try
            {
                var surveyResult = await GetSurveyResultPartialAsync();

                //teste.GetType().GetProperty("VOTES").GetValue(teste, null);
                int higherVoting = 0;
                int idxSurveyWinner = 0;
                for (int i = 0; i < surveyResult.Count; i++)
                {
                    int votesReceived = int.Parse(surveyResult[i].GetType().GetProperty("VOTES").GetValue(surveyResult[i], null).ToString());
                    if (votesReceived > higherVoting)
                    {
                        idxSurveyWinner = i;
                        higherVoting = votesReceived;
                    } else if (votesReceived == higherVoting)
                    {
                        //Caso o número de votação empatar, será gerado um randomico para escolher o restaurante sorteado.
                        Random random = new Random();

                        if (random.Next(0, 2) == 1)
                        {
                            idxSurveyWinner = i;
                        }
                    }
                }

                SurveyWinners sw = new SurveyWinners();

                sw.SVW_RESTAURANT_ID = int.Parse(surveyResult[idxSurveyWinner].GetType().GetProperty("SRV_RESTAURANT_ID").GetValue(surveyResult[idxSurveyWinner], null).ToString());
                sw.SVW_DATE = DateTime.Now;
                sw.SVW_VOTES = int.Parse(surveyResult[idxSurveyWinner].GetType().GetProperty("VOTES").GetValue(surveyResult[idxSurveyWinner], null).ToString());
                sw.SVW_TOTAL_VOTES = int.Parse(surveyResult[idxSurveyWinner].GetType().GetProperty("TOTAL").GetValue(surveyResult[idxSurveyWinner], null).ToString());

                _dbContext.Add(sw);
                await _dbContext.SaveChangesAsync();

                return sw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO RESPONSAVEL POR RETORNAR A TOTALIZAÇÃO DE VOTOS DO DIA ATUAL
        /// </summary>
        /// <param name=""></param>
        /// <returns>TOTAL DE VOTOS</returns>
        private async Task<int> GetTotalVotesAsync()
        {
            try
            {
                return await _dbContext.QuerySurvey.Where(x => x.SRV_DATE.Date == DateTime.Now.Date).AsNoTracking().CountAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
