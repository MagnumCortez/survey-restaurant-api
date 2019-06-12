using Restaurant.BLL.Infra;
using Restaurant.DAL.Infra;
using Restaurant.Entities;
using System;
using System.Threading.Tasks;

namespace Restaurant.BLL
{
    public class LoginBLL : ILoginBLL
    {
        private readonly ILoginRepository _loginRepository;

        public LoginBLL(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL PELA VALIDAÇÃO DO LOGIN DE ESTUDANTE
        /// </summary>
        /// <param name="ra">REGISTRO ACADÊMICO</param>
        /// <param name="password">SENHA</param>
        /// <returns>OBJETO STUDENT</returns>
        public async Task<Student> PostLoginAsync(long ra, string password)
        {
            try
            {
                if (ra <= 0 || string.IsNullOrWhiteSpace(password))
                {
                    throw new Exception("Dados de acesso inválidos");
                }

                return await _loginRepository.PostLoginAsync(ra, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
