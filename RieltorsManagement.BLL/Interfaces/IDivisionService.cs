using System.Collections.Generic;

namespace RieltorsManagement.BLL
{
    /// <summary>
    /// Интерфейс взаимодействия для подразделения.
    /// </summary>
    public interface IDivisionService
    {
        /// <summary>
        /// Получение списка всех подразделений.
        /// </summary>
        IEnumerable<DivisionDTO> GetDivisions();

        /// <summary>
        /// Получение записи по Id.
        /// </summary>
        DivisionDTO GetDivision(int? id);

        /// <summary>
        /// Добавление новой записи.
        /// </summary>
        void AddDivision(DivisionDTO divisionDTO);

        /// <summary>
        /// Высвобождение ресурсов.
        /// </summary>
        void Dispose();
    }
}
