using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharpdev.SDK.Testing
{
    /// <summary>
    ///     Базовый класс для подготовки объектов.
    /// </summary>
    /// <typeparam name="TTestObjectType">Подменяемый объект.</typeparam>
    public abstract class TestObjectGeneratorBase<TTestObjectType>: ITestObjectGenerator<TTestObjectType>
    {
        /// <summary>
        ///     Набор созданных объектов.
        /// </summary>
        private readonly IList<TTestObjectType> _testObjects = new List<TTestObjectType>();

        /// <summary>
        ///     Количество созданных заглушек.
        /// </summary>
        private int _createTestObjectsCount;

        /// <summary>
        ///     Создание объекта.
        /// </summary>
        /// <param name="testObjectNumber">Порядковый номер создаваемого объекта.</param>
        /// <returns>Созданный объект, размещённый в куче.</returns>
        protected abstract TTestObjectType Allocate(int testObjectNumber);

        /// <summary>
        ///     Построение заглушки <see cref="TTestObjectType" />.
        /// </summary>
        /// <returns>Экземпляр заглушки объекта <see cref="TTestObjectType" />.</returns>
        public IEnumerable<TTestObjectType> Please
        {
            get
            {
                if (!_testObjects.Any())
                    throw new Exception("Нечего генерировать.");

                var generatedObjects = _testObjects.ToArray();
                _testObjects.Clear();
                return generatedObjects;
            }
        }

        /// <summary>
        ///     Построение объекта типа <see cref="TTestObjectType" />.
        /// </summary>
        /// <returns>Экземпляр объекта типа <see cref="TTestObjectType" />.</returns>
        public TTestObjectType PorFavor => Allocate(_createTestObjectsCount++);

        /// <summary>
        ///     Количество заглушек для генерации.
        /// </summary>
        /// <returns></returns>
        public ITestObjectGenerator<TTestObjectType> CountOf(int countStubObjects)
        {
            for(var iteration = 1; iteration <= countStubObjects; iteration++)
            {
                _testObjects.Add(Allocate(_createTestObjectsCount++));
            }

            return this;
        }
    }
}
