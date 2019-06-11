using System.Collections.Generic;

namespace Sharpdev.SDK.Extensions
{
    /// <summary>
    ///     Набор расширений для интерфейса <see cref="IEnumerable{T}" />
    /// </summary>
    public static class EnumerableExtension
    {
        /// <summary>
        ///     Создает перечисление из одного элемента <paramref name="item" />
        /// </summary>
        /// <param name="item">Элемент перечисления.</param>
        /// <typeparam name="TElementType">Тип элемента.</typeparam>
        /// <returns>
        ///     Объект <see cref="IEnumerable{T}" />, содержащий единственный элемент.
        /// </returns>
        public static IEnumerable<TElementType> Yield<TElementType>(this TElementType item)
        {
            yield return item;
        }
    }
}
