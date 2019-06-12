using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.UoW.Infra;
using System.Threading.Tasks;
using Restaurant.Helpers;
using System;
using Restaurant.Entities;

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentUoW _studentUoW;

        public StudentController(IStudentUoW studentUoW)
        {
            _studentUoW = studentUoW;
        }

        /// <summary>
        /// RETORNA LISTA COM TODOS ESTUDANTES
        /// </summary>
        /// <param name=""></param>
        /// <returns>OBJETO RESPONSE</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var response = new ResponseContent();
            try
            {
                response.Object = await _studentUoW.studentBLL.GetAllStudentAsync();
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
        /// CONSULTAR DADOS DE ESTUDANTE
        /// </summary>
        /// <param name="id">ID ESTUDANTE</param>
        /// <returns>OBJETO RESPONSE</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(long id)
        {
            var response = new ResponseContent();
            try
            {
                response.Object = await _studentUoW.studentBLL.GetStudentAsync(id);
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
        /// SALVAR DADOS DE CADASTRO DO ESTUDANTE
        /// </summary>
        /// <param name="student">OBJETO STUDENT</param>
        /// <returns>OBJETO RESPONSE</returns>
        [HttpPost]
        public async Task<IActionResult> PostStudent([FromBody]Student student)
        {
            var response = new ResponseContent();
            try
            {
                response.Object = await _studentUoW.studentBLL.PostStudentAsync(student);
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
        /// ATUALIZAR DADOS DE CADASTRO DE ESTUDANTE
        /// </summary>
        /// <param name="student">OBJETO STUDENT</param>
        /// <returns>OBJETO RESPONSE</returns>
        [HttpPut]
        public async Task<IActionResult> PutStudent([FromBody]Student student)
        {
            var response = new ResponseContent();
            try
            {
                response.Object = await _studentUoW.studentBLL.PutStudentAsync(student);
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