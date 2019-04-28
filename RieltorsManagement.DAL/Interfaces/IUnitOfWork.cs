using System;

namespace RieltorsManagement.DAL
{
    /// <summary>
    /// Интерфейс для реализации паттерна Unit of Work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Риэлторы.
        /// </summary>
        IRepository<Rieltor> Rieltors { get; }

        /// <summary>
        /// Подразделения.
        /// </summary>
        IRepository<Division> Divisions { get; }
        
        /// <summary>
        /// Сохранение транзакции в БД.
        /// </summary>
        void Save();
    }
}