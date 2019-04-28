using System.Collections.Generic;
using System.Linq;
using RieltorsManagement.DAL;

namespace RieltorsManagement.BLL
{
    /// <summary>
    /// Сервисный класс с бизнес-логикой и валидациями для риэлтора.
    /// </summary>
    public class RieltorService : IRieltorService
    {
        IUnitOfWork Database { get; set; }

        public RieltorService()
        {
            Database = new EFUnitOfWork();
        }

        /// <summary>
        /// Получение списка всех риэлторов из БД.
        /// </summary>
        /// <returns>Список всех риэлторов.</returns>
        public IEnumerable<RieltorDTO> GetRieltors()
        {
            var rieltors = Database.Rieltors.GetAll();
            return rieltors.Select(x => new RieltorDTO(x.Id, x.LastName, x.FirstName, x.CreatedDateTime, x.Division?.Name ?? ""));
        }

        /// <summary>
        /// Получение риэлтора по Id из БД.
        /// </summary>
        /// <returns>Риэлтор.</returns>
        public RieltorDTO GetRieltor(int? id)
        {
            if (id == null)
                throw new ValidationException("Id не может быть пустым.", "");

            var rieltors = GetRieltors();
            var rieltor = rieltors.Where(x => x.Id == id).FirstOrDefault();

            if (rieltor == null)
                throw new ValidationException("Не найден риэлтор с указанным Id", "");

            return rieltor;
        }

        /// <summary>
        /// Создание новой записи о риэлторе в БД.
        /// </summary>
        public void AddRieltor(RieltorDTO rieltorDTO)
        {
            Division division = Database.Divisions.
                Find(x => x.Name == rieltorDTO.Division).
                FirstOrDefault();

            if (division == null)
                throw new ValidationException("Подразделение не найдено", "");

            Rieltor rieltor = new Rieltor(rieltorDTO.FirstName, rieltorDTO.LastName, division);
            Database.Rieltors.Create(rieltor);
            Database.Save();            
        }

        /// <summary>
        /// Обновление существующей записи о риэлторе в БД.
        /// </summary>
        /// <param name="rieltor">Существующий риэлтор.</param>
        public void UpdateRieltor(RieltorDTO rieltorDTO)
        {
            var rieltor = Database.Rieltors.Get(rieltorDTO.Id);
            if (rieltor == null)
                throw new ValidationException("Не найден риэлтор с указанным Id", "");

            Division division = Database.Divisions.
                Find(x => x.Name == rieltorDTO.Division).
                FirstOrDefault();

            rieltor.FirstName = rieltorDTO.FirstName;
            rieltor.LastName = rieltorDTO.LastName;
            rieltor.Division = division ?? throw new ValidationException("Подразделение не найдено", "");

            Database.Rieltors.Update(rieltor);
            Database.Save();
        }

        /// <summary>
        /// Удаление записи о риэлторе из БД.
        /// </summary>
        /// <param name="id">Id существующего риэлтора.</param>
        public void DeleteRieltor(int? id)
        {
            if (id == null)
                throw new ValidationException("Id не может быть пустым.", "");

            var rieltor = Database.Rieltors.Get(id.Value);
            if (rieltor == null)
                throw new ValidationException("Не найден риэлтор с указанным Id", "");

            Database.Rieltors.Delete((int)id);
            Database.Save();
        }

        /// <summary>
        /// Высвобождение неиспользуемых ресурсов.
        /// </summary>
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
