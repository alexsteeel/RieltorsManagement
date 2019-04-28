using System;

namespace RieltorsManagement.BLL
{
    /// <summary>
    /// Объект передачи данных для риэлтора.
    /// </summary>
    public class RieltorDTO
    {
        public RieltorDTO()
        {

        }

        public RieltorDTO(int id, string lastName, string firstName, DateTime createdDateTime, string division)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            CreatedDateTime = createdDateTime.ToString();
            Division = division;
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public string CreatedDateTime { get; set; }

        /// <summary>
        /// Подразделение.
        /// </summary>
        public string Division { get; set; }
    }
}