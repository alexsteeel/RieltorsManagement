using System;

namespace RieltorsManagement.BLL
{
    /// <summary>
    /// Объект передачи данных для подразделения.
    /// </summary>
    public class DivisionDTO
    {
        public DivisionDTO()
        {

        }

        public DivisionDTO(int id, string name, DateTime createdDateTime)
        {
            Id = id;
            Name = name;
            CreatedDateTime = createdDateTime.ToString();
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public string CreatedDateTime { get; set; }
    }
}