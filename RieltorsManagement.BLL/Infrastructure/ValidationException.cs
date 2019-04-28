using System;

namespace RieltorsManagement.BLL
{
    /// <summary>
    /// Исключение для валидаций.
    /// </summary>
    public class ValidationException : Exception
    {
        public string Property { get; protected set; }

        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}