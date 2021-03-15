using System;

namespace SmartSchool.API.Version2.DTO
{
    /// <summary>
    /// Este é o DTO do aluno
    /// </summary>
    public class StudentDTO
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
        /// Nome é o Primeiro nome e o Sobrenome do Aluno.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Telefone do Aluno.
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Esta idade é o cálculo relacionado a data de nascimento do Aluno.
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Data de inicio do curso do Aluno.
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Ativar ou não o Aluno.
        /// </summary>
        public bool Active { get; set; }
    }
}
