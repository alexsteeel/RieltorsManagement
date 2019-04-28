using System.Collections.Generic;

namespace RieltorsManagement.BLL
{
    /// <summary>
    /// Интерфейс взаимодействия для риэлтора.
    /// </summary>
    public interface IRieltorService
    {
        /// <summary>
        /// Получение списка всех риэлторов.
        /// </summary>
        IEnumerable<RieltorDTO> GetRieltors();

        /// <summary>
        /// Получение записи по Id.
        /// </summary>
        RieltorDTO GetRieltor(int? id);

        /// <summary>
        /// Добавление новой записи.
        /// </summary>
        void AddRieltor(RieltorDTO rieltorDTO);

        /// <summary>
        /// Высвобождение ресурсов.
        /// </summary>
        void Dispose();
    }
}
