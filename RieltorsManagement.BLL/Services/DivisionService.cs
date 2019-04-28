using System.Collections.Generic;
using System.Linq;
using RieltorsManagement.DAL;

namespace RieltorsManagement.BLL
{
    /// <summary>
    /// Сервисный класс с бизнес-логикой и валидациями для подразделения.
    /// </summary>
    public class DivisionService : IDivisionService
    {
        IUnitOfWork Database { get; set; }

        public DivisionService()
        {
            Database = new EFUnitOfWork();
        }

        /// <summary>
        /// Получение списка всех подразделений из БД.
        /// </summary>
        /// <returns>Список всех подразделений.</returns>
        public IEnumerable<DivisionDTO> GetDivisions()
        {
            var divisions = Database.Divisions.GetAll();
            return divisions.Select(x => new DivisionDTO(x.Id, x.Name, x.CreatedDateTime));
        }

        /// <summary>
        /// Получение подразделения по Id из БД.
        /// </summary>
        /// <returns>Подразделение.</returns>
        public DivisionDTO GetDivision(int? id)
        {
            if (id == null)
                throw new ValidationException("Id не может быть пустым.", "");

            var division = Database.Divisions.Get(id.Value);
            if (division == null)
                throw new ValidationException("Не найдено подразделение с указанным Id", "");

            return new DivisionDTO(division.Id, division.Name, division.CreatedDateTime);
        }

        /// <summary>
        /// Создание новой записи о подразделении в БД.
        /// </summary>
        public void AddDivision(DivisionDTO divisionDTO)
        {
            Division division = new Division(divisionDTO.Name);
            Database.Divisions.Create(division);
            Database.Save();
        }

        /// <summary>
        /// Обновление существующей записи о подразделении в БД.
        /// </summary>
        /// <param name="rieltor">Существующее подразделение.</param>
        public void UpdateDivision(DivisionDTO divisionDTO)
        {
            var division = Database.Divisions.Get(divisionDTO.Id);
            if (division == null)
                throw new ValidationException("Не найдено подразделение с указанным Id", "");

            Database.Divisions.Update(division);
            Database.Save();
        }

        /// <summary>
        /// Удаление записи о подразделении из БД.
        /// </summary>
        /// <param name="id">Id существующего подразделения.</param
        public void DeleteDivision(int? id)
        {
            if (id == null)
                throw new ValidationException("Id не может быть пустым.", "");

            var division = Database.Divisions.Get(id.Value);
            if (division == null)
                throw new ValidationException("Не найдено подразделение с указанным Id", "");

            Database.Divisions.Delete((int)id);
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
