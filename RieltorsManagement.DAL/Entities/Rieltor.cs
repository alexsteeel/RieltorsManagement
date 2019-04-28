using System;
using System.ComponentModel.DataAnnotations;

namespace RieltorsManagement.DAL
{
    /// <summary>
    /// Риэлтор.
    /// </summary>
    public class Rieltor
    {
        public Rieltor()
        {

        }

        public Rieltor(string firstName, string lastName, Division division)
        {
            FirstName = firstName;
            LastName = lastName;
            Division = division;
            CreatedDateTime = DateTime.Now;
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        [Required]
        public DateTime CreatedDateTime { get; set; }

        /// <summary>
        /// Подразделение.
        /// </summary>
        public virtual Division Division { get; set; }
    }
}
