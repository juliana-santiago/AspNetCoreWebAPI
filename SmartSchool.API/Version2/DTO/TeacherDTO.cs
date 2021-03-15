using System;

namespace SmartSchool.API.Version2.DTO
{
    /// <summary>
    /// Este é o DTO do Professor
    /// </summary>
    public class TeacherDTO
    {
        /// <summary>
        /// Identificador e chave do Banco.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Chave do Professor.
        /// </summary>
        public int Registration { get; set; }
        /// <summary>
        /// Nome é o Primeiro nome e o Sobrenome do Professor.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Telefone do Professor.
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Data de inicio do curso que o Professor leciona.
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Ativar ou não o Professor.
        /// </summary>
        public bool Active { get; set; } = true;
    }
}
