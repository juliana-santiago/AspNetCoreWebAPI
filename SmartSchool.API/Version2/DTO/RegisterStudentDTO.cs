using System;

namespace SmartSchool.API.Version2.DTO
{
    /// <summary>
    /// Este é o DTO do Aluno para Registrar
    /// </summary>
    public class RegisterStudentDTO
    {
        /// <summary>
        /// Identificador e chave do Banco.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Chave do Aluno.
        /// </summary>
        public int Registration { get; set; }
        /// <summary>
        /// Primeiro nome.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Sobrenome do Aluno.
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Telefone do Aluno.
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Data de nascimento do Aluno.
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Data de inicio do curso do Aluno.
        /// </summary>
        public DateTime StartDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Data de conclusão do curso do Aluno.
        /// </summary>
        public DateTime? FinalDate { get; set; } = null;
        /// <summary>
        /// Ativar ou não o Aluno.
        /// </summary>
        public bool Active { get; set; } = true;
    }
}
