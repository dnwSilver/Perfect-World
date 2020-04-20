using System.Collections.Generic;
using System.Linq;

namespace Sharpdev.SDK.Extensions
{
    /// <summary>
    ///     Набор расширений для интерфейса <see cref="IEnumerable{T}" />.
    /// </summary>
    public static class EnumerableExtension
    {
        /// <summary>
        ///     Создает перечисление из одного элемента <paramref name="item" />.
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

        /// <summary>
        ///     Определяет заполнение перечисления.
        /// </summary>
        /// <param name="data">Проверяемое перечисление.</param>
        /// <typeparam name="T">Тип объектов которые находятся в перечислении.</typeparam>
        /// <returns>
        ///     true - если в перечислении нет элементов.
        ///     false - если в перечислении есть хотя бы один элемент.
        /// </returns>
        public static bool Empty<T>(this IEnumerable<T> data)
        {
            return !data.Any();
        }
    }
}
