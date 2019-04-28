using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RieltorsManagement.DAL
{
    /// <summary>
    /// Репозиторий для риэлтора.
    /// </summary>
    public class RieltorRepository : IRepository<Rieltor>
    {
        /// <summary>
        /// Контекст данных БД.
        /// </summary>
        private RieltorContext db;

        public RieltorRepository(RieltorContext context)
        {
            this.db = context;
        }

        /// <summary>
        /// Получение списка всех риэлторов из БД.
        /// </summary>
        /// <returns>Список всех риэлторов.</returns>
        public IEnumerable<Rieltor> GetAll()
        {
            return db.Rieltors.Include(o => o.Division);
        }

        /// <summary>
        /// Получение риэлтора по Id из БД.
        /// </summary>
        /// <returns>Риэлтор.</returns>
        public Rieltor Get(int id)
        {
            return db.Rieltors.Find(id);
        }

        /// <summary>
        /// Создание новой записи о риэлторе в БД.
        /// </summary>
        /// <param name="rieltor">Объект класса Риэлтор.</param>
        public void Create(Rieltor rieltor)
        {
            db.Rieltors.Add(rieltor);
        }

        /// <summary>
        /// Обновление существующей записи о риэлторе в БД.
        /// </summary>
        /// <param name="rieltor">Существующий риэлтор.</param>
        public void Update(Rieltor rieltor)
        {
            db.Entry(rieltor).State = EntityState.Modified;
        }

        /// <summary>
        /// Поиск записи в БД по условию.
        /// </summary>
        /// <param name="predicate">Условие.</param>
        /// <returns>Список риэлторов, соответствующих заданному условию.</returns>
        public IEnumerable<Rieltor> Find(Func<Rieltor, bool> predicate)
        {
            return db.Rieltors.
                Include(o => o.Division).
                Where(predicate).
                ToList();
        }

        /// <summary>
        /// Удаление записи о риэлторе из БД.
        /// </summary>
        /// <param name="id">Id существующего риэлтора.</param>
        public void Delete(int id)
        {
            Rieltor rieltor = db.Rieltors.Find(id);
            if (rieltor != null)
                db.Rieltors.Remove(rieltor);
        }
    }
}