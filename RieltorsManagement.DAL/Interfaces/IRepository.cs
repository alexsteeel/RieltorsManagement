using System;
using System.Collections.Generic;

namespace RieltorsManagement.DAL
{
    /// <summary>
    /// Интерфейс репозитория.
    /// </summary>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Получение всех объектов заданного типа из БД.
        /// </summary>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Получение объекта указанного типа по идентификатору.
        /// </summary>
        /// <param name="id">Уникальный идентификатор объекта в БД.</param>
        /// <returns>Объект указанного типа.</returns>
        T Get(int id);

        /// <summary>
        /// Поиск объектов по условию.
        /// </summary>
        /// <param name="predicate">Условие поиска.</param>
        /// <returns>Коллекция объектов, соответствующих условию поиска.</returns>
        IEnumerable<T> Find(Func<T, Boolean> predicate);

        /// <summary>
        /// Создание нового объекта.
        /// </summary>
        void Create(T item);

        /// <summary>
        /// Обновление существующего объекта.
        /// </summary>
        void Update(T item);

        /// <summary>
        /// Удаление объекта по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор объекта в БД.</param>
        void Delete(int id);
    }
}