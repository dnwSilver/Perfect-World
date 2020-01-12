using System.Collections.Generic;
using System.Reflection;

namespace Sharpdev.SDK.Testing
{
    /// <summary>
    ///     Строитель для объектов используемых при тестировании.
    /// </summary>
    /// <typeparam name="TBuildingObjectType">Тип собираемого объекта.</typeparam>
    /// <remarks>
    ///     По-хорошему строитель должен упрощать создание объекта настолько, чтобы код был понятен
    ///     доменному эксперту. Особенно стоит использовать строитель для объектов, которые требуют
    ///     настройки перед началом работы.
    /// </remarks>
    public interface ITestObjectGenerator<out TBuildingObjectType>
    {
        /// <summary>
        ///      Построение набора объектов типа <see cref="TBuildingObjectType" />.
        /// </summary>
        /// <returns>Набор экземпляров объекта типа <see cref="TBuildingObjectType" />.</returns>
        IEnumerable<TBuildingObjectType> Please { get; }

        /// <summary>
        ///     Построение объекта типа <see cref="TBuildingObjectType" />.
        /// </summary>
        /// <returns>Экземпляр объекта типа <see cref="TBuildingObjectType" />.</returns>
        TBuildingObjectType PorFavor { get; }
        
        /// <summary>
        /// Количество объектов для генерации.
        /// </summary>
        /// <param name="countGeneratedObjects">Количество создаваемых объектов.</param>
        /// <returns>Генератор объектов.</returns>
        ITestObjectGenerator<TBuildingObjectType> CountOf(int countGeneratedObjects);
    }

    public static class UpdateObjectExtension
    {
        public static TObject With<TObject>(this TObject @object, string propertyName, object value)
        {
            var prop = @object.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);

            if(null != prop && prop.CanWrite)
            {
                prop.SetValue(@object, value, null);
            }
            
            return @object;
        }
        public static TObject WithOut<TObject>(this TObject @object, string propertyName)
        {
            var prop = @object.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);

            if(null != prop && prop.CanWrite)
            {
                prop.SetValue(@object, null, null);
            }

            return @object;
        }
    }

}
