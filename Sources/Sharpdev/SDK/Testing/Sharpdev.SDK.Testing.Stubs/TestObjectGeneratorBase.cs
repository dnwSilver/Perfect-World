using System.Collections.Generic;

namespace Sharpdev.SDK.Testing
{
    /// <summary>
    ///     Базовый класс для подготовки объектов.
    /// </summary>
    /// <typeparam name="TBuildingObjectType">Подменяемый объект.</typeparam>
    public abstract class TestObjectGeneratorBase<TBuildingObjectType> : ITestObjectGenerator<TBuildingObjectType>
        where TBuildingObjectType : class
    {
        /// <summary>
        ///     Заглушка для идентификатора.
        /// </summary>
        private readonly IList<TBuildingObjectType> _stubObjects = new List<TBuildingObjectType>();

        /// <summary>
        ///     Количество созданных заглушек.
        /// </summary>
        private int _createStubCount;

        /// <summary>
        ///     Построение заглушки <see cref="TBuildingObjectType" />.
        /// </summary>
        /// <returns>Экземпляр заглушки объекта <see cref="TBuildingObjectType" />.</returns>
        public IEnumerable<TBuildingObjectType> Please()
        {
            return this._stubObjects;
        }

        /// <summary>
        ///     Построение объекта типа <see cref="TBuildingObjectType" />.
        /// </summary>
        /// <returns>Экземпляр объекта типа <see cref="TBuildingObjectType" />.</returns>
        public TBuildingObjectType PorFavor()
        {
            return this.AllocateStub(default);
        }
        
        /// <summary>
        ///     Количество заглушек для генерации.
        /// </summary>
        /// <returns></returns>
        public ITestObjectGenerator<TBuildingObjectType> CountOf(int countStubObjects)
        {
            for(var iteration = 1; iteration <= countStubObjects; iteration++)
            {
                this._createStubCount++;
                this._stubObjects.Add(this.AllocateStub(this._createStubCount));
            }

            return this;
        }

        /// <summary>
        ///     Создание объекта.
        /// </summary>
        /// <param name="stubNumber">Порядковый номер создаваемого объекта.</param>
        /// <returns>Созданный объект, размещённый в куче.</returns>
        protected abstract TBuildingObjectType AllocateStub(int stubNumber);
    }
}
