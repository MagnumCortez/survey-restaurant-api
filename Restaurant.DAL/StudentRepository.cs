using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Infra;
using Restaurant.Entities;

namespace Restaurant.DAL
{
    public class StudentRepository : RepositoryBase<IRestaurantDbContext>, IStudentRepository
    {
        public StudentRepository(IRestaurantDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// METODO RESPONSAVEL POR RETORNAR UMA LISTA COM TODOS ESTUDANTES
        /// </summary>
        /// <param name=""></param>
        /// <returns>RETORNA UMA LISTA COM TODOS ESTUDANTES</returns>
        public async Task<List<Student>> GetAllStudentAsync()
        {
            try
            {
                return await _dbContext.QueryStudent.ToListAsync<Student>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO RESPONSAVEL POR RETORNAR OS DADOS DO ESTUDANTE
        /// </summary>
        /// <param name="ID">ID DO ESTUDANTE</param>
        /// <returns>OBJETO ESTUDANTE</returns>
        public async Task<Student> GetStudentAsync(long id)
        {
            try
            {
                return await _dbContext.QueryStudent.Where(x => x.STD_IDENTI.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO RESPONSAVEL POR PERSISTIR OS DADOS DE ESTUDANDE
        /// </summary>
        /// <param name="student">INSTANCIA DE ESTUDANTE</param>
        /// <returns>EM CASO DE SUCESSO RETORNA O OBJETO ESTUDANTE</returns>
        public async Task<Student> PostStudentAsync(Student student)
        {
            try
            {
                _dbContext.Add(student);
                await _dbContext.SaveChangesAsync();

                return student;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO RESPONSAVEL POR ATUALIZAR O DADOS DE ESTUDANTE
        /// </summary>
        /// <param name="student">INSTANCIA DE ESTUDANTE</param>
        /// <returns>EM CASO DE SUCESSO RETORNA O OBJETO ESTUDANTE</returns>
        public async Task<Student> PutStudentAsync(Student student)
        {
            try
            {
                _dbContext.SetModified(student);
                await _dbContext.SaveChangesAsync();

                return student;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
