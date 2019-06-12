using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.UoW.Infra;
using Restaurant.Entities;
using Restaurant.Helpers;

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginUoW _loginUoW;

        public LoginController(ILoginUoW loginUoW)
        {
            _loginUoW = loginUoW;
        }

        /// <summary>
        /// MÉTODO QUE VALIDA LOGIN DO ESTUDANTE
        /// </summary>
        /// <param name="ra">REGISTRO ACADÊMICO</param>
        /// <param name="password">SENHA DO ESTUDANTE</param>
        /// <returns>OBJETO RESPONSE</returns>
        [HttpPost]
        public async Task<IActionResult> PostLogin([FromBody] Student student)
        {
            var response = new ResponseContent();
            try
            {
                var objStudent = await _loginUoW.loginBLL.PostLoginAsync(student.STD_RA, student.STD_PASSWORD);

                response.Object = objStudent;

                if (objStudent == null)
                {
                    response.Object = "Usuário e/ou senha inválidos";
                }
                
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