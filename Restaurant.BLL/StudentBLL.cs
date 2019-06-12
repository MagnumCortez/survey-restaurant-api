using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.BLL.Infra;
using Restaurant.DAL.Infra;
using Restaurant.Entities;

namespace Restaurant.BLL
{
    public class StudentBLL : IStudentBLL
    {
        private readonly IStudentRepository _studentRepository;

        public StudentBLL(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// MÉTDODO RESPONSÁVEL PELA VALIDAÇÃO DOS DADOS UTILIZADOS PARA RETORNO DE TODOS ESTUDANTES
        /// </summary>
        /// <param name=""></param>
        /// <returns>LIST STUDENT</returns>
        public async Task<List<Student>> GetAllStudentAsync()
        {
            try
            {
                return await _studentRepository.GetAllStudentAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// MÉTDODO RESPONSÁVEL PELA VALIDAÇÃO DOS DADOS UTILIZADOS PARA CONSULTA DE ESTUDANTE
        /// </summary>
        /// <param name="ID">ID STUDENT</param>
        /// <returns>OBJETO STUDENT</returns>
        public async Task<Student> GetStudentAsync(long id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Preencha o ID do estaudante");
                }

                return await _studentRepository.GetStudentAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL PELA VALIDAÇÃO DOS DADOS UTILIZADOS PARA A INCLUSÃO DE ESTUDANTE
        /// </summary>
        /// <param name="student">OBJETO STUDENT</param>
        /// <returns>OBJETO STUDENT</returns>
        public async Task<Student> PostStudentAsync(Student student)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(student.STD_NAME))
                {
                    throw new Exception("Preencha o nome do estudante");
                }

                if (student.STD_RA <= 0)
                {
                    throw new Exception("Preencha o registro acadêmico do estudante com um valor superior a zero");
                }

                if (string.IsNullOrWhiteSpace(student.STD_PASSWORD))
                {
                    throw new Exception("Preencha o password do estudante");
                }

                return await _studentRepository.PostStudentAsync(student);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL PELA VALIDAÇÃO DOS DADOS UTILIZADOS PARA ALTERAÇÃO DO ESTUDANTE
        /// </summary>
        /// <param name="student">OBJETO STUDENT</param>
        /// <returns>OBJETO STUDENT</returns>
        public async Task<Student> PutStudentAsync(Student student)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(student.STD_NAME))
                {
                    throw new Exception("Preencha o nome do estudante");
                }

                if (student.STD_RA <= 0)
                {
                    throw new Exception("Preencha o registro acadêmico do estudante com um valor superior a zero");
                }

                if (string.IsNullOrWhiteSpace(student.STD_PASSWORD))
                {
                    throw new Exception("Preencha o password do estudante");
                }

                return await _studentRepository.PutStudentAsync(student);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
