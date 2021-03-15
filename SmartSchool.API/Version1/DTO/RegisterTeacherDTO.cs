using System;

namespace SmartSchool.API.Version1.DTO
{
    /// <summary>
    /// Este é o DTO do Professor para Registrar
    /// </summary>
    public class RegisterTeacherDTO
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
        /// Primeiro nome do Professor.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Sobrenome do Professor.
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Telefone do Professor.
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Data de inicio do curso que o Professor leciona.
        /// </summary>
        public DateTime StartDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Data de conclusão do curso que o Professor leciona.
        /// </summary>
        public DateTime? FinalDate { get; set; } = null;
        /// <summary>
        /// Ativar ou não o Professor.
        /// </summary>
        public bool Active { get; set; } = true;
    }
}
