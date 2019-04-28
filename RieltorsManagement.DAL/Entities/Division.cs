using System;
using System.ComponentModel.DataAnnotations;

namespace RieltorsManagement.DAL
{
    /// <summary>
    /// Подразделение.
    /// </summary>
    public class Division
    {
        public Division()
        {
            
        }

        public Division(string name)
        {
            Name = name;
            CreatedDateTime = DateTime.Now;
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime CreatedDateTime { get; set; }
    }
}
