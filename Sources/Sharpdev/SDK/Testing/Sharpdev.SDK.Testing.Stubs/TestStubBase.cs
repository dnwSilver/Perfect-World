using System.Collections.Generic;
using System.Linq;

namespace Sharpdev.SDK.Testing
{
    /// <summary>
    ///     Базовый класс для подготовки stub.
    /// </summary>
    /// <typeparam name="TBuildingObjectType">Подменяемый объект.</typeparam>
    public abstract class TestStubBase<TBuildingObjectType> : ITestStub<IList<TBuildingObjectType>>
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
        public IList<TBuildingObjectType> Please()
        {
            if (!this._stubObjects.Any())
                this.CountOf(1);

            return this._stubObjects;
        }

        /// <summary>
        ///     Количество заглушек для генерации.
        /// </summary>
        /// <returns></returns>
        public ITestStub<IList<TBuildingObjectType>> CountOf(int countStubObjects)
        {
            for(var iteration = 0; iteration < countStubObjects; iteration++)
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
