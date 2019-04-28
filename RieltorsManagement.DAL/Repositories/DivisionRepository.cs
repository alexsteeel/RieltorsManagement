using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RieltorsManagement.DAL
{
    /// <summary>
    /// Репозиторий для подразделений.
    /// </summary>
    public class DivisionRepository : IRepository<Division>
    {
        private RieltorContext db;

        public DivisionRepository(RieltorContext context)
        {
            this.db = context;
        }

        /// <summary>
        /// Получение списка всех подразделений из БД.
        /// </summary>
        /// <returns>Список всех подразделений.</returns>
        public IEnumerable<Division> GetAll()
        {
            return db.Divisions;
        }

        /// <summary>
        /// Получение подразделения по Id из БД.
        /// </summary>
        /// <returns>Подразделение.</returns>
        public Division Get(int id)
        {
            return db.Divisions.Find(id);
        }

        /// <summary>
        /// Создание новой записи о подразделении в БД.
        /// </summary>
        /// <param name="rieltor">Объект класса Подразделение.</param>
        public void Create(Division division)
        {
            db.Divisions.Add(division);
        }

        /// <summary>
        /// Обновление существующей записи о подразделении в БД.
        /// </summary>
        /// <param name="rieltor">Существующее подразделение.</param>
        public void Update(Division division)
        {
            db.Entry(division).State = EntityState.Modified;
        }

        /// <summary>
        /// Поиск записи в БД по условию.
        /// </summary>
        /// <param name="predicate">Условие.</param>
        /// <returns>Список подразделений, соответствующих заданному условию.</returns>
        public IEnumerable<Division> Find(Func<Division, bool> predicate)
        {
            return db.Divisions.
                Where(predicate).
                ToList();
        }

        /// <summary>
        /// Удаление записи о подразделении из БД.
        /// </summary>
        /// <param name="id">Id существующего подразделения.</param>
        public void Delete(int id)
        {
            Division division = db.Divisions.Find(id);
            if (division != null)
                db.Divisions.Remove(division);
        }
    }
}