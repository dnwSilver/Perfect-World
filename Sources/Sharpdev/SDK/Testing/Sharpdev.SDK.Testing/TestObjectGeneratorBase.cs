using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharpdev.SDK.Testing
{
    /// <summary>
    ///     Базовый класс для подготовки объектов.
    /// </summary>
    /// <typeparam name="TBuildingObjectType">Подменяемый объект.</typeparam>
    public abstract class TestObjectGeneratorBase<TBuildingObjectType>: ITestObjectGenerator<TBuildingObjectType>
    {
        /// <summary>
        ///     Набор созданных объектов.
        /// </summary>
        private readonly IList<TBuildingObjectType> _objectsForTest = new List<TBuildingObjectType>();

        /// <summary>
        ///     Количество созданных заглушек.
        /// </summary>
        private int _createObjectsCount;

        /// <summary>
        ///     Создание объекта.
        /// </summary>
        /// <param name="stubNumber">Порядковый номер создаваемого объекта.</param>
        /// <returns>Созданный объект, размещённый в куче.</returns>
        protected abstract TBuildingObjectType AllocateStub(int stubNumber);

        /// <summary>
        ///     Построение заглушки <see cref="TBuildingObjectType" />.
        /// </summary>
        /// <returns>Экземпляр заглушки объекта <see cref="TBuildingObjectType" />.</returns>
        public IEnumerable<TBuildingObjectType> Please
        {
            get
            {
                if (!_objectsForTest.Any())
                    throw new Exception("Нечего генерировать.");

                var generatedObjects = _objectsForTest.ToArray();
                _objectsForTest.Clear();
                return generatedObjects;

            }
        }

        /// <summary>
        ///     Построение объекта типа <see cref="TBuildingObjectType" />.
        /// </summary>
        /// <returns>Экземпляр объекта типа <see cref="TBuildingObjectType" />.</returns>
        public TBuildingObjectType PorFavor => AllocateStub(default);

        /// <summary>
        ///     Количество заглушек для генерации.
        /// </summary>
        /// <returns></returns>
        public ITestObjectGenerator<TBuildingObjectType> CountOf(int countStubObjects)
        {
            for(var iteration = 1; iteration <= countStubObjects; iteration++)
            {
                _createObjectsCount++;
                _objectsForTest.Add(AllocateStub(_createObjectsCount));
            }

            return this;
        }
    }
}
