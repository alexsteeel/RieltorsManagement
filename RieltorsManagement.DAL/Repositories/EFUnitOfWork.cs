using System;

namespace RieltorsManagement.DAL
{
    /// <summary>
    /// Класс для взаимодействия с БД.
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork
    {
        #region Constructors.

        public EFUnitOfWork()
        {
            var dba = new RieltorContextOptionsBuilder();
            db = new RieltorContext(dba.GetDbContextOptionsJson());
        }

        #endregion

        #region Fields and properties.

        /// <summary>
        /// Контекст базы данных.
        /// </summary>
        private RieltorContext db;

        /// <summary>
        /// Репозиторий для риэлторов.
        /// </summary>
        private RieltorRepository _rieltorRepository;
        public IRepository<Rieltor> Rieltors
        {
            get
            {
                if (_rieltorRepository == null)
                    _rieltorRepository = new RieltorRepository(db);
                return _rieltorRepository;
            }
        }

        /// <summary>
        /// Репозиторий для подразделений.
        /// </summary>
        private DivisionRepository _divisionRepository;
        public IRepository<Division> Divisions
        {
            get
            {
                if (_divisionRepository == null)
                    _divisionRepository = new DivisionRepository(db);
                return _divisionRepository;
            }
        }

        /// <summary>
        /// Флаг состояния подключения к БД (true - удалено, false - не удалено).
        /// </summary>
        private bool disposed = false;

        #endregion

        #region Methods.

        /// <summary>
        /// Сохранение изменений.
        /// </summary>
        public void Save()
        {
            db.SaveChanges();
        }

        /// <summary>
        /// Удаление соединения с БД.
        /// </summary>
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Освобождение ресурсов.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}